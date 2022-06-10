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
    public partial class FrmOgrenciNotlar : Form
    {
        public FrmOgrenciNotlar()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=MSAGLAM\MSSQLSERVER1;Initial Catalog=BonusOkul;Integrated Security=True");
        public string numara;
        private void FrmOgrenciNotlar_Load(object sender, EventArgs e)
        {
            /* Ogrencı Ekranından Giriş Yapılan Öğrencinin Notlarını Getirme */
            /* SQL Inner Join Kullanarak İki Tablo Arasında Birleştirme İşlemi Yapıldı */ 
            SqlCommand komut = new SqlCommand("Select DERSAD, SINAV1, SINAV2, SINAV3, PROJE, ORTALAMA, DURUM From TBLNOTLAR inner join TBLDERSLER ON TBLNOTLAR.DERSID = TBLDERSLER.DERSID where OGRENCIID = @P1", baglanti);
            komut.Parameters.AddWithValue("@P1", numara);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
