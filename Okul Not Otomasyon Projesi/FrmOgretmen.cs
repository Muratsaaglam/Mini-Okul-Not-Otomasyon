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
    public partial class FrmOgretmen : Form
    {
        public FrmOgretmen()
        {
            InitializeComponent();
        }

        private void FrmOgretmen_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmKulupler frmkulup = new FrmKulupler();
            frmkulup.Show();
            Hide();
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmDersler frmDersler = new FrmDersler();
            frmDersler.Show();
            Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmOgrenci frmogrenci = new FrmOgrenci();
            frmogrenci.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmSınavNotlar frmSınavNotlar = new FrmSınavNotlar();
            frmSınavNotlar.Show();
            Hide();
        }
    }
}
