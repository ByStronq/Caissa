using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using Caïssa.Models.EntityFramework;
using Caïssa.Controllers;
using System.Linq;
using System.Collections.Generic;

namespace Caïssa
{
    public partial class klasikSatranc : Form
    {
                        /************************* PRIVATES VARIABLES *************************/
            private                          int               odaNo    =   Properties.Settings.Default.odaNo;
            private                         bool             kontrol    =                               false;
            private                         bool    ntsyGetirKontrol    =                               true;
            private                    ArrayList     hamleVePozisyon    =                     new ArrayList();
                        /************************* PRIVATES VARIABLES *************************/
            private int forceSiraNo;
        public klasikSatranc(int forceSira)
        {
            InitializeComponent();
            forceSiraNo = forceSira;
        }

        private void klasikSatranc_Load(object sender, EventArgs e)
        {

            odaNoLabel.Text += odaNo;
            satrancTahtalari odaBilgisi = new SatrancTahtasiController().getir(1, forceSiraNo);

                string odaSahibiAdSoyad = odaBilgisi.kullanicilar.Ad + " " + odaBilgisi.kullanicilar.Soyad, rakipAdSoyad = odaBilgisi.kullanicilar1 != null ? odaBilgisi.kullanicilar1.Ad + " " + odaBilgisi.kullanicilar1.Soyad : null, odaSahibiRutbeAd = "", rakipRutbeAd = "";
                bool odaSahibiCins = odaBilgisi.kullanicilar.cinsiyet, rakipCins = odaBilgisi.kullanicilar1 != null ? odaBilgisi.kullanicilar1.cinsiyet : false;
                Image odaSahibiPP = odaSahibiCins ? Properties.Resources.img_avatar1 : Properties.Resources.img_avatar2, rakipPP = rakipCins ? Properties.Resources.img_avatar1 : odaBilgisi.kullanicilar1 != null ? Properties.Resources.img_avatar2 : Properties.Resources.img_avatar3, odaSahibiRutbeTas = null, rakipRutbeTas = null;
                int odaSahibiELO = odaBilgisi.kullanicilar.ELO, rakipELO = odaBilgisi.kullanicilar1 != null ? odaBilgisi.kullanicilar1.ELO : 0;

                    if (odaSahibiELO > 0 && odaSahibiELO < 500) { odaSahibiRutbeTas = Properties.Resources.cm; odaSahibiRutbeAd = (odaSahibiCins ? "" : "W") + "CM (" + (odaSahibiCins ? "" : "Woman ") + "Candidate Master - " + (odaSahibiCins ? "" : "Kadın ") + "Usta Adayı)"; }
                    else if (odaSahibiELO >= 500 && odaSahibiELO < 1000) { odaSahibiRutbeTas = Properties.Resources.fm; odaSahibiRutbeAd = (odaSahibiCins ? "" : "W") + "FM (" + (odaSahibiCins ? "" : "Woman ") + "FIDE Master - " + (odaSahibiCins ? "" : "Kadın ") + "FIDE Ustası)"; }
                    else if (odaSahibiELO >= 1000 && odaSahibiELO < 1500) { odaSahibiRutbeTas = Properties.Resources.im; odaSahibiRutbeAd = (odaSahibiCins ? "" : "W") + "IM (" + (odaSahibiCins ? "" : "Woman ") + "International Master - " + (odaSahibiCins ? "" : "Kadın ") + "Uluslararası Usta)"; }
                    else if (odaSahibiELO >= 1500) { odaSahibiRutbeTas = Properties.Resources.gm;  odaSahibiRutbeAd = (odaSahibiCins ? "" : "W") + "GM (" + (odaSahibiCins ? "" : "Woman ") + "Grand Master - " + (odaSahibiCins ? "" : "Kadın ") + "Büyük Usta)"; }
                    else { odaSahibiRutbeTas = null; odaSahibiRutbeAd = "UNRANKED!"; }

                        if (rakipELO > 0 && rakipELO < 500) { rakipRutbeTas = Properties.Resources.cm; rakipRutbeAd = (rakipCins ? "" : "W") + "CM (" + (rakipCins ? "" : "Woman ") + "Candidate Master - " + (rakipCins ? "" : "Kadın ") + "Usta Adayı)"; }
                        else if (rakipELO >= 500 && rakipELO < 1000) { rakipRutbeTas = Properties.Resources.fm; rakipRutbeAd = (rakipCins ? "" : "W") + "FM (" + (rakipCins ? "" : "Woman ") + "FIDE Master - " + (rakipCins ? "" : "Kadın ") + "FIDE Ustası)"; }
                        else if (rakipELO >= 1000 && rakipELO < 1500) { rakipRutbeTas = Properties.Resources.im; rakipRutbeAd = (rakipCins ? "" : "W") + "IM (" + (rakipCins ? "" : "Woman ") + "International Master - " + (rakipCins ? "" : "Kadın ") + "Uluslararası Usta)"; }
                        else if (rakipELO >= 1500) { rakipRutbeTas = Properties.Resources.gm; rakipRutbeAd = (rakipCins ? "" : "W") + "GM (" + (rakipCins ? "" : "Woman ") + "Grand Master - " + (rakipCins ? "" : "Kadın ") + "Büyük Usta)"; }
                        else { rakipRutbeTas = null; rakipRutbeAd = "UNRANKED!"; }

            int yer = 0;
            ToolTip Aciklama = new ToolTip();

            profilePhoto1.Click += davetEt; profilePhoto2.Click += davetEt;

            if (new OnlineSatrancEntities().satrancTahtalari.Where(s => s.ID == odaNo).FirstOrDefault().rakip == new Models.bilgilerim().getir().ID)
            {
                adSoyad1.Text = rakipAdSoyad;
                adSoyad2.Text = odaSahibiAdSoyad;

                    profilePhoto1.Image = rakipPP;
                    profilePhoto2.Image = odaSahibiPP;
                    profilePhoto1.Tag = "2";
                    profilePhoto2.Tag = "1";

                odaStatus1.Text = "Konuk";
                odaStatus2.Text = "Oda Sahibi";

                    rutbeTas1.Image = rakipRutbeTas;
                    rutbeTas2.Image = odaSahibiRutbeTas;

                rutbeAd1.Text = rakipRutbeAd;
                rutbeAd2.Text = odaSahibiRutbeAd;

                    elo1.Text = "ELO: " + rakipELO;
                    elo2.Text = "ELO: " + odaSahibiELO;

                        Aciklama.SetToolTip(rutbeAd1, rakipRutbeAd);
                        Aciklama.SetToolTip(rutbeAd2, odaSahibiRutbeAd);

                yer = 1;
                for (int i = 1; i <= 8; i++)
                {
                    for (char j = 'h'; j >= 'a'; j--)
                    {
                        Button btn = new Button();
                        btn.Name = j + "" + i;
                        btn.Size = new Size(60, 60);
                        btn.Margin = Padding.Empty;
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.Click += notasyonOlustur;
                        if (i % 2 == 0)
                        {
                            if (yer == 1)
                            {
                                btn.BackColor = Color.Black;
                                yer = 0;
                            }
                            else
                            {
                                yer++;
                                btn.BackColor = Color.White;
                            }

                            if (i == 2) { btn.BackgroundImage = Properties.Resources.beyazPiyon; btn.Tag = "beyazPiyon"; }
                            else if (i == 8)
                                if (j == 'a' || j == 'h') { btn.BackgroundImage = Properties.Resources.kale; btn.Tag = "kale"; }
                                else if (j == 'b' || j == 'g') { btn.BackgroundImage = Properties.Resources.at; btn.Tag = "at"; }
                                else if (j == 'c' || j == 'f') { btn.BackgroundImage = Properties.Resources.fil; btn.Tag = "fil"; }
                                else if (j == 'd') { btn.BackgroundImage = Properties.Resources.vezir; btn.Tag = "vezir"; }
                                else if (j == 'e') { btn.BackgroundImage = Properties.Resources.sah; btn.Tag = "sah"; }
                        }
                        else
                        {
                            if (yer == 0)
                            {
                                btn.BackColor = Color.Black;
                                yer++;
                            }
                            else
                            {
                                yer = 0;
                                btn.BackColor = Color.White;
                            }

                            if (i == 7) { btn.BackgroundImage = Properties.Resources.piyon; btn.Tag = "piyon"; }
                            else if (i == 1)
                                if (j == 'a' || j == 'h') { btn.BackgroundImage = Properties.Resources.beyazKale; btn.Tag = "beyazKale"; }
                                else if (j == 'b' || j == 'g') { btn.BackgroundImage = Properties.Resources.beyazAt; btn.Tag = "beyazAt"; }
                                else if (j == 'c' || j == 'f') { btn.BackgroundImage = Properties.Resources.beyazFil; btn.Tag = "beyazFil"; }
                                else if (j == 'd') { btn.BackgroundImage = Properties.Resources.beyazVezir; btn.Tag = "beyazVezir"; }
                                else if (j == 'e') { btn.BackgroundImage = Properties.Resources.beyazSah; btn.Tag = "beyazSah"; }
                        }
                        btn.BackgroundImageLayout = ImageLayout.Stretch;
                        satrancTahtasiContainer.Controls.Add(btn);
                    }
                }
            }
            else
            {
                adSoyad1.Text = odaSahibiAdSoyad;
                adSoyad2.Text = rakipAdSoyad;

                    profilePhoto1.Image = odaSahibiPP;
                    profilePhoto2.Image = rakipPP;
                    profilePhoto1.Tag = "1";
                    profilePhoto2.Tag = "2";

                odaStatus1.Text = "Oda Sahibi";
                odaStatus2.Text = "Konuk";

                    rutbeTas1.Image = odaSahibiRutbeTas;
                    rutbeTas2.Image = rakipRutbeTas;

                rutbeAd1.Text = odaSahibiRutbeAd;
                rutbeAd2.Text = rakipRutbeAd;

                    elo1.Text = "ELO: " + odaSahibiELO;
                    elo2.Text = "ELO: " + rakipELO;

                        Aciklama.SetToolTip(rutbeAd1, odaSahibiRutbeAd);
                        Aciklama.SetToolTip(rutbeAd2, rakipRutbeAd);

                for (int i = 8; i >= 1; i--)
                {
                    for (char j = 'a'; j <= 'h'; j++)
                    {
                        Button btn = new Button();
                        btn.Name = j + "" + i;
                        btn.Size = new Size(60, 60);
                        btn.Margin = Padding.Empty;
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.Click += notasyonOlustur;
                        if (i % 2 == 0)
                        {
                            if (yer == 1)
                            {
                                btn.BackColor = Color.Black;
                                yer = 0;
                            }
                            else
                            {
                                yer++;
                                btn.BackColor = Color.White;
                            }

                            if (i == 2) { btn.BackgroundImage = Properties.Resources.beyazPiyon; btn.Tag = "beyazPiyon"; }
                            else if (i == 8)
                                if (j == 'a' || j == 'h') { btn.BackgroundImage = Properties.Resources.kale; btn.Tag = "kale"; }
                                else if (j == 'b' || j == 'g') { btn.BackgroundImage = Properties.Resources.at; btn.Tag = "at"; }
                                else if (j == 'c' || j == 'f') { btn.BackgroundImage = Properties.Resources.fil; btn.Tag = "fil"; }
                                else if (j == 'd') { btn.BackgroundImage = Properties.Resources.vezir; btn.Tag = "vezir"; }
                                else if (j == 'e') { btn.BackgroundImage = Properties.Resources.sah; btn.Tag = "sah"; }
                        }
                        else
                        {
                            if (yer == 0)
                            {
                                btn.BackColor = Color.Black;
                                yer++;
                            }
                            else
                            {
                                yer = 0;
                                btn.BackColor = Color.White;
                            }

                            if (i == 7) { btn.BackgroundImage = Properties.Resources.piyon; btn.Tag = "piyon"; }
                            else if (i == 1)
                                if (j == 'a' || j == 'h') { btn.BackgroundImage = Properties.Resources.beyazKale; btn.Tag = "beyazKale"; }
                                else if (j == 'b' || j == 'g') { btn.BackgroundImage = Properties.Resources.beyazAt; btn.Tag = "beyazAt"; }
                                else if (j == 'c' || j == 'f') { btn.BackgroundImage = Properties.Resources.beyazFil; btn.Tag = "beyazFil"; }
                                else if (j == 'd') { btn.BackgroundImage = Properties.Resources.beyazVezir; btn.Tag = "beyazVezir"; }
                                else if (j == 'e') { btn.BackgroundImage = Properties.Resources.beyazSah; btn.Tag = "beyazSah"; }
                        }
                        btn.BackgroundImageLayout = ImageLayout.Stretch;
                        satrancTahtasiContainer.Controls.Add(btn);
                    }
                }
            }

                List<hamleler> hamleler = new OnlineSatrancEntities().hamleler.Where(s => s.odaNo == odaNo).ToList();

                    foreach(hamleler hamle in hamleler)
                    {
                        Control eskiTas = satrancTahtasiContainer.Controls.Find(hamle.pozisyon, true)[0];
                        Control yeniTas;

                        char[] notasyonParca = hamle.notasyon.ToCharArray();

                            // NOTASYON KONTROL BAŞLANGICI = TAŞIN ESKİ HÜCRESİ => TAŞIN YENİ HÜCRESİ //
                            if (notasyonParca[0] == 'Ş' || notasyonParca[0] == 'V' || notasyonParca[0] == 'F' || notasyonParca[0] == 'A' || notasyonParca[0] == 'K') // Şah, Vezir, Fil, At veya Kale;
                                if (notasyonParca[1] == 'x' || notasyonParca[1] == '+')
                                {
                                    yeniTas = satrancTahtasiContainer.Controls.Find((notasyonParca[2] + "" + notasyonParca[3]), true)[0];   // Bir taşı yiyor veya şah çekiyorsa yeniPozisyonu
                                    //if (notasyonParca[1] == '+') sahCek = true;
                                }
                                else yeniTas = satrancTahtasiContainer.Controls.Find((notasyonParca[1] + "" + notasyonParca[2]), true)[0];       // Yer değiştiriyorsa yeniPozisyonu
                            else        // Taş piyon ise;    
                                if (notasyonParca.Count() >= 3 && (notasyonParca[2] == 'x' || notasyonParca[2] == '+'))
                                {
                                    yeniTas = satrancTahtasiContainer.Controls.Find((notasyonParca[3] + "" + notasyonParca[4]), true)[0];       // Bir taşı yiyor veya şah çekiyorsa yeniPozisyonu
                                    //if (notasyonParca[2] == '+') sahCek = true;
                                }
                                else
                                {
                                    yeniTas = satrancTahtasiContainer.Controls.Find((notasyonParca[0] + "" + notasyonParca[1]), true)[0];       // Yer değiştiriyorsa yeniPozisyonu
                                    //if (notasyonParca.Count() >= 3 && (notasyonParca[2] == 'V' || notasyonParca[2] == 'K')) tasCik = notasyonParca[2];
                                }    // Piyon Vezir veya Kale taşı çıkıyorsa
                            // NOTASYON KONTROL BİTİŞİ = TAŞIN ESKİ HÜCRESİ => TAŞIN YENİ HÜCRESİ //


                            yeniTas.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject(eskiTas.Tag.ToString());
                            yeniTas.Tag = eskiTas.Tag;

                        eskiTas.BackgroundImage = null;
                        eskiTas.Tag = null;
                    }
        }

        private void davetEt(object sender, EventArgs e)
        {
            if (Controls.Find("adSoyad" + ((Control)sender).Name[12], true).OfType<Label>().First().Text == "Rakip Bekleniyor...") // Tıklanan yerde oyuncu yoksa;
            {
                kullanicilar bilgilerim = new Models.bilgilerim().getir();
                OnlineSatrancEntities db = new OnlineSatrancEntities();

                    Form form = new Form();
                
                        foreach (arkadasliklar arkadaslik in db.arkadasliklar.Where(s => (s.gonderenID == bilgilerim.ID || s.alıcıID == bilgilerim.ID) && s.arkadaslikDurumu).ToList()) 
                        {
                            kullanicilar arkadas = arkadaslik.kullanicilar1.ID == bilgilerim.ID ? arkadaslik.kullanicilar : arkadaslik.kullanicilar1;
                            Button davetEtBTN = new Button() { Text = arkadas.kAdi + " Davet Et" }; davetEtBTN.Tag = arkadas.ID; davetEtBTN.Click += davetEt_Click;
                            form.Controls.Add(davetEtBTN);
                        }

                    void davetEt_Click(object sender2, EventArgs e2) 
                    {
                        db.mesajlar.Add(new mesajlar { gonderenID = bilgilerim.ID, aliciID = Convert.ToInt32(((Button) sender2).Tag.ToString()), mesaj = "Oda No: (" + odaNo + ") Sıra No: [" + ((PictureBox)sender).Tag + "] - Klasik Satranç", tarih = DateTime.Now });
                        if (db.SaveChanges() > 0) MessageBox.Show("Davet gönderildi!"); else MessageBox.Show("Davet gönderilemedi!");
                    }

                    form.Show();
            }
            else // Tıklanan yerde oyuncu varsa;
            {
                MessageBox.Show("Zaten biri oynuyor bu yüzden birini davet edemezsin!");
            }
        }

        private void notasyonOlustur(object sender, EventArgs e)
        {
            SatrancTahtasiController controller = new SatrancTahtasiController();
            Button btn = (sender as Button);

            if (!kontrol)
            {
                hamleVePozisyon.Clear();
                hamleVePozisyon.Add(btn.Tag);
                hamleVePozisyon.Add(btn.Name);

                    SatrancTahtasiController.OdaKontrol odaKontrol = controller.odaKontrol(1);

                kontrol = true;

                if (btn.BackgroundImage == null)
                {
                    MessageBox.Show("BASTIĞINIZ HÜCREDE OYNATILACAK BİR TAŞ YOK!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    kontrol = false;
                }
                else if (odaKontrol.odaSahibi && !odaKontrol.odaRakip)
                {
                    if (!btn.Tag.ToString().Contains("beyaz")) // Beyaz taşa basmadıysanız
                    {
                        MessageBox.Show("SİYAH TAŞLARLA OYNAMA YETKİNİZ YOK!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        kontrol = false;
                    }
                    else if (!odaKontrol.hamleSirasi) // Sıra sizde değilse
                    {
                        MessageBox.Show("SIRA SİZDE DEĞİL!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        kontrol = false;
                    }
                }
                else if (!odaKontrol.odaSahibi && odaKontrol.odaRakip)
                {
                    if (btn.Tag.ToString().Contains("beyaz")) // Siyah taşa basmadıysanız
                    {
                        MessageBox.Show("BEYAZ TAŞLARLA OYNAMA YETKİNİZ YOK!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        kontrol = false;
                    }
                    else if (!odaKontrol.hamleSirasi) // Sıra sizde değilse
                    {
                        MessageBox.Show("SIRA SİZDE DEĞİL!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        kontrol = false;
                    }
                }
                else
                {
                    MessageBox.Show("İZLEYİCİ MODDA HAMLE YAPAMAZSINIZ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    kontrol = false;
                }
            }
            else
            {
                hamleVePozisyon.Add(btn.Name);
                string notasyon = null, tasTuru = hamleVePozisyon.ToArray()[0].ToString(), pozisyon = hamleVePozisyon.ToArray()[1].ToString(), yeniPozisyon = hamleVePozisyon.ToArray()[2].ToString(), tasTuru2, yenenTas = "-";

                    if (btn.Tag != null)
                    {
                        tasTuru2 = btn.Tag.ToString();

                                 if (tasTuru2 == "piyon" || tasTuru2 == "beyazPiyon") yenenTas = "";
                            else if (tasTuru2 == "kale" || tasTuru2 == "beyazKale") yenenTas = "K";
                            else if (tasTuru2 == "at" || tasTuru2 == "beyazAt") yenenTas = "A";
                            else if (tasTuru2 == "fil" || tasTuru2 == "beyazFil") yenenTas = "F";
                            else if (tasTuru2 == "sah" || tasTuru2 == "beyazSah") yenenTas = "S";
                            else if (tasTuru2 == "vezir" || tasTuru2 == "beyazVezir") yenenTas = "V";

                                     if (tasTuru == "piyon" || tasTuru == "beyazPiyon") notasyon = pozisyon + "x" + yeniPozisyon;
                                else if (tasTuru == "kale" || tasTuru == "beyazKale") notasyon = "Kx" + yeniPozisyon;
                                else if (tasTuru == "at" || tasTuru == "beyazAt") notasyon = "Ax" + yeniPozisyon;
                                else if (tasTuru == "fil" || tasTuru == "beyazFil") notasyon = "Fx" + yeniPozisyon;
                                else if (tasTuru == "sah" || tasTuru == "beyazSah") notasyon = "Sx" + yeniPozisyon;
                                else if (tasTuru == "vezir" || tasTuru == "beyazVezir") notasyon = "Vx" + yeniPozisyon;
                    }
                    else
                    {
                                if (tasTuru == "piyon" || tasTuru == "beyazPiyon") notasyon = yeniPozisyon;
                        else if (tasTuru == "kale" || tasTuru == "beyazKale") notasyon = "K" + yeniPozisyon;
                        else if (tasTuru == "at" || tasTuru == "beyazAt") notasyon = "A" + yeniPozisyon;
                        else if (tasTuru == "fil" || tasTuru == "beyazFil") notasyon = "F" + yeniPozisyon;
                        else if (tasTuru == "sah" || tasTuru == "beyazSah") notasyon = "S" + yeniPozisyon;
                        else if (tasTuru == "vezir" || tasTuru == "beyazVezir") notasyon = "V" + yeniPozisyon;
                    }

                if (!controller.notasyonGonder(notasyon, pozisyon, yenenTas, 1)) MessageBox.Show(notasyon + " Hatalı");
                else
                {
                    Control eskiTas = satrancTahtasiContainer.Controls.Find(pozisyon, true)[0];
                    
                        btn.Tag = tasTuru;
                        btn.BackgroundImage = (Image) Properties.Resources.ResourceManager.GetObject(btn.Tag.ToString());

                    eskiTas.BackgroundImage = null;
                    eskiTas.Tag = null;
                }

                kontrol = false;
            }
        }

        private void timerShpGetir_Tick(object sender, EventArgs e)
        {
            kullanicilar sahip = new SatrancTahtasiController().sahipGetir();

                if (sahip != null) { Image pp = sahip.cinsiyet ? Properties.Resources.img_avatar1 : Properties.Resources.img_avatar2;

                    if (sahip.ID == new Models.bilgilerim().getir().ID)
                    {
                        adSoyad1.Text = sahip.Ad + " " + sahip.Soyad;
                        profilePhoto1.Image = pp;
                        elo1.Text = "ELO: " + sahip.ELO;

                             if (sahip.ELO > 0 && sahip.ELO < 500) { rutbeTas1.Image = Properties.Resources.cm; rutbeAd1.Text = (sahip.cinsiyet ? "" : "W") + "CM (" + (sahip.cinsiyet ? "" : "Woman ") + "Candidate Master - " + (sahip.cinsiyet ? "" : "Kadın ") + "Usta Adayı)"; }
                        else if (sahip.ELO >= 500 && sahip.ELO < 1000) { rutbeTas1.Image = Properties.Resources.fm; rutbeAd1.Text = (sahip.cinsiyet ? "" : "W") + "FM (" + (sahip.cinsiyet ? "" : "Woman ") + "FIDE Master - " + (sahip.cinsiyet ? "" : "Kadın ") + "FIDE Ustası)"; }
                        else if (sahip.ELO >= 1000 && sahip.ELO < 1500) { rutbeTas1.Image = Properties.Resources.im; rutbeAd1.Text = (sahip.cinsiyet ? "" : "W") + "IM (" + (sahip.cinsiyet ? "" : "Woman ") + "International Master - " + (sahip.cinsiyet ? "" : "Kadın ") + "Uluslararası Usta)"; }
                        else if (sahip.ELO >= 1500) { rutbeTas1.Image = Properties.Resources.gm; rutbeAd1.Text = (sahip.cinsiyet ? "" : "W") + "GM (" + (sahip.cinsiyet ? "" : "Woman ") + "Grand Master - " + (sahip.cinsiyet ? "" : "Kadın ") + "Büyük Usta)"; }
                           else { rutbeTas1.Image = null; rutbeAd1.Text = "UNRANKED!"; }
                    }
                    else
                    {
                        adSoyad2.Text = sahip.Ad + " " + sahip.Soyad;
                        profilePhoto2.Image = pp;
                        elo2.Text = "ELO: " + sahip.ELO;

                             if (sahip.ELO > 0 && sahip.ELO < 500) { rutbeTas2.Image = Properties.Resources.cm; rutbeAd2.Text = (sahip.cinsiyet ? "" : "W") + "CM (" + (sahip.cinsiyet ? "" : "Woman ") + "Candidate Master - " + (sahip.cinsiyet ? "" : "Kadın ") + "Usta Adayı)"; }
                        else if (sahip.ELO >= 500 && sahip.ELO < 1000) { rutbeTas2.Image = Properties.Resources.fm; rutbeAd2.Text = (sahip.cinsiyet ? "" : "W") + "FM (" + (sahip.cinsiyet ? "" : "Woman ") + "FIDE Master - " + (sahip.cinsiyet ? "" : "Kadın ") + "FIDE Ustası)"; }
                        else if (sahip.ELO >= 1000 && sahip.ELO < 1500) { rutbeTas2.Image = Properties.Resources.im; rutbeAd2.Text = (sahip.cinsiyet ? "" : "W") + "IM (" + (sahip.cinsiyet ? "" : "Woman ") + "International Master - " + (sahip.cinsiyet ? "" : "Kadın ") + "Uluslararası Usta)"; }
                        else if (sahip.ELO >= 1500) { rutbeTas2.Image = Properties.Resources.gm; rutbeAd2.Text = (sahip.cinsiyet ? "" : "W") + "GM (" + (sahip.cinsiyet ? "" : "Woman ") + "Grand Master - " + (sahip.cinsiyet ? "" : "Kadın ") + "Büyük Usta)"; }
                           else { rutbeTas2.Image = null; rutbeAd2.Text = "UNRANKED!"; }
                    }

                    satrancTahtasiContainer.Enabled = true;
                } else {
                    adSoyad2.Text = "Rakip Bekleniyor...";
                    satrancTahtasiContainer.Enabled = false;
                }
        }

        private void timerRkpGetir_Tick(object sender, EventArgs e)
        {
            kullanicilar rakip = new SatrancTahtasiController().rakipGetir();

                if (rakip != null) { Image pp = rakip.cinsiyet ? Properties.Resources.img_avatar1 : Properties.Resources.img_avatar2;

                    if (rakip.ID == new Models.bilgilerim().getir().ID)
                    {
                        adSoyad1.Text = rakip.Ad + " " + rakip.Soyad;
                        profilePhoto1.Image = pp;
                        elo1.Text = "ELO: " + rakip.ELO;

                             if (rakip.ELO > 0 && rakip.ELO < 500) { rutbeTas1.Image = Properties.Resources.cm; rutbeAd1.Text = (rakip.cinsiyet ? "" : "W") + "CM (" + (rakip.cinsiyet ? "" : "Woman ") + "Candidate Master - " + (rakip.cinsiyet ? "" : "Kadın ") + "Usta Adayı)"; }
                        else if (rakip.ELO >= 500 && rakip.ELO < 1000) { rutbeTas1.Image = Properties.Resources.fm; rutbeAd1.Text = (rakip.cinsiyet ? "" : "W") + "FM (" + (rakip.cinsiyet ? "" : "Woman ") + "FIDE Master - " + (rakip.cinsiyet ? "" : "Kadın ") + "FIDE Ustası)"; }
                        else if (rakip.ELO >= 1000 && rakip.ELO < 1500) { rutbeTas1.Image = Properties.Resources.im; rutbeAd1.Text = (rakip.cinsiyet ? "" : "W") + "IM (" + (rakip.cinsiyet ? "" : "Woman ") + "International Master - " + (rakip.cinsiyet ? "" : "Kadın ") + "Uluslararası Usta)"; }
                        else if (rakip.ELO >= 1500) { rutbeTas1.Image = Properties.Resources.gm; rutbeAd1.Text = (rakip.cinsiyet ? "" : "W") + "GM (" + (rakip.cinsiyet ? "" : "Woman ") + "Grand Master - " + (rakip.cinsiyet ? "" : "Kadın ") + "Büyük Usta)"; }
                           else { rutbeTas1.Image = null; rutbeAd1.Text = "UNRANKED!"; }
                    }
                    else
                    {
                        adSoyad2.Text = rakip.Ad + " " + rakip.Soyad;
                        profilePhoto2.Image = pp;
                        elo2.Text = "ELO: " + rakip.ELO;

                             if (rakip.ELO > 0 && rakip.ELO < 500) { rutbeTas2.Image = Properties.Resources.cm; rutbeAd2.Text = (rakip.cinsiyet ? "" : "W") + "CM (" + (rakip.cinsiyet ? "" : "Woman ") + "Candidate Master - " + (rakip.cinsiyet ? "" : "Kadın ") + "Usta Adayı)"; }
                        else if (rakip.ELO >= 500 && rakip.ELO < 1000) { rutbeTas2.Image = Properties.Resources.fm; rutbeAd2.Text = (rakip.cinsiyet ? "" : "W") + "FM (" + (rakip.cinsiyet ? "" : "Woman ") + "FIDE Master - " + (rakip.cinsiyet ? "" : "Kadın ") + "FIDE Ustası)"; }
                        else if (rakip.ELO >= 1000 && rakip.ELO < 1500) { rutbeTas2.Image = Properties.Resources.im; rutbeAd2.Text = (rakip.cinsiyet ? "" : "W") + "IM (" + (rakip.cinsiyet ? "" : "Woman ") + "International Master - " + (rakip.cinsiyet ? "" : "Kadın ") + "Uluslararası Usta)"; }
                        else if (rakip.ELO >= 1500) { rutbeTas2.Image = Properties.Resources.gm; rutbeAd2.Text = (rakip.cinsiyet ? "" : "W") + "GM (" + (rakip.cinsiyet ? "" : "Woman ") + "Grand Master - " + (rakip.cinsiyet ? "" : "Kadın ") + "Büyük Usta)"; }
                           else { rutbeTas2.Image = null; rutbeAd2.Text = "UNRANKED!"; }
                    }

                    satrancTahtasiContainer.Enabled = true;
                } else {
                    adSoyad2.Text = "Rakip Bekleniyor...";
                    satrancTahtasiContainer.Enabled = false;
                }
        }

        private void timerNtsynGetir_Tick(object sender, EventArgs e)
        {
            SatrancTahtasiController controller = new SatrancTahtasiController();
            SatrancTahtasiController.OdaKontrol odaKontrol = controller.odaKontrol(1);

            if (odaKontrol.odaSahibi && odaKontrol.rakipHamle || odaKontrol.odaRakip && odaKontrol.sahipHamle)
            {
                if (ntsyGetirKontrol)
                {
                    Models.satrancAlgoritmasi.NotasyonGetir hamleBilgisi = controller.notasyonGetir();

                    if (hamleBilgisi != null)
                    {
                        Control eskiTas = satrancTahtasiContainer.Controls.Find(hamleBilgisi.eskiPozisyon, true)[0];
                        Control yeniTas = satrancTahtasiContainer.Controls.Find(hamleBilgisi.yeniPozisyon, true)[0];

                        if (eskiTas.BackgroundImage != null && eskiTas.Tag != null)
                        {
                            yeniTas.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject(eskiTas.Tag.ToString());
                            yeniTas.Tag = eskiTas.Tag;
                        }

                        eskiTas.BackgroundImage = null;
                        eskiTas.Tag = null;
                    }
                    ntsyGetirKontrol = false;
                }
            } else ntsyGetirKontrol =  true;

        }
    }
}
