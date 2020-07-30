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
using Caïssa.Models.EntityFramework;

namespace Caïssa
{
    public partial class Form1 : Form
    {
        private Form activeForm = null;
        private SatrancTahtasiController satrancTahtasiController = new SatrancTahtasiController();
        private OnlineSatrancEntities db = new OnlineSatrancEntities();
        private kullanicilar bilgilerim = new bilgilerim().getir();
        public Form1()
        {
            InitializeComponent();
            customizeDesign();
            openChildForm(new GirisYap());

                FormClosing += cevrimdisiOl; // Çevrimdışı ol!
        }

        private void cevrimdisiOl(object sender, FormClosingEventArgs e)
        {
            try
            {
                db.kullanicilar.Where(s => s.ID == bilgilerim.ID).FirstOrDefault().durum = false;
                db.SaveChanges();
            } catch {}
        }

        private void customizeDesign()
        {
            panelMacBulSubMenu.Visible = false;
            panelMacKurSubMenu.Visible = false;
            panelBotlaOynaSubMenu.Visible = false;
        }

        private void hideSubMenu()
        {
            if (panelMacBulSubMenu.Visible == true)
                panelMacBulSubMenu.Visible = false;
            if (panelMacKurSubMenu.Visible == true)
                panelMacKurSubMenu.Visible = false;
            if (panelBotlaOynaSubMenu.Visible == true)
                panelBotlaOynaSubMenu.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void macBul_Click(object sender, EventArgs e)
        {
            showSubMenu(panelMacBulSubMenu);
        }

        private void klasik_Click(object sender, EventArgs e)
        {
            openChildForm(new macBul(1));
            hideSubMenu();
        }

        private void dortluSatranc_Click(object sender, EventArgs e)
        {
            openChildForm(new macBul(2));
            hideSubMenu();
        }

        private void takimliSatranc_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void macKur_Click(object sender, EventArgs e)
        {
            showSubMenu(panelMacKurSubMenu);
        }

        private void soloMacKur_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.odaNo = satrancTahtasiController.OdaKur(false, 1);
            Properties.Settings.Default.Save();
            openChildForm(new klasikSatranc(0));
            hideSubMenu();
        }

        private void dortluMacKur_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.odaNo = satrancTahtasiController.OdaKur(false, 2);
            Properties.Settings.Default.Save();
            openChildForm(new dortluSatranc(0));
            hideSubMenu();
        }

        private void botlaOyna_Click(object sender, EventArgs e)
        {
            showSubMenu(panelBotlaOynaSubMenu);
        }

        private void kolay_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void orta_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void zor_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        public void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void test_Click(object sender, EventArgs e)
        {
            openChildForm(new test());
        }
    }
}
