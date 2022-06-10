using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Okul_Not_Otomasyon_Projesi
{
    public partial class FrmSınavNotlar : Form
    {
        public FrmSınavNotlar()
        {
            InitializeComponent();
        }

        /* Not ID */
        int notid;
        /* DataSet Tanımlama */
        BonusOkulDataSetTableAdapters.TBLNOTLARTableAdapter ds = new BonusOkulDataSetTableAdapters.TBLNOTLARTableAdapter();
        SqlConnection baglanti = new SqlConnection(@"Data Source=MSAGLAM\MSSQLSERVER1;Initial Catalog=BonusOkul;Integrated Security=True");

        private void BtnAra_Click(object sender, EventArgs e)
        {
            /* Öğrenci Arama */
            dataGridView1.DataSource = ds.NotListesi(int.Parse(TxtOgrId.Text));
        }

        private void FrmSınavNotlar_Load(object sender, EventArgs e)
        {
            /* ComboBoxa Derslerin Otomatik Yazılması */ 
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from TBLDERSLER", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DisplayMember = "DERSAD";
            comboBox1.ValueMember = "DERSID";
            comboBox1.DataSource = dt;
            baglanti.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /* DataGrid View'e Sol Tıklandığında Verilerin Otomatik Aktarılması*/
            notid= int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            TxtOgrId.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            TxtSinav1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            TxtSinav2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            TxtSinav3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            TxtProje.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            TxtOrtalama.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            TxtDurum.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();

        }

        /* Hesaplama Butonu */
        int sinav1, sinav2, sinav3, proje;
        double ortalama;
        string durum;
        private void BtnHesapla_Click(object sender, EventArgs e)
        {
            

            /*String Durum */

            sinav1 = Convert.ToInt16(TxtSinav1.Text);
            sinav2 = Convert.ToInt16(TxtSinav2.Text);
            sinav3 = Convert.ToInt16(TxtSinav3.Text);
            proje = Convert.ToInt16(TxtProje.Text);
            ortalama = (sinav1+sinav2+sinav3+proje)/4;
            TxtOrtalama.Text = ortalama.ToString();
            if (ortalama>50)
            {
                TxtDurum.Text = "True";
            }
            else
            {
                TxtDurum.Text = "False";

            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            /* Not Güncelleme */
            ds.NotGuncelle(byte.Parse(comboBox1.SelectedValue.ToString()),int.Parse(TxtOgrId.Text),
                byte.Parse(TxtSinav1.Text), byte.Parse(TxtSinav2.Text), byte.Parse(TxtSinav3.Text), 
                byte.Parse(TxtProje.Text), decimal.Parse(TxtOrtalama.Text), bool.Parse(TxtDurum.Text),notid);
            dataGridView1.DataSource = ds.NotListesi(int.Parse(TxtOgrId.Text));

        }
    }
}
