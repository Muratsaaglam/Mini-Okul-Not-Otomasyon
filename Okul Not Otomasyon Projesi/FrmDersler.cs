using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Okul_Not_Otomasyon_Projesi
{
    public partial class FrmDersler : Form
    {
        public FrmDersler()
        {
            InitializeComponent();
        }
        
        /*DataSet Tanımlama */ 
        BonusOkulDataSetTableAdapters.TBLDERSLERTableAdapter ds = new BonusOkulDataSetTableAdapters.TBLDERSLERTableAdapter();


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmOgretmen frm = new FrmOgretmen();
            frm.Show();
            this.Hide();
        }

        private void FrmDersler_Load(object sender, EventArgs e)
        {
            /* DataSet Kullanarak Dersleri Listeleyen Kod Bölünü */ 
            dataGridView1.DataSource = ds.DersListesi();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            /* DataSet İle Ders Ekleyen Kod Bölümü */
            ds.DersEkle(TxtDersAd.Text);
            MessageBox.Show("Ders Ekleme İşlemi Yapılmıştır.");
            dataGridView1.DataSource = ds.DersListesi();

        }

        private void BtnListe_Click(object sender, EventArgs e)
        {
            /* DataSet İle Dersleri Listeyen Kod Bölümü */
            dataGridView1.DataSource = ds.DersListesi();

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            /* DataSet İle Dersleri Silen Kod Bölümü */
            ds.DersSil(byte.Parse(TxtDersId.Text));
            dataGridView1.DataSource = ds.DersListesi();

        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            /* DataSet İle Dersleri Güncelleme Kod Bölümü */
            ds.DersGuncelle(TxtDersAd.Text,byte.Parse(TxtDersId.Text));
            dataGridView1.DataSource = ds.DersListesi();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*Data GridView'deki Verilere Sol Tıklayınca TextBoxlara Otomatik Dolmasını Sağlayan Kod Bölümü */
            TxtDersId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtDersAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

        }
    }
}
