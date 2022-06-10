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
    public partial class FrmOgrenci : Form
    {
        public FrmOgrenci()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmOgretmen frm= new FrmOgretmen();
            frm.Show();
            Hide();
        }

        /*DataSet Tanımlama */
        BonusOkulDataSetTableAdapters.DataTable1TableAdapter ds = new BonusOkulDataSetTableAdapters.DataTable1TableAdapter();
        SqlConnection baglanti = new SqlConnection(@"Data Source=MSAGLAM\MSSQLSERVER1;Initial Catalog=BonusOkul;Integrated Security=True");

        private void FrmOgrenci_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from TBLKULUPLER",baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DisplayMember = "KULUPAD";
            comboBox1.ValueMember = "KULUPID";
            comboBox1.DataSource = dt;
            baglanti.Close();
        }

        /* Cinsiyet İçin Bir Boş Değer Atandı. */ 
        string c = "";

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            /* Öğrenci Ekleme */
            

            ds.OgrenciEkle(TxtOgrAd.Text, TxtOgrSoyad.Text, byte.Parse(comboBox1.SelectedValue.ToString()), c);
            MessageBox.Show("Öğrenci Ekleme İşlemi Başarıyla Tamamlandı");
            dataGridView1.DataSource = ds.OgrenciListesi();


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /* DataGrid View'e Sol Tıklandığında Verilerin Otomatik Aktarılması*/
            TxtOgrId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtOgrAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtOgrSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            /* Öğrenci Sil. */
            ds.OgrenciSil(int.Parse(TxtOgrId.Text));
            MessageBox.Show("Öğrenci Kaydı Silindi.");
            dataGridView1.DataSource = ds.OgrenciListesi();

        }

        private void BtnListe_Click(object sender, EventArgs e)
        {
            /* Verileri Listeleme */ 
            dataGridView1.DataSource = ds.OgrenciListesi();

        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            /* Öğrenci Güncelleme */
            ds.OgrenciGuncelle(TxtOgrAd.Text, TxtOgrSoyad.Text, byte.Parse(comboBox1.SelectedValue.ToString()), c, int.Parse(TxtOgrId.Text));
            MessageBox.Show("Öğrenci Bilgileri Güncellendi.");
            dataGridView1.DataSource = ds.OgrenciListesi();

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                c = "KIZ";
            }
           
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                c = "ERKEK";
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /* Öğrenci Arama */
            dataGridView1.DataSource = ds.OgrenciGetir(TxtOgrArama.Text);

        }
    }
}
