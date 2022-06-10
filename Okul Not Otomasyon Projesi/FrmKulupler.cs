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
    public partial class FrmKulupler : Form
    {
        public FrmKulupler()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=MSAGLAM\MSSQLSERVER1;Initial Catalog=BonusOkul;Integrated Security=True");
        public void Listele()
        {

            /* Kuluplerdeki Verilerin Otomatik Gelmesini Sağlayan Kod Bölümü */
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBLKULUPLER", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmOgretmen frm = new FrmOgretmen();
            frm.Show();
            this.Hide();
        }

        private void FrmKulupler_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void BtnListe_Click(object sender, EventArgs e)
        {
            Listele();

        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            /* Kulup Ekleme Kod Bölümü */
            baglanti.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO TBLKULUPLER (KULUPAD) values (@P1)",baglanti);
            komut.Parameters.AddWithValue("@P1",TxtKulupAd.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kulup Listeye Eklendi");
            Listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*Data GridView'deki Verilere Sol Tıklayınca TextBoxlara Otomatik Dolmasını Sağlayan Kod Bölümü */ 
            TxtKulupId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtKulupAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            /* Kulup Silme Kod Bölümü */
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Delete from TBLKULUPLER Where KULUPID=@P1",baglanti);
            komut.Parameters.AddWithValue("@P1",TxtKulupId.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kulüp Silindi");
            Listele();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            /*Kulup Bilgileri Güncelleyen Kod Bölümü */
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Update TBLKULUPLER SET KULUPAD=@P1 WHERE KULUPID=@P2",baglanti);
            komut.Parameters.AddWithValue("@P1",TxtKulupAd.Text);
            komut.Parameters.AddWithValue("@P2",TxtKulupId.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Güncelleme İşlemi Gerçekleştirildi.");
            Listele();
        }
    }
}
