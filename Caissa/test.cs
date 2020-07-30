using System;
using System.Linq;
using System.Windows.Forms;
using Caïssa.Models;

namespace Caïssa
{
    public partial class test : Form
    {
        private Form1 frm1 = null;
        public test()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            satrancAlgoritmasi satranc = new satrancAlgoritmasi(notasyon.Text, pozisyon.Text, 10200, 0, "", 2);

            if (satranc.HamleKontrol()) MessageBox.Show("Başarılı"); else MessageBox.Show("Başarısız");
        }

        private void geriDon_Click(object sender, EventArgs e)
        {
            frm1 = Application.OpenForms.OfType<Form1>().SingleOrDefault();
            frm1.openChildForm(new Home());
        }
    }
}
