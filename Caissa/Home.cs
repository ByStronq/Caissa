using Caïssa.Models;
using Caïssa.Models.EntityFramework;
using Caïssa.Properties;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Caïssa
{
    public partial class Home : Form
    {
        private OnlineSatrancEntities db = new OnlineSatrancEntities();
        private kullanicilar bilgilerim = new bilgilerim().getir();
        private int sonMesajID;
        public Home()
        {
            InitializeComponent();

                db.kullanicilar.Where(s => s.ID == bilgilerim.ID).FirstOrDefault().durum = true;
                db.SaveChanges(); // Çevrimiçi ol!

            IOrderedQueryable<mesajlar> mesajlarIQ = db.mesajlar.Where(s => s.aliciID == bilgilerim.ID).OrderByDescending(s => s.ID);
            sonMesajID = mesajlarIQ.FirstOrDefault() != null ? mesajlarIQ.FirstOrDefault().ID : 0;
        }

        private void Home_Load(object sender, EventArgs e)
        {
            kAdi.Text = bilgilerim.kAdi;
            pp.Image = bilgilerim.cinsiyet ? Resources.img_avatar1 : Resources.img_avatar2;

            rutbeGoster(bilgilerim.ELO, bilgilerim.cinsiyet, rutbeTas, rutbeAd);

            rutbeELO.Text = "ELO: " + bilgilerim.ELO;

            Panel arkadaslarPanel = new Panel { Name = "arkadaslarPanel", Size = new Size(240, 38), BorderStyle = BorderStyle.FixedSingle };

            Label kategoriAd1 = new Label() { Name = "arkadaslarLabel", Text = "ARKADAŞLAR", ForeColor = Color.WhiteSmoke, Dock = DockStyle.Left }, kategoriAd2 = new Label() { Name = "isteklerLabel", Text = "İSTEKLER", ForeColor = Color.WhiteSmoke };

            Button arkadasEkleBtn = new Button { Name = "arkadasEkleBtn", Size = new Size(38, 38), Margin = Padding.Empty, FlatStyle = FlatStyle.Flat, BackgroundImage = Resources.arkadasEkle, BackgroundImageLayout = ImageLayout.Zoom, Dock = DockStyle.Right }; arkadasEkleBtn.Click += arkadasEkleBtn_Click;

            arkadaslarPanel.Controls.AddRange(new Control[] { arkadasEkleBtn, kategoriAd1 }); arkadaslar.Controls.Add(arkadaslarPanel); istekler.Controls.Add(kategoriAd2);

                arkadaslarGetir();

            satrancTahtalari satrancTahtalari = db.satrancTahtalari.Where(s => s.odaSahibi == bilgilerim.ID || s.rakip == bilgilerim.ID || s.rakip2 == bilgilerim.ID || s.rakip3 == bilgilerim.ID).FirstOrDefault();

            if (satrancTahtalari != null)
            {
                Settings.Default.odaNo = satrancTahtalari.ID;
                Settings.Default.Save();
                Button yenidenBaglan = new Button { Name = "yenidenBaglan", Text = "Yeniden Bağlan", FlatStyle = FlatStyle.Flat, Size = new Size(125, 38), ForeColor = Color.WhiteSmoke, BackColor = Color.Green }; yenidenBaglan.Click += yenidenBaglan_Click;
                Button mactanAyril = new Button { Name = "mactanAyril", Text = "Maçtan Ayrıl", FlatStyle = FlatStyle.Flat, Size = new Size(99, 38), ForeColor = Color.WhiteSmoke, BackColor = Color.Red }; mactanAyril.Click += mactanAyril_Click;
                posts.Controls.AddRange(new Control[] { yenidenBaglan, mactanAyril });
            }
        }

        private void yenidenBaglan_Click(object sender, EventArgs e) { ((Form1) Application.OpenForms["Form1"]).openChildForm((db.satrancTahtalari.Where(s => s.ID == Settings.Default.odaNo).FirstOrDefault().odaTuru == 1) ? (Form) new klasikSatranc(0) : new dortluSatranc(0)); }

        private void mactanAyril_Click(object sender, EventArgs e)
        {
            satrancTahtalari satrancTahtalari = db.satrancTahtalari.Where(s => s.odaSahibi == bilgilerim.ID || s.rakip == bilgilerim.ID || s.rakip2 == bilgilerim.ID || s.rakip3 == bilgilerim.ID).FirstOrDefault();

            if (satrancTahtalari != null)
            {
                if (satrancTahtalari.rakip == bilgilerim.ID) { satrancTahtalari.rakip = null; satrancTahtalari.kullanicilar1.ELO -= 150; }
                else if (satrancTahtalari.rakip2 == bilgilerim.ID) { satrancTahtalari.rakip2 = null; satrancTahtalari.kullanicilar2.ELO -= 150; }
                else if (satrancTahtalari.rakip3 == bilgilerim.ID) { satrancTahtalari.rakip3 = null; satrancTahtalari.kullanicilar3.ELO -= 150; }

                    if (MessageBox.Show("Maçtan ayrılmak istediğinize emin misiniz ? (-150 ELO Puanı)", "Maçtan Ayrıl", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (db.SaveChanges() > 0)
                        {
                            posts.Controls.RemoveByKey("yenidenBaglan");
                            posts.Controls.RemoveByKey("mactanAyril");
                            MessageBox.Show("Maçtan ayrıldınız");
                        }
                        else MessageBox.Show("Maçtan ayrılırken bir sorun oluştu!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }
        }

        private void arkadasEkleBtn_Click(object sender, EventArgs e)
        {
            Form prompt = new Form() { Width = 500, FormBorderStyle = FormBorderStyle.FixedDialog, Text = "Arkadaş Ekleme", StartPosition = FormStartPosition.CenterScreen };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = "Kullanıcı Adı: " };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            Button confirmation = new Button() { Text = "Ara!", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += arkadasEkle;
            prompt.Controls.AddRange(new Control[] { textBox, confirmation, textLabel, /*aramaPanel*/ });
            prompt.AcceptButton = confirmation;
            prompt.Show();

            void arkadasEkle(object sender2, EventArgs e2) { kullanicilar kullanici = db.kullanicilar.Where(s => s.kAdi == textBox.Text).FirstOrDefault(); ((Button) sender2).Name = "arkadasEkle_" + (kullanici != null ? kullanici.ID.ToString() : "0"); arkEkle(sender2, e2); prompt.Close(); }
        }

        private void arkEkle(object sender, EventArgs e)
        {
            int arkadasID = Convert.ToInt32(((Button) sender).Name.Split('_')[1]);
            kullanicilar arkadasim = db.kullanicilar.Where(s => s.ID == arkadasID).FirstOrDefault();

            if (arkadasim != null)
            {
                if (MessageBox.Show("\" " + arkadasim.kAdi + " \" kullanıcısına arkadaşlık daveti göndermek istediğinize emin misiniz ?", "Arkadaş Ekle", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    db.arkadasliklar.Add(new arkadasliklar { gonderenID = bilgilerim.ID, alıcıID = arkadasID });
                    if (db.SaveChanges() == 1)
                    {
                        MessageBox.Show(arkadasim.kAdi + " kullanıcısına arkadaşlık daveti başarıyla gönderildi!", "BAŞARILI!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        arkadasGoster(db.arkadasliklar.Where(s => s.gonderenID == bilgilerim.ID && s.alıcıID == arkadasID).FirstOrDefault(), arkadasim);
                    }
                    else MessageBox.Show("Arkadaş ekleme başarısız!", "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else MessageBox.Show("Böyle bir kullanıcı yok!", "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void arkCikar(object sender, EventArgs e)
        {
            int arkadaslikID = Convert.ToInt32(((Button) sender).Name.Split('_')[1]);
            arkadasliklar arkadaslik = db.arkadasliklar.Where(s => s.ID == arkadaslikID).FirstOrDefault();
            kullanicilar arkadasim = arkadaslik.gonderenID == bilgilerim.ID ? arkadaslik.kullanicilar : arkadaslik.kullanicilar1;

            if (MessageBox.Show("\" " + arkadasim.kAdi + " \" kullanıcısını arkadaş listenizden çıkarmak istediğinize emin misiniz ?", "Arkadaş Çıkar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                db.arkadasliklar.Remove(arkadaslik);
                if (db.SaveChanges() == 1)
                {
                    MessageBox.Show(arkadasim.kAdi + " arkadaş listenizden başarıyla çıkarıldı!", "BAŞARILI!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    istekler.Controls.Remove(istekler.Controls.Find("arkadasPanel_" + arkadaslikID, true).FirstOrDefault());
                } else MessageBox.Show("Arkadaş silme başarısız!", "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void arkKabulEt(object sender, EventArgs e)
        {
            int arkadaslikID = Convert.ToInt32(((Button) sender).Name.Split('_')[1]);
            arkadasliklar arkadaslik = db.arkadasliklar.Where(s => s.ID == arkadaslikID).FirstOrDefault();
            kullanicilar arkadasim = arkadaslik.gonderenID == bilgilerim.ID ? arkadaslik.kullanicilar : arkadaslik.kullanicilar1;

            if (MessageBox.Show("\" " + arkadasim.kAdi + " \" kullanıcısını arkadaş listenize eklemek istediğinize emin misiniz ?", "Arkadaş Ekle", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                arkadaslik.arkadaslikDurumu = true;
                if (db.SaveChanges() == 1)
                {
                    MessageBox.Show(arkadasim.kAdi + " arkadaş listenize başarıyla eklendi!", "BAŞARILI!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Control arkadas = istekler.Controls.Find("arkadasPanel_" + arkadaslikID, true).FirstOrDefault(), arkadasCikar = arkadas.Controls.Find("arkadasCikar_" + arkadaslikID, true).FirstOrDefault(), arkadasKabulEt = arkadas.Controls.Find("arkadasKabulEt_" + arkadaslikID, true).FirstOrDefault();
                    int index = arkadas.Controls.IndexOf(arkadasCikar);
                    arkadas.Controls.Remove(arkadasCikar); arkadas.Controls.Remove(arkadasKabulEt);
                    Button fisilti = new Button { Name = "arkadasFisilti_" + arkadaslikID, Text = "Fısıltı!", ForeColor = Color.WhiteSmoke, FlatStyle = FlatStyle.Flat, Dock = DockStyle.Right, BackColor = Color.BlueViolet }; fisilti.Click += fisiltiAc; arkadas.Controls.Add(fisilti); arkadas.Controls.SetChildIndex(fisilti, index);
                    istekler.Controls.Remove(arkadas); arkadaslar.Controls.Add(arkadas);
                } else MessageBox.Show("Arkadaş ekleme başarısız!", "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void arkadasListeGetir_Tick(object sender, EventArgs e)
        {
            arkadaslarGetir();
        }

        private void arkadaslarGetir()
        {
            Control arkadaslarLabel = arkadaslar.Controls.Find("arkadaslarPanel", true).FirstOrDefault(), isteklerLabel = istekler.Controls.Find("isteklerLabel", true).FirstOrDefault();
            arkadaslar.Controls.Clear(); istekler.Controls.Clear(); arkadaslar.Controls.Add(arkadaslarLabel); istekler.Controls.Add(isteklerLabel);

            foreach (arkadasliklar arkadaslik in db.arkadasliklar.Where(s => (s.gonderenID == bilgilerim.ID || s.alıcıID == bilgilerim.ID)).ToList())
            {
                kullanicilar arkadasim = arkadaslik.gonderenID == bilgilerim.ID ? arkadaslik.kullanicilar : arkadaslik.kullanicilar1;
                arkadasGoster(arkadaslik, arkadasim);
            }
        }

        private void arkadasGoster(arkadasliklar arkadaslik, kullanicilar arkadasim)
        {
            Panel arkadas = new Panel() { Name = "arkadasPanel_" + arkadaslik.ID, Size = new Size(240, 96), BorderStyle = BorderStyle.FixedSingle };

                PictureBox arkadasPP = new PictureBox() { Name = "arkadasPP_" + arkadaslik.ID, Size = new Size(64, 64), Image = arkadasim.cinsiyet ? Resources.img_avatar1 : Resources.img_avatar2, SizeMode = PictureBoxSizeMode.Zoom, Dock = DockStyle.Left };
                Label arkadaskAdi = new Label() { Name = "arkadaskAdi_" + arkadaslik.ID, Text = arkadasim.kAdi, ForeColor = Color.WhiteSmoke, Dock = DockStyle.Top };
                PictureBox arkadasRutbeTas = new PictureBox() { Name = "arkadasRutbeTas_" + arkadaslik.ID, Size = new Size(16, 16), SizeMode = PictureBoxSizeMode.Zoom, Dock = DockStyle.Left };
                Label arkadasRutbeAd = new Label() { Name = "arkadasRutbeAd_" + arkadaslik.ID, ForeColor = Color.WhiteSmoke, Dock = DockStyle.Top };

                    rutbeGoster(arkadasim.ELO, arkadasim.cinsiyet, arkadasRutbeTas, arkadasRutbeAd);

                Label arkadasELO = new Label() { Name = "arkadasELO_" + arkadaslik.ID, Text = "ELO: " + arkadasim.ELO, ForeColor = Color.WhiteSmoke, Dock = DockStyle.Top };
                Button fisilti = new Button() { Name = "arkadasFisilti_" + arkadaslik.ID, Text = "Fısıltı!", ForeColor = Color.WhiteSmoke, FlatStyle = FlatStyle.Flat, Dock = DockStyle.Right, BackColor = Color.BlueViolet }; fisilti.Click += fisiltiAc;
                Button arkCikarBTN = new Button() { Name = "arkadasCikar_" + arkadaslik.ID, Text = "Çıkar!", ForeColor = Color.WhiteSmoke, FlatStyle = FlatStyle.Flat, Dock = DockStyle.Right, BackColor = Color.DarkRed }; arkCikarBTN.Click += arkCikar;
                Button arkKabulEtBTN = new Button() { Name = "arkadasKabulEt_" + arkadaslik.ID, Text = "Kabul Et!", ForeColor = Color.WhiteSmoke, FlatStyle = FlatStyle.Flat, Dock = DockStyle.Right, BackColor = Color.DarkGreen }; arkKabulEtBTN.Click += arkKabulEt;

            arkadas.Controls.AddRange(new Control[] { fisilti, arkadasELO, arkadasRutbeAd, arkadasRutbeTas, arkadaskAdi, arkadasPP });

                    if (arkadaslik.arkadaslikDurumu) arkadaslar.Controls.Add(arkadas); // Arkadaş Listesi
            else if (arkadaslik.gonderenID == bilgilerim.ID) { int index = arkadas.Controls.IndexOf(fisilti); arkadas.Controls.Remove(fisilti); arkadas.Controls.Add(arkCikarBTN); arkadas.Controls.SetChildIndex(arkCikarBTN, index); istekler.Controls.Add(arkadas); arkCikarBTN.Text = "İptal Et!"; } // Gönderensem;
                else { int index = arkadas.Controls.IndexOf(fisilti); arkadas.Controls.Remove(fisilti); arkadas.Controls.Add(arkCikarBTN); arkadas.Controls.Add(arkKabulEtBTN); arkadas.Controls.SetChildIndex(arkCikarBTN, index); arkadas.Controls.SetChildIndex(arkKabulEtBTN, index + 1); istekler.Controls.Add(arkadas); arkCikarBTN.Text = "Reddet!"; } // Alıcı isem;
        }

        private void fisiltiAc(object sender, EventArgs e)
        {
            Button fisilti = (Button) sender;
            int arkadaslikID = Convert.ToInt32(fisilti.Name.Split('_')[1]);

              arkadasliklar arkadaslik = db.arkadasliklar.Where(s => s.ID == arkadaslikID).FirstOrDefault();
              kullanicilar arkadasim = arkadaslik.gonderenID == bilgilerim.ID ? arkadaslik.kullanicilar : arkadaslik.kullanicilar1;

                mesaj mesaj = new mesaj() { Name = "mesajForm_" + arkadaslik.ID, arkadasim = arkadasim };

            mesaj.Show();
        }

        private void mesajGetirici_Tick(object sender, EventArgs e) 
        { 
            foreach (mesajlar gelenMesaj in db.mesajlar.Where(s => s.aliciID == bilgilerim.ID && s.ID > sonMesajID).ToList())
            {
                int arkadaslikID = db.arkadasliklar.Where(s => s.gonderenID == gelenMesaj.kullanicilar.ID && s.alıcıID == bilgilerim.ID || s.gonderenID == bilgilerim.ID && s.alıcıID == gelenMesaj.kullanicilar.ID).FirstOrDefault().ID;
                if (Application.OpenForms["mesajForm_" + arkadaslikID] == null)
                {
                    mesaj mesaj = new mesaj() { Name = "mesajForm_" + arkadaslikID, arkadasim = gelenMesaj.kullanicilar };
                    System.Media.SystemSounds.Asterisk.Play();
                    mesaj.Show();
                } sonMesajID = gelenMesaj.ID;
            }
        }

        private void rutbeGoster(int ELO, bool cinsiyet, PictureBox rutbeTas, Label rutbeAd)
        {
            if (ELO > 0 && ELO < 500) { rutbeTas.Image = Resources.cm; rutbeAd.Text = (cinsiyet ? "" : "W") + "CM"; }
            else if (ELO >= 500 && ELO < 1000) { rutbeTas.Image = Resources.fm; rutbeAd.Text = (cinsiyet ? "" : "W") + "FM"; }
            else if (ELO >= 1000 && ELO < 1500) { rutbeTas.Image = Resources.im; rutbeAd.Text = (cinsiyet ? "" : "W") + "IM"; }
            else if (ELO >= 1500) { rutbeTas.Image = Resources.gm; rutbeAd.Text = (cinsiyet ? "" : "W") + "GM"; }
            else { rutbeTas.Image = null; rutbeAd.Text = "UNRANKED!"; }
        }

        private void profilDuzenle_Click(object sender, EventArgs e) { ((Form1) Application.OpenForms["Form1"]).openChildForm(new profilim()); }
    }
}
