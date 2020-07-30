using Caïssa.Models;
using Caïssa.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Caïssa
{
    public partial class mesaj : Form
    {
        private kullanicilar bilgilerim = new bilgilerim().getir();
        public kullanicilar arkadasim;
        OnlineSatrancEntities db = new OnlineSatrancEntities();
        public mesaj()
        {
            InitializeComponent();
        }

        private void mesaj_Load(object sender, EventArgs e)
        {
            Text = arkadasim.kAdi + " (" + (arkadasim.durum ? "Çevrimiçi" : "Çevrimdışı") + ")";

                mesajGoster(false);
        }

        private void mesajTBx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                mesajlar mesaj = db.mesajlar.Add(new mesajlar { gonderenID = bilgilerim.ID, aliciID = arkadasim.ID, mesaj = mesajTBx.Text, tarih = DateTime.Now });

                    if (db.SaveChanges() == 0) { mesajKutusu(mesaj, true); } else { mesajKutusu(mesaj, false); }

                mesajTBx.Clear();
            }
        }

        private void mesajGetirici_Tick(object sender, EventArgs e)
        {
            if (mesajlarPanel.Controls.Count != 0) mesajGoster(true); else mesajGoster(false);
        }

        private void mesajGoster(bool sonMesaj)
        {
            int bilgilerimID = bilgilerim.ID;
            DateTime onGunOnce = DateTime.Now.AddDays(-10);
            List<mesajlar> mesajlar = new List<mesajlar>();

              if (sonMesaj) { int sonMesajID = Convert.ToInt32(mesajlarPanel.Controls.OfType<Label>().Last().Name.Split('_')[1]); mesajlar = db.mesajlar.Where(s => (s.gonderenID == bilgilerimID && s.aliciID == arkadasim.ID || s.gonderenID == arkadasim.ID && s.aliciID == bilgilerimID) && s.tarih >= onGunOnce && s.tarih <= DateTime.Now && s.ID > sonMesajID).ToList(); }
              else mesajlar = db.mesajlar.Where(s => (s.gonderenID == bilgilerimID && s.aliciID == arkadasim.ID || s.gonderenID == arkadasim.ID && s.aliciID == bilgilerimID) && s.tarih >= onGunOnce && s.tarih <= DateTime.Now).ToList();

                foreach (mesajlar mesaj in mesajlar) mesajKutusu(mesaj, false);
        }

        private void mesajKutusu(mesajlar mesaj, bool hata)
        {
            string mesajsaati;
            if (mesaj.tarih.Day == DateTime.Now.Day) { mesajsaati = mesaj.tarih.ToShortTimeString(); } else if (DateTime.Now.Day - mesaj.tarih.Day == 1) { mesajsaati = "Dün " + mesaj.tarih.ToShortTimeString(); } else { mesajsaati = mesaj.tarih.ToShortDateString() + " " + mesaj.tarih.ToShortTimeString(); }
            Label mesajLabel = new Label() { Name = "mesaj_" + mesaj.ID, Text = mesaj.kullanicilar.kAdi + ": " + mesaj.mesaj + " (" + mesajsaati + ")", ForeColor = mesaj.kullanicilar.durum ? Color.Green : Color.LightGray, Dock = DockStyle.Bottom };
            if (hata) { mesajLabel.ForeColor = Color.Red; mesajLabel.Text += " (Mesaj gönderilemedi)"; }
            else if (mesaj.mesaj.StartsWith("Oda No: ") && new Regex("^[0-9]*$").IsMatch(mesaj.mesaj.Split('(', ')')[1]) && new Regex("^[0-9]*$").IsMatch(mesaj.mesaj.Split('[', ']')[1]))
            { 
                mesajLabel.ForeColor = Color.LightBlue; mesajLabel.Font = new Font(mesajLabel.Font, FontStyle.Underline); mesajLabel.Cursor = Cursors.Hand; mesajLabel.Tag = "(" + mesaj.mesaj.Split('(', ')')[1] + ")[" + mesaj.mesaj.Split('[', ']')[1] + "]"; mesajLabel.Click += davetKabul;
            }
            mesajlarPanel.Controls.Add(mesajLabel);
        }

        private void davetKabul(object sender, EventArgs e)
        {
            Label odaBilgisi = (Label) sender;

                Properties.Settings.Default.odaNo = Convert.ToInt32(odaBilgisi.Tag.ToString().Split('(', ')')[1]);
                Properties.Settings.Default.Save();

            int odaNo = Properties.Settings.Default.odaNo, odaTuru = (int) db.satrancTahtalari.Where(s => s.ID == odaNo).FirstOrDefault().odaTuru;
            Form oda = null;

            if (odaTuru == 1) oda = new klasikSatranc(Convert.ToInt32(odaBilgisi.Tag.ToString().Split('[', ']')[1])); else if (odaTuru == 2) oda = new dortluSatranc(Convert.ToInt32(odaBilgisi.Tag.ToString().Split('[', ']')[1]));

            if (oda != null) ((Form1) Application.OpenForms["Form1"]).openChildForm(oda); else MessageBox.Show("Alınan davetteki odaya erişilemedi", "Davet Hatası!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void cevrimiciDurum_Tick(object sender, EventArgs e)
        {
            bool cevrimiciDurum = new OnlineSatrancEntities().kullanicilar.Where(s => s.ID == arkadasim.ID).FirstOrDefault().durum;

                if (cevrimiciDurum && !Text.Contains("Çevrimiçi")) { Text = Text.Replace("dışı", "içi"); foreach (Control mesaj in mesajlarPanel.Controls) if (mesaj.Text.Contains(arkadasim.kAdi)) mesaj.ForeColor = Color.Green; }
                else if (!cevrimiciDurum && !Text.Contains("Çevrimdışı")) { Text = Text.Replace("içi", "dışı"); foreach (Control mesaj in mesajlarPanel.Controls) if (mesaj.Text.Contains(arkadasim.kAdi)) mesaj.ForeColor = Color.LightGray; }
        }
    }
}
