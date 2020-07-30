using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Caïssa.Controllers;
using Caïssa.Models;

namespace Caïssa
{
    public partial class macBul : Form
    {
        private Form1 frm1;
        public int odaTuru;
        public bilgilerim bilgilerim = new bilgilerim();
        int saniye = 0, dakika = 0, saat = 0;
        SatrancTahtasiController controller = new SatrancTahtasiController();

        public macBul(int odaTipi)
        {
            odaTuru = odaTipi;
            InitializeComponent();
        }

        private void kabulEt_Click(object sender, EventArgs e)
        {
            frm1 = Application.OpenForms.OfType<Form1>().SingleOrDefault();

                if (odaTuru == 1) frm1.openChildForm(new klasikSatranc(0));
                else if (odaTuru == 2) frm1.openChildForm(new dortluSatranc(0));
        }

        private void macBulSayaci_Tick(object sender, EventArgs e)
        {
            if (saniye < 59) saniye++;
            else
            {
                saniye = 0; 
                if (dakika < 59) dakika++;
                else { dakika = 0; saat++; }
            }

                hour.Text = saat < 10 ? "0" + saat : saat.ToString();
                minute.Text = dakika < 10 ? "0" + dakika : dakika.ToString();
                second.Text = saniye < 10 ? "0" + saniye : saniye.ToString();

            int gelenOdaNo = controller.Eslestir(odaTuru);

            if (gelenOdaNo != 0)
            {
                Properties.Settings.Default.odaNo = gelenOdaNo;
                Properties.Settings.Default.Save();

                    if (controller.rakipGetir() != null && controller.rakipGetir().ID == bilgilerim.getir().ID) kabulEt.Text = "KALDIĞIN YERDEN DEVAM ET";
                    else if (controller.rakip2Getir() != null && controller.rakip2Getir().ID == bilgilerim.getir().ID) kabulEt.Text = "KALDIĞIN YERDEN DEVAM ET";
                    else if (controller.rakip3Getir() != null && controller.rakip3Getir().ID == bilgilerim.getir().ID) kabulEt.Text = "KALDIĞIN YERDEN DEVAM ET";

                kabulEt.Visible = true;
                macBulSayaci.Stop();
            }
        }
    }
}
