using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using Caïssa.Models.EntityFramework;
using Caïssa.Controllers;
using System.Linq;
using System.Collections.Generic;
using Caïssa.Models;

namespace Caïssa
{
    public partial class dortluSatranc : Form
    {
        /************************* PRIVATES VARIABLES *************************/
        private int odaNo = Properties.Settings.Default.odaNo;
        private bool kontrol = false;
        private bool rokKontrol = false;
        //private bool ntsyGetirKontrol = true;
        private ArrayList hamleVePozisyon = new ArrayList();
        private int forceSiraNo;
        /************************* PRIVATES VARIABLES *************************/
        public dortluSatranc(int forceSira)
        {
            InitializeComponent();
            forceSiraNo = forceSira;
        }

        private void dortluSatranc_Load(object sender, EventArgs e)
        {

            odaNoLabel.Text += odaNo;
            satrancTahtalari odaBilgisi = new SatrancTahtasiController().getir(2, forceSiraNo);

            string odaSahibiAdSoyad = odaBilgisi.kullanicilar.Ad + " " + odaBilgisi.kullanicilar.Soyad, rakipAdSoyad = odaBilgisi.kullanicilar1 != null ? odaBilgisi.kullanicilar1.Ad + " " + odaBilgisi.kullanicilar1.Soyad : null,
                   rakip2AdSoyad = odaBilgisi.kullanicilar2 != null ? odaBilgisi.kullanicilar2.Ad + " " + odaBilgisi.kullanicilar2.Soyad : null, rakip3AdSoyad = odaBilgisi.kullanicilar3 != null ? odaBilgisi.kullanicilar3.Ad + " " + odaBilgisi.kullanicilar3.Soyad : null;
            bool odaSahibiCins = odaBilgisi.kullanicilar.cinsiyet, rakipCins = odaBilgisi.kullanicilar1 != null ? odaBilgisi.kullanicilar1.cinsiyet : false, rakip2Cins = odaBilgisi.kullanicilar2 != null ? odaBilgisi.kullanicilar2.cinsiyet : false, rakip3Cins = odaBilgisi.kullanicilar3 != null ? odaBilgisi.kullanicilar3.cinsiyet : false;
            Image odaSahibiPP = odaSahibiCins ? Properties.Resources.img_avatar1 : Properties.Resources.img_avatar2, rakipPP = rakipCins ? Properties.Resources.img_avatar1 : odaBilgisi.kullanicilar1 != null ? Properties.Resources.img_avatar2 : Properties.Resources.img_avatar3,
                  rakip2PP = rakip2Cins ? Properties.Resources.img_avatar1 : odaBilgisi.kullanicilar2 != null ? Properties.Resources.img_avatar2 : Properties.Resources.img_avatar3, rakip3PP = rakip3Cins ? Properties.Resources.img_avatar1 : odaBilgisi.kullanicilar3 != null ? Properties.Resources.img_avatar2 : Properties.Resources.img_avatar3;
            int odaSahibiELO = odaBilgisi.kullanicilar.ELO, rakipELO = odaBilgisi.kullanicilar1 != null ? odaBilgisi.kullanicilar1.ELO : 0, rakip2ELO = odaBilgisi.kullanicilar2 != null ? odaBilgisi.kullanicilar2.ELO : 0, rakip3ELO = odaBilgisi.kullanicilar3 != null ? odaBilgisi.kullanicilar3.ELO : 0;

            ToolTip Aciklama = new ToolTip();

            profilePhoto1.Click += davetEt; profilePhoto2.Click += davetEt; profilePhoto3.Click += davetEt; profilePhoto4.Click += davetEt;

            if (new OnlineSatrancEntities().satrancTahtalari.Where(s => s.ID == odaNo).FirstOrDefault().rakip == new Models.bilgilerim().getir().ID)
            {
                adSoyad1.Text = rakipAdSoyad; adSoyad2.Text = odaSahibiAdSoyad; adSoyad3.Text = rakip3AdSoyad; adSoyad4.Text = rakip2AdSoyad;
                    profilePhoto1.Image = rakipPP; profilePhoto2.Image = odaSahibiPP; profilePhoto3.Image = rakip3PP; profilePhoto4.Image = rakip2PP;
                    profilePhoto1.Tag = "2"; profilePhoto2.Tag = "1"; profilePhoto3.Tag = "4"; profilePhoto4.Tag = "3";
                odaStatus1.Text = "Konuk"; odaStatus2.Text = "Oda Sahibi"; odaStatus3.Text = "Konuk3"; odaStatus4.Text = "Konuk2";
                    rutbeGoster(rakipELO, rakipCins, rutbeTas1, rutbeAd1); rutbeGoster(odaSahibiELO, odaSahibiCins, rutbeTas2, rutbeAd2); rutbeGoster(rakip3ELO, rakip3Cins, rutbeTas3, rutbeAd3); rutbeGoster(rakip2ELO, rakip2Cins, rutbeTas4, rutbeAd4);
                elo1.Text = "ELO: " + rakipELO; elo2.Text = "ELO: " + odaSahibiELO; elo3.Text = "ELO: " + rakip3ELO; elo4.Text = "ELO: " + rakip2ELO;

                        Aciklama.SetToolTip(rutbeAd1, rutbeAd1.Text); Aciklama.SetToolTip(rutbeAd2, rutbeAd2.Text); Aciklama.SetToolTip(rutbeAd3, rutbeAd3.Text); Aciklama.SetToolTip(rutbeAd4, rutbeAd4.Text);

                for (int i = 1; i <= 8; i++) for (char j = 'h'; j >= 'a'; j--)
                {
                    Button btn = hucreOlustur(j, i);

                        if (i % 2 == 0) { if (j == 'b' || j == 'd' || j == 'f' || j == 'h') btn.BackColor = Color.LightSlateGray; else btn.BackColor = Color.White; } else { if (j == 'a' || j == 'c' || j == 'e' || j == 'g')  btn.BackColor = Color.LightSlateGray; else btn.BackColor = Color.White; }

                    satrancTahtasiContainer.Controls.Add(btn);
                }

                for (int i = 1; i <= 3; i++) for (char j = 'p'; j >= 'i'; j--)
                {
                    Button btn = hucreOlustur(j, i);
                    if (i % 2 == 0) { if (j == 'i' || j == 'k' || j == 'm' || j == 'o') btn.BackColor = Color.LightSlateGray; else btn.BackColor = Color.White;

                        if (i == 2) { btn.BackgroundImage = Properties.Resources.kirmiziPiyon; btn.Tag = "kirmiziPiyon"; }
                    }
                    else { if (j == 'j' || j == 'l' || j == 'n' || j == 'p')  btn.BackColor = Color.LightSlateGray; else btn.BackColor = Color.White;

                        if (i == 1)
                            if (j == 'i' || j == 'p') { btn.BackgroundImage = Properties.Resources.kirmiziKale; btn.Tag = "kirmiziKale"; }
                            else if (j == 'j' || j == 'o') { btn.BackgroundImage = Properties.Resources.kirmiziAt; btn.Tag = "kirmiziAt"; }
                            else if (j == 'k' || j == 'n') { btn.BackgroundImage = Properties.Resources.kirmiziFil; btn.Tag = "kirmiziFil"; }
                            else if (j == 'l') { btn.BackgroundImage = Properties.Resources.kirmiziVezir; btn.Tag = "kirmiziVezir"; }
                            else if (j == 'm') { btn.BackgroundImage = Properties.Resources.kirmiziSah; btn.Tag = "kirmiziSah"; }
                    }
                    rakipContainer.Controls.Add(btn);
                }

                for (int i = 4; i <= 6; i++) for (char j = 'p'; j >= 'i'; j--)
                {
                    Button btn = hucreOlustur(j, i);
                    if (i % 2 == 0) { if (j == 'i' || j == 'k' || j == 'm' || j == 'o') btn.BackColor = Color.LightSlateGray; else btn.BackColor = Color.White;

                        if (i == 6)
                            if (j == 'i' || j == 'p') { btn.BackgroundImage = Properties.Resources.turuncuKale; btn.Tag = "turuncuKale"; }
                            else if (j == 'j' || j == 'o') { btn.BackgroundImage = Properties.Resources.turuncuAt; btn.Tag = "turuncuAt"; }
                            else if (j == 'k' || j == 'n') { btn.BackgroundImage = Properties.Resources.turuncuFil; btn.Tag = "turuncuFil"; }
                            else if (j == 'l') { btn.BackgroundImage = Properties.Resources.turuncuVezir; btn.Tag = "turuncuVezir"; }
                            else if (j == 'm') { btn.BackgroundImage = Properties.Resources.turuncuSah; btn.Tag = "turuncuSah"; }
                    }
                    else { if (j == 'j' || j == 'l' || j == 'n' || j == 'p')  btn.BackColor = Color.LightSlateGray; else btn.BackColor = Color.White;

                        if (i == 5) { btn.BackgroundImage = Properties.Resources.turuncuPiyon; btn.Tag = "turuncuPiyon"; }
                    }
                    odaSahibiContainer.Controls.Add(btn);
                }

                for (char j = 'x'; j >= 'q'; j--) for (int i = 3; i >= 1; i--)
                {
                    Button btn = hucreOlustur(j, i);
                    if (i % 2 == 0) { if (j == 'r' || j == 't' || j == 'v' || j == 'x') btn.BackColor = Color.LightSlateGray; else btn.BackColor = Color.White;

                        if (i == 2) { btn.BackgroundImage = Properties.Resources.maviPiyon; btn.Tag = "maviPiyon"; }
                    }
                    else { if (j == 'q' || j == 's' || j == 'u' || j == 'w') btn.BackColor = Color.LightSlateGray; else btn.BackColor = Color.White;

                        if (i == 1)
                            if (j == 'q' || j == 'x') { btn.BackgroundImage = Properties.Resources.maviKale; btn.Tag = "maviKale"; }
                            else if (j == 'r' || j == 'w') { btn.BackgroundImage = Properties.Resources.maviAt; btn.Tag = "maviAt"; }
                            else if (j == 's' || j == 'v') { btn.BackgroundImage = Properties.Resources.maviFil; btn.Tag = "maviFil"; }
                            else if (j == 't') { btn.BackgroundImage = Properties.Resources.maviVezir; btn.Tag = "maviVezir"; }
                            else if (j == 'u') { btn.BackgroundImage = Properties.Resources.maviSah; btn.Tag = "maviSah"; }
                    }
                    rakip3Container.Controls.Add(btn);
                }

                for (char j = 'x'; j >= 'q'; j--) for (int i = 6; i >= 4; i--)
                {
                    Button btn = hucreOlustur(j, i);
                    if (i % 2 == 0) {  if (j == 'r' || j == 't' || j == 'v' || j == 'x') btn.BackColor = Color.LightSlateGray; else btn.BackColor = Color.White;

                        if (i == 6)
                            if (j == 'q' || j == 'x') { btn.BackgroundImage = Properties.Resources.yesilKale; btn.Tag = "yesilKale"; }
                            else if (j == 'r' || j == 'w') { btn.BackgroundImage = Properties.Resources.yesilAt; btn.Tag = "yesilAt"; }
                            else if (j == 's' || j == 'v') { btn.BackgroundImage = Properties.Resources.yesilFil; btn.Tag = "yesilFil"; }
                            else if (j == 't') { btn.BackgroundImage = Properties.Resources.yesilVezir; btn.Tag = "yesilVezir"; }
                            else if (j == 'u') { btn.BackgroundImage = Properties.Resources.yesilSah; btn.Tag = "yesilSah"; }
                    }
                    else { if (j == 'q' || j == 's' || j == 'u' || j == 'w') btn.BackColor = Color.LightSlateGray; else btn.BackColor = Color.White;

                        if (i == 5) { btn.BackgroundImage = Properties.Resources.yesilPiyon; btn.Tag = "yesilPiyon"; }
                    }
                    rakip2Container.Controls.Add(btn);
                }
            }
            else if (new OnlineSatrancEntities().satrancTahtalari.Where(s => s.ID == odaNo).FirstOrDefault().rakip2 == new Models.bilgilerim().getir().ID)
            {
                adSoyad1.Text = rakip2AdSoyad; adSoyad2.Text = rakip3AdSoyad; adSoyad3.Text = rakipAdSoyad; adSoyad4.Text = odaSahibiAdSoyad;
                    profilePhoto1.Image = rakip2PP; profilePhoto2.Image = rakip3PP; profilePhoto3.Image = rakipPP; profilePhoto4.Image = odaSahibiPP;
                    profilePhoto1.Tag = "3"; profilePhoto2.Tag = "4"; profilePhoto3.Tag = "2"; profilePhoto4.Tag = "1";
                odaStatus1.Text = "Konuk2"; odaStatus2.Text = "Konuk3"; odaStatus3.Text = "Konuk"; odaStatus4.Text = "Oda Sahibi";
                    rutbeGoster(rakip2ELO, rakip2Cins, rutbeTas1, rutbeAd1); rutbeGoster(rakip3ELO, rakip3Cins, rutbeTas2, rutbeAd2); rutbeGoster(rakipELO, rakipCins, rutbeTas3, rutbeAd3); rutbeGoster(odaSahibiELO, odaSahibiCins, rutbeTas4, rutbeAd4);
                elo1.Text = "ELO: " + rakip2ELO; elo2.Text = "ELO: " + rakip3ELO; elo3.Text = "ELO: " + rakipELO; elo4.Text = "ELO: " + odaSahibiELO;

                        Aciklama.SetToolTip(rutbeAd1, rutbeAd1.Text); Aciklama.SetToolTip(rutbeAd2, rutbeAd2.Text); Aciklama.SetToolTip(rutbeAd3, rutbeAd3.Text); Aciklama.SetToolTip(rutbeAd4, rutbeAd4.Text);

                for (char j = 'h'; j >= 'a'; j--) for (int i = 8; i >= 1; i--)
                {
                    Button btn = hucreOlustur(j, i);

                        if (i % 2 == 0) { if (j == 'b' || j == 'd' || j == 'f' || j == 'h') btn.BackColor = Color.LightSlateGray; else btn.BackColor = Color.White; } else { if (j == 'a' || j == 'c' || j == 'e' || j == 'g')  btn.BackColor = Color.LightSlateGray; else btn.BackColor = Color.White; }

                    satrancTahtasiContainer.Controls.Add(btn);
                }

                for (char j = 'p'; j >= 'i'; j--) for (int i = 3; i >= 1; i--)
                {
                    Button btn = hucreOlustur(j, i);
                    if (i % 2 == 0) { if (j == 'i' || j == 'k' || j == 'm' || j == 'o') btn.BackColor = Color.LightSlateGray; else btn.BackColor = Color.White;

                        if (i == 2) { btn.BackgroundImage = Properties.Resources.kirmiziPiyon; btn.Tag = "kirmiziPiyon"; }
                    }
                    else { if (j == 'j' || j == 'l' || j == 'n' || j == 'p')  btn.BackColor = Color.LightSlateGray; else btn.BackColor = Color.White;

                        if (i == 1)
                            if (j == 'i' || j == 'p') { btn.BackgroundImage = Properties.Resources.kirmiziKale; btn.Tag = "kirmiziKale"; }
                            else if (j == 'j' || j == 'o') { btn.BackgroundImage = Properties.Resources.kirmiziAt; btn.Tag = "kirmiziAt"; }
                            else if (j == 'k' || j == 'n') { btn.BackgroundImage = Properties.Resources.kirmiziFil; btn.Tag = "kirmiziFil"; }
                            else if (j == 'l') { btn.BackgroundImage = Properties.Resources.kirmiziVezir; btn.Tag = "kirmiziVezir"; }
                            else if (j == 'm') { btn.BackgroundImage = Properties.Resources.kirmiziSah; btn.Tag = "kirmiziSah"; }
                    }
                    rakip3Container.Controls.Add(btn);
                }

                for (char j = 'p'; j >= 'i'; j--) for (int i = 6; i >= 4; i--)
                {
                    Button btn = hucreOlustur(j, i);
                    if (i % 2 == 0) { if (j == 'i' || j == 'k' || j == 'm' || j == 'o') btn.BackColor = Color.LightSlateGray; else btn.BackColor = Color.White;

                        if (i == 6)
                            if (j == 'i' || j == 'p') { btn.BackgroundImage = Properties.Resources.turuncuKale; btn.Tag = "turuncuKale"; }
                            else if (j == 'j' || j == 'o') { btn.BackgroundImage = Properties.Resources.turuncuAt; btn.Tag = "turuncuAt"; }
                            else if (j == 'k' || j == 'n') { btn.BackgroundImage = Properties.Resources.turuncuFil; btn.Tag = "turuncuFil"; }
                            else if (j == 'l') { btn.BackgroundImage = Properties.Resources.turuncuVezir; btn.Tag = "turuncuVezir"; }
                            else if (j == 'm') { btn.BackgroundImage = Properties.Resources.turuncuSah; btn.Tag = "turuncuSah"; }
                    }
                    else { if (j == 'j' || j == 'l' || j == 'n' || j == 'p')  btn.BackColor = Color.LightSlateGray; else btn.BackColor = Color.White;

                        if (i == 5) { btn.BackgroundImage = Properties.Resources.turuncuPiyon; btn.Tag = "turuncuPiyon"; }
                    }
                    rakip2Container.Controls.Add(btn);
                }

                for (int i = 3; i >= 1; i--) for (char j = 'q'; j <= 'x'; j++)
                {
                    Button btn = hucreOlustur(j, i);
                    if (i % 2 == 0) { if (j == 'r' || j == 't' || j == 'v' || j == 'x') btn.BackColor = Color.LightSlateGray; else btn.BackColor = Color.White;

                        if (i == 2) { btn.BackgroundImage = Properties.Resources.maviPiyon; btn.Tag = "maviPiyon"; }
                    }
                    else { if (j == 'q' || j == 's' || j == 'u' || j == 'w') btn.BackColor = Color.LightSlateGray; else btn.BackColor = Color.White;

                        if (i == 1)
                            if (j == 'q' || j == 'x') { btn.BackgroundImage = Properties.Resources.maviKale; btn.Tag = "maviKale"; }
                            else if (j == 'r' || j == 'w') { btn.BackgroundImage = Properties.Resources.maviAt; btn.Tag = "maviAt"; }
                            else if (j == 's' || j == 'v') { btn.BackgroundImage = Properties.Resources.maviFil; btn.Tag = "maviFil"; }
                            else if (j == 't') { btn.BackgroundImage = Properties.Resources.maviVezir; btn.Tag = "maviVezir"; }
                            else if (j == 'u') { btn.BackgroundImage = Properties.Resources.maviSah; btn.Tag = "maviSah"; }
                    }
                    odaSahibiContainer.Controls.Add(btn);
                }

                for (int i = 6; i >= 4; i--) for (char j = 'q'; j <= 'x'; j++)
                {
                    Button btn = hucreOlustur(j, i);
                    if (i % 2 == 0) {  if (j == 'r' || j == 't' || j == 'v' || j == 'x') btn.BackColor = Color.LightSlateGray; else btn.BackColor = Color.White;

                        if (i == 6)
                            if (j == 'q' || j == 'x') { btn.BackgroundImage = Properties.Resources.yesilKale; btn.Tag = "yesilKale"; }
                            else if (j == 'r' || j == 'w') { btn.BackgroundImage = Properties.Resources.yesilAt; btn.Tag = "yesilAt"; }
                            else if (j == 's' || j == 'v') { btn.BackgroundImage = Properties.Resources.yesilFil; btn.Tag = "yesilFil"; }
                            else if (j == 't') { btn.BackgroundImage = Properties.Resources.yesilVezir; btn.Tag = "yesilVezir"; }
                            else if (j == 'u') { btn.BackgroundImage = Properties.Resources.yesilSah; btn.Tag = "yesilSah"; }
                    }
                    else { if (j == 'q' || j == 's' || j == 'u' || j == 'w') btn.BackColor = Color.LightSlateGray; else btn.BackColor = Color.White;

                        if (i == 5) { btn.BackgroundImage = Properties.Resources.yesilPiyon; btn.Tag = "yesilPiyon"; }
                    }
                    rakipContainer.Controls.Add(btn);
                }
            }
            else if (new OnlineSatrancEntities().satrancTahtalari.Where(s => s.ID == odaNo).FirstOrDefault().rakip3 == new Models.bilgilerim().getir().ID)
            {
                adSoyad1.Text = rakip3AdSoyad; adSoyad2.Text = rakip2AdSoyad;  adSoyad3.Text = odaSahibiAdSoyad;  adSoyad4.Text = rakipAdSoyad; 
                    profilePhoto1.Image = rakip3PP; profilePhoto2.Image = rakip2PP; profilePhoto3.Image = odaSahibiPP; profilePhoto4.Image = rakipPP;
                    profilePhoto1.Tag = "4"; profilePhoto2.Tag = "3"; profilePhoto3.Tag = "1"; profilePhoto4.Tag = "2";
                odaStatus1.Text = "Konuk3"; odaStatus2.Text = "Konuk2";  odaStatus3.Text = "Oda Sahibi";  odaStatus4.Text = "Konuk"; 
                    rutbeGoster(rakip3ELO, rakip3Cins, rutbeTas1, rutbeAd1); rutbeGoster(rakip2ELO, rakip2Cins, rutbeTas2, rutbeAd2); rutbeGoster(odaSahibiELO, odaSahibiCins, rutbeTas3, rutbeAd3); rutbeGoster(rakipELO, rakipCins, rutbeTas4, rutbeAd4);
                elo1.Text = "ELO: " + rakip3ELO; elo2.Text = "ELO: " + rakip2ELO; elo3.Text = "ELO: " + odaSahibiELO; elo4.Text = "ELO: " + rakipELO;

                        Aciklama.SetToolTip(rutbeAd1, rutbeAd1.Text); Aciklama.SetToolTip(rutbeAd2, rutbeAd2.Text); Aciklama.SetToolTip(rutbeAd3, rutbeAd3.Text); Aciklama.SetToolTip(rutbeAd4, rutbeAd4.Text);

                for (char j = 'a'; j <= 'h'; j++) for (int i = 1; i <= 8; i++)
                {
                    Button btn = hucreOlustur(j, i);

                        if (i % 2 == 0) { if (j == 'b' || j == 'd' || j == 'f' || j == 'h') btn.BackColor = Color.LightSlateGray; else btn.BackColor = Color.White; } else { if (j == 'a' || j == 'c' || j == 'e' || j == 'g')  btn.BackColor = Color.LightSlateGray; else btn.BackColor = Color.White; }

                    satrancTahtasiContainer.Controls.Add(btn);
                }

                for (char j = 'i'; j <= 'p'; j++) for (int i = 1; i <= 3; i++)
                {
                    Button btn = hucreOlustur(j, i);
                    if (i % 2 == 0) { if (j == 'i' || j == 'k' || j == 'm' || j == 'o') btn.BackColor = Color.LightSlateGray; else btn.BackColor = Color.White;

                        if (i == 2) { btn.BackgroundImage = Properties.Resources.kirmiziPiyon; btn.Tag = "kirmiziPiyon"; }
                    }
                    else { if (j == 'j' || j == 'l' || j == 'n' || j == 'p')  btn.BackColor = Color.LightSlateGray; else btn.BackColor = Color.White;

                        if (i == 1)
                            if (j == 'i' || j == 'p') { btn.BackgroundImage = Properties.Resources.kirmiziKale; btn.Tag = "kirmiziKale"; }
                            else if (j == 'j' || j == 'o') { btn.BackgroundImage = Properties.Resources.kirmiziAt; btn.Tag = "kirmiziAt"; }
                            else if (j == 'k' || j == 'n') { btn.BackgroundImage = Properties.Resources.kirmiziFil; btn.Tag = "kirmiziFil"; }
                            else if (j == 'l') { btn.BackgroundImage = Properties.Resources.kirmiziVezir; btn.Tag = "kirmiziVezir"; }
                            else if (j == 'm') { btn.BackgroundImage = Properties.Resources.kirmiziSah; btn.Tag = "kirmiziSah"; }
                    }
                    rakip2Container.Controls.Add(btn);
                }

                for (char j = 'i'; j <= 'p'; j++) for (int i = 4; i <= 6; i++)
                {
                    Button btn = hucreOlustur(j, i);
                    if (i % 2 == 0) { if (j == 'i' || j == 'k' || j == 'm' || j == 'o') btn.BackColor = Color.LightSlateGray; else btn.BackColor = Color.White;

                        if (i == 6)
                            if (j == 'i' || j == 'p') { btn.BackgroundImage = Properties.Resources.turuncuKale; btn.Tag = "turuncuKale"; }
                            else if (j == 'j' || j == 'o') { btn.BackgroundImage = Properties.Resources.turuncuAt; btn.Tag = "turuncuAt"; }
                            else if (j == 'k' || j == 'n') { btn.BackgroundImage = Properties.Resources.turuncuFil; btn.Tag = "turuncuFil"; }
                            else if (j == 'l') { btn.BackgroundImage = Properties.Resources.turuncuVezir; btn.Tag = "turuncuVezir"; }
                            else if (j == 'm') { btn.BackgroundImage = Properties.Resources.turuncuSah; btn.Tag = "turuncuSah"; }
                    }
                    else { if (j == 'j' || j == 'l' || j == 'n' || j == 'p')  btn.BackColor = Color.LightSlateGray; else btn.BackColor = Color.White;

                        if (i == 5) { btn.BackgroundImage = Properties.Resources.turuncuPiyon; btn.Tag = "turuncuPiyon"; }
                    }
                    rakip3Container.Controls.Add(btn);
                }

                for (int i = 1; i <= 3; i++) for (char j = 'x'; j >= 'q'; j--)
                {
                    Button btn = hucreOlustur(j, i);
                    if (i % 2 == 0) { if (j == 'r' || j == 't' || j == 'v' || j == 'x') btn.BackColor = Color.LightSlateGray; else btn.BackColor = Color.White;

                        if (i == 2) { btn.BackgroundImage = Properties.Resources.maviPiyon; btn.Tag = "maviPiyon"; }
                    }
                    else { if (j == 'q' || j == 's' || j == 'u' || j == 'w') btn.BackColor = Color.LightSlateGray; else btn.BackColor = Color.White;

                        if (i == 1)
                            if (j == 'q' || j == 'x') { btn.BackgroundImage = Properties.Resources.maviKale; btn.Tag = "maviKale"; }
                            else if (j == 'r' || j == 'w') { btn.BackgroundImage = Properties.Resources.maviAt; btn.Tag = "maviAt"; }
                            else if (j == 's' || j == 'v') { btn.BackgroundImage = Properties.Resources.maviFil; btn.Tag = "maviFil"; }
                            else if (j == 't') { btn.BackgroundImage = Properties.Resources.maviVezir; btn.Tag = "maviVezir"; }
                            else if (j == 'u') { btn.BackgroundImage = Properties.Resources.maviSah; btn.Tag = "maviSah"; }
                    }
                    rakipContainer.Controls.Add(btn);
                }

                for (int i = 4; i <= 6; i++) for (char j = 'x'; j >= 'q'; j--)
                {
                    Button btn = hucreOlustur(j, i);
                    if (i % 2 == 0) {  if (j == 'r' || j == 't' || j == 'v' || j == 'x') btn.BackColor = Color.LightSlateGray; else btn.BackColor = Color.White;

                        if (i == 6)
                            if (j == 'q' || j == 'x') { btn.BackgroundImage = Properties.Resources.yesilKale; btn.Tag = "yesilKale"; }
                            else if (j == 'r' || j == 'w') { btn.BackgroundImage = Properties.Resources.yesilAt; btn.Tag = "yesilAt"; }
                            else if (j == 's' || j == 'v') { btn.BackgroundImage = Properties.Resources.yesilFil; btn.Tag = "yesilFil"; }
                            else if (j == 't') { btn.BackgroundImage = Properties.Resources.yesilVezir; btn.Tag = "yesilVezir"; }
                            else if (j == 'u') { btn.BackgroundImage = Properties.Resources.yesilSah; btn.Tag = "yesilSah"; }
                    }
                    else { if (j == 'q' || j == 's' || j == 'u' || j == 'w') btn.BackColor = Color.LightSlateGray; else btn.BackColor = Color.White;

                        if (i == 5) { btn.BackgroundImage = Properties.Resources.yesilPiyon; btn.Tag = "yesilPiyon"; }
                    }
                    odaSahibiContainer.Controls.Add(btn);
                }
            }
            else
            {
                adSoyad1.Text = odaSahibiAdSoyad; adSoyad2.Text = rakipAdSoyad; adSoyad3.Text = rakip2AdSoyad; adSoyad4.Text = rakip3AdSoyad;
                    profilePhoto1.Image = odaSahibiPP; profilePhoto2.Image = rakipPP; profilePhoto3.Image = rakip2PP; profilePhoto4.Image = rakip3PP;
                    profilePhoto1.Tag = "1"; profilePhoto2.Tag = "2"; profilePhoto3.Tag = "3"; profilePhoto4.Tag = "4";
                odaStatus1.Text = "Oda Sahibi"; odaStatus2.Text = "Konuk"; odaStatus3.Text = "Konuk2"; odaStatus4.Text = "Konuk3";
                    rutbeGoster(odaSahibiELO, odaSahibiCins, rutbeTas1, rutbeAd2); rutbeGoster(rakipELO, rakipCins, rutbeTas2, rutbeAd2); rutbeGoster(rakip2ELO, rakip2Cins, rutbeTas3, rutbeAd3); rutbeGoster(rakip3ELO, rakip3Cins, rutbeTas4, rutbeAd4);
                elo1.Text = "ELO: " + odaSahibiELO; elo2.Text = "ELO: " + rakipELO; elo3.Text = "ELO: " + rakip2ELO; elo4.Text = "ELO: " + rakip3ELO;

                        Aciklama.SetToolTip(rutbeAd1, rutbeAd1.Text); Aciklama.SetToolTip(rutbeAd2, rutbeAd2.Text); Aciklama.SetToolTip(rutbeAd3, rutbeAd3.Text); Aciklama.SetToolTip(rutbeAd4, rutbeAd4.Text);

                for (int i = 8; i >= 1; i--) for (char j = 'a'; j <= 'h'; j++)
                {
                    Button btn = hucreOlustur(j, i);

                        if (i % 2 == 0) { if (j == 'b' || j == 'd' || j == 'f' || j == 'h') btn.BackColor = Color.LightSlateGray; else btn.BackColor = Color.White; } else { if (j == 'a' || j == 'c' || j == 'e' || j == 'g')  btn.BackColor = Color.LightSlateGray; else btn.BackColor = Color.White; }

                    satrancTahtasiContainer.Controls.Add(btn);
                }

                for (int i = 3; i >= 1; i--) for (char j = 'i'; j <= 'p'; j++)
                {
                    Button btn = hucreOlustur(j, i);
                    if (i % 2 == 0) { if (j == 'i' || j == 'k' || j == 'm' || j == 'o') btn.BackColor = Color.LightSlateGray; else btn.BackColor = Color.White;

                        if (i == 2) { btn.BackgroundImage = Properties.Resources.kirmiziPiyon; btn.Tag = "kirmiziPiyon"; }
                    }
                    else { if (j == 'j' || j == 'l' || j == 'n' || j == 'p')  btn.BackColor = Color.LightSlateGray; else btn.BackColor = Color.White;

                        if (i == 1)
                            if (j == 'i' || j == 'p') { btn.BackgroundImage = Properties.Resources.kirmiziKale; btn.Tag = "kirmiziKale"; }
                            else if (j == 'j' || j == 'o') { btn.BackgroundImage = Properties.Resources.kirmiziAt; btn.Tag = "kirmiziAt"; }
                            else if (j == 'k' || j == 'n') { btn.BackgroundImage = Properties.Resources.kirmiziFil; btn.Tag = "kirmiziFil"; }
                            else if (j == 'l') { btn.BackgroundImage = Properties.Resources.kirmiziVezir; btn.Tag = "kirmiziVezir"; }
                            else if (j == 'm') { btn.BackgroundImage = Properties.Resources.kirmiziSah; btn.Tag = "kirmiziSah"; }
                    }
                    odaSahibiContainer.Controls.Add(btn);
                }

                for (int i = 6; i >= 4; i--) for (char j = 'i'; j <= 'p'; j++)
                {
                    Button btn = hucreOlustur(j, i);
                    if (i % 2 == 0) { if (j == 'i' || j == 'k' || j == 'm' || j == 'o') btn.BackColor = Color.LightSlateGray; else btn.BackColor = Color.White;

                        if (i == 6)
                            if (j == 'i' || j == 'p') { btn.BackgroundImage = Properties.Resources.turuncuKale; btn.Tag = "turuncuKale"; }
                            else if (j == 'j' || j == 'o') { btn.BackgroundImage = Properties.Resources.turuncuAt; btn.Tag = "turuncuAt"; }
                            else if (j == 'k' || j == 'n') { btn.BackgroundImage = Properties.Resources.turuncuFil; btn.Tag = "turuncuFil"; }
                            else if (j == 'l') { btn.BackgroundImage = Properties.Resources.turuncuVezir; btn.Tag = "turuncuVezir"; }
                            else if (j == 'm') { btn.BackgroundImage = Properties.Resources.turuncuSah; btn.Tag = "turuncuSah"; }
                    }
                    else { if (j == 'j' || j == 'l' || j == 'n' || j == 'p')  btn.BackColor = Color.LightSlateGray; else btn.BackColor = Color.White;

                        if (i == 5) { btn.BackgroundImage = Properties.Resources.turuncuPiyon; btn.Tag = "turuncuPiyon"; }
                    }
                    rakipContainer.Controls.Add(btn);
                }

                for (char j = 'q'; j <= 'x'; j++) for (int i = 1; i <= 3; i++)
                {
                    Button btn = hucreOlustur(j, i);
                    if (i % 2 == 0) { if (j == 'r' || j == 't' || j == 'v' || j == 'x') btn.BackColor = Color.LightSlateGray; else btn.BackColor = Color.White;

                        if (i == 2) { btn.BackgroundImage = Properties.Resources.maviPiyon; btn.Tag = "maviPiyon"; }
                    }
                    else { if (j == 'q' || j == 's' || j == 'u' || j == 'w') btn.BackColor = Color.LightSlateGray; else btn.BackColor = Color.White;

                        if (i == 1)
                            if (j == 'q' || j == 'x') { btn.BackgroundImage = Properties.Resources.maviKale; btn.Tag = "maviKale"; }
                            else if (j == 'r' || j == 'w') { btn.BackgroundImage = Properties.Resources.maviAt; btn.Tag = "maviAt"; }
                            else if (j == 's' || j == 'v') { btn.BackgroundImage = Properties.Resources.maviFil; btn.Tag = "maviFil"; }
                            else if (j == 't') { btn.BackgroundImage = Properties.Resources.maviVezir; btn.Tag = "maviVezir"; }
                            else if (j == 'u') { btn.BackgroundImage = Properties.Resources.maviSah; btn.Tag = "maviSah"; }
                    }
                    rakip2Container.Controls.Add(btn);
                }

                for (char j = 'q'; j <= 'x'; j++) for (int i = 4; i <= 6; i++)
                {
                    Button btn = hucreOlustur(j, i);
                    if (i % 2 == 0) {  if (j == 'r' || j == 't' || j == 'v' || j == 'x') btn.BackColor = Color.LightSlateGray; else btn.BackColor = Color.White;

                        if (i == 6)
                            if (j == 'q' || j == 'x') { btn.BackgroundImage = Properties.Resources.yesilKale; btn.Tag = "yesilKale"; }
                            else if (j == 'r' || j == 'w') { btn.BackgroundImage = Properties.Resources.yesilAt; btn.Tag = "yesilAt"; }
                            else if (j == 's' || j == 'v') { btn.BackgroundImage = Properties.Resources.yesilFil; btn.Tag = "yesilFil"; }
                            else if (j == 't') { btn.BackgroundImage = Properties.Resources.yesilVezir; btn.Tag = "yesilVezir"; }
                            else if (j == 'u') { btn.BackgroundImage = Properties.Resources.yesilSah; btn.Tag = "yesilSah"; }
                    }
                    else { if (j == 'q' || j == 's' || j == 'u' || j == 'w') btn.BackColor = Color.LightSlateGray; else btn.BackColor = Color.White;

                        if (i == 5) { btn.BackgroundImage = Properties.Resources.yesilPiyon; btn.Tag = "yesilPiyon"; }
                    }
                    rakip3Container.Controls.Add(btn);
                }
            }

            List<hamleler> hamleler = new OnlineSatrancEntities().hamleler.Where(s => s.odaNo == odaNo).ToList();

            foreach (hamleler hamle in hamleler)
            {
                Control eskiTas = hamleGoster(hamle.pozisyon);
                Control yeniTas = null;

                char[] notasyonParca = hamle.notasyon.ToCharArray();
                string tasTuru = eskiTas.Tag.ToString();

                    // NOTASYON KONTROL BAŞLANGICI = TAŞIN ESKİ HÜCRESİ => TAŞIN YENİ HÜCRESİ //
                    if (notasyonParca[0] == 'Ş' || notasyonParca[0] == 'V' || notasyonParca[0] == 'F' || notasyonParca[0] == 'A' || notasyonParca[0] == 'K') // Şah, Vezir, Fil, At veya Kale;
                        if (notasyonParca[1] == 'x' || notasyonParca[1] == '+')
                        {// Bir taşı yiyor veya şah çekiyorsa yeniPozisyonu
                         //if (notasyonParca[1] == '+') sahCek = true;

                            yeniTas = hamleGoster(notasyonParca[2] + "" + notasyonParca[3]);

                        }
                        else {       // Yer değiştiriyorsa yeniPozisyonu

                            yeniTas = hamleGoster(notasyonParca[1] + "" + notasyonParca[2]);

                        }
                    else        // Taş piyon ise;    
                        if (notasyonParca.Count() >= 3 && (notasyonParca[2] == 'x' || notasyonParca[2] == '+'))
                        {// Bir taşı yiyor veya şah çekiyorsa yeniPozisyonu
                         //if (notasyonParca[2] == '+') sahCek = true;

                            yeniTas = hamleGoster(notasyonParca[3] + "" + notasyonParca[4]);

                        }
                    else
                    {// Yer değiştiriyorsa yeniPozisyonu
                     //if (notasyonParca.Count() >= 3 && (notasyonParca[2] == 'V' || notasyonParca[2] == 'K')) tasCik = notasyonParca[2];

                             yeniTas = hamleGoster(notasyonParca[0] + "" + notasyonParca[1]);

                    }    // Piyon Vezir veya Kale taşı çıkıyorsa
                         // NOTASYON KONTROL BİTİŞİ = TAŞIN ESKİ HÜCRESİ => TAŞIN YENİ HÜCRESİ //

                    if (hamle.notasyon == "O-O") yeniTas = hamleGoster((char)(hamle.pozisyon[0] + 3) + "" + hamle.pozisyon[1]); // Küçük Rok
                    else if (hamle.notasyon == "O-O-O") yeniTas = hamleGoster((char)(hamle.pozisyon[0] - 4) + "" + hamle.pozisyon[1]); // Büyük Rok

                if (yeniTas.Name[0] >= 'a' && yeniTas.Name[0] <= 'h' && (tasTuru == "kirmiziPiyon" && yeniTas.Name[1] >= '5' || tasTuru == "turuncuPiyon" && yeniTas.Name[1] <= '4' || tasTuru == "maviPiyon" && yeniTas.Name[0] >= 'e' || tasTuru == "yesilPiyon" && yeniTas.Name[0] <= 'd')) yeniTas.Tag = tasTuru.Split('P')[0] + "Vezir";
                else if ((hamle.notasyon == "O-O" || hamle.notasyon == "O-O-O"))
                { string tasTuru2 = yeniTas.Tag.ToString(); yeniTas.Tag = null;
                    if (hamle.notasyon == "O-O")
                    {
                        Control rok1 = hamleGoster((char)(hamle.pozisyon[0] + 1) + "" + hamle.pozisyon[1]);      /***** TAG *****/   rok1.Tag = tasTuru.Contains("Sah") ? tasTuru2 : tasTuru;      /***** BACKGROUND IMAGE *****/    rok1.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject(rok1.Tag.ToString());
                        Control rok2 = hamleGoster((char)(hamle.pozisyon[0] + 2) + "" + hamle.pozisyon[1]);      /***** TAG *****/   rok2.Tag = tasTuru.Contains("Sah") ? tasTuru : tasTuru2;      /***** BACKGROUND IMAGE *****/    rok2.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject(rok2.Tag.ToString());
                    }
                    else if (hamle.notasyon == "O-O-O")
                    {
                        Control rok1 = hamleGoster((char)(hamle.pozisyon[0] - 1) + "" + hamle.pozisyon[1]);      /***** TAG *****/   rok1.Tag = tasTuru.Contains("Sah") ? tasTuru2 : tasTuru;      /***** BACKGROUND IMAGE *****/    rok1.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject(rok1.Tag.ToString());
                        Control rok2 = hamleGoster((char)(hamle.pozisyon[0] - 2) + "" + hamle.pozisyon[1]);      /***** TAG *****/   rok2.Tag = tasTuru.Contains("Sah") ? tasTuru : tasTuru2;      /***** BACKGROUND IMAGE *****/    rok2.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject(rok2.Tag.ToString());
                    } if ((odaBilgisi.kullanicilar.ID == new bilgilerim().getir().ID && tasTuru.Contains("kirmizi")) || (odaBilgisi.kullanicilar1.ID == new bilgilerim().getir().ID && tasTuru.Contains("turuncu")) || (odaBilgisi.kullanicilar2.ID == new bilgilerim().getir().ID && tasTuru.Contains("mavi"))
                       || (odaBilgisi.kullanicilar3.ID == new bilgilerim().getir().ID && tasTuru.Contains("yesil"))) rokKontrol = true;
                } else yeniTas.Tag = eskiTas.Tag;

                    yeniTas.BackgroundImage = yeniTas.Tag != null ? (Image)Properties.Resources.ResourceManager.GetObject(yeniTas.Tag.ToString()) : null;
                eskiTas.BackgroundImage = null;
                eskiTas.Tag = null;
            }
        }

        private void davetEt(object sender, EventArgs e)
        {
            if (Controls.Find("adSoyad" + ((Control)sender).Name[12], true).OfType<Label>().First().Text == "Rakip Bekleniyor..." || Controls.Find("adSoyad" + ((Control)sender).Name[12], true).OfType<Label>().First().Text == "") // Tıklanan yerde oyuncu yoksa;
            {
                kullanicilar bilgilerim = new bilgilerim().getir();
                OnlineSatrancEntities db = new OnlineSatrancEntities();

                    Form form = new Form();
                
                        foreach (arkadasliklar arkadaslik in db.arkadasliklar.Where(s => (s.gonderenID == bilgilerim.ID || s.alıcıID == bilgilerim.ID) && s.arkadaslikDurumu).ToList()) 
                        {
                            kullanicilar arkadas = arkadaslik.kullanicilar1.ID == bilgilerim.ID ? arkadaslik.kullanicilar : arkadaslik.kullanicilar1;
                            Button davetEtBTN = new Button() { Text = arkadas.kAdi + " Davet Et", Dock = DockStyle.Bottom }; davetEtBTN.Tag = arkadas.ID; davetEtBTN.Click += davetEt_Click;
                            form.Controls.Add(davetEtBTN);
                        }

                    void davetEt_Click(object sender2, EventArgs e2) 
                    {
                        db.mesajlar.Add(new mesajlar { gonderenID = bilgilerim.ID, aliciID = Convert.ToInt32(((Button) sender2).Tag.ToString()), mesaj = "Oda No: (" + odaNo + ") Sıra No: [" + ((PictureBox)sender).Tag + "] - Dörtlü Satranç", tarih = DateTime.Now });
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

                SatrancTahtasiController.OdaKontrol odaKontrol = controller.odaKontrol(2);

                kontrol = true;

                if (btn.BackgroundImage == null)
                {
                    MessageBox.Show("BASTIĞINIZ HÜCREDE OYNATILACAK BİR TAŞ YOK!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    kontrol = false;
                }
                else if (odaKontrol.odaSahibi && !odaKontrol.odaRakip && !odaKontrol.odaRakip2 && !odaKontrol.odaRakip3) // ODA SAHİBİ İSENİZ;
                {
                    if (!btn.Tag.ToString().Contains("kirmizi")) // Kırmızı taşa basmadıysanız
                    {
                        MessageBox.Show("DİĞER TAŞLARLA OYNAMA YETKİNİZ YOK!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        kontrol = false;
                    }
                    else if (!odaKontrol.hamleSirasi) // Sıra sizde değilse
                    {
                        MessageBox.Show("SIRA SİZDE DEĞİL!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        kontrol = false;
                    }
                }
                else if (!odaKontrol.odaSahibi && odaKontrol.odaRakip && !odaKontrol.odaRakip2 && !odaKontrol.odaRakip3) // RAKİP1 İSENİZ;
                {
                    if (!btn.Tag.ToString().Contains("turuncu")) // Turuncu taşa basmadıysanız
                    {
                        MessageBox.Show("DİĞER TAŞLARLA OYNAMA YETKİNİZ YOK!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        kontrol = false;
                    }
                    else if (!odaKontrol.hamleSirasi) // Sıra sizde değilse
                    {
                        MessageBox.Show("SIRA SİZDE DEĞİL!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        kontrol = false;
                    }
                }
                else if (!odaKontrol.odaSahibi && !odaKontrol.odaRakip && odaKontrol.odaRakip2 && !odaKontrol.odaRakip3) // RAKİP2 İSENİZ;
                {
                    if (!btn.Tag.ToString().Contains("mavi")) // Mavi taşa basmadıysanız
                    {
                        MessageBox.Show("DİĞER TAŞLARLA OYNAMA YETKİNİZ YOK!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        kontrol = false;
                    }
                    else if (!odaKontrol.hamleSirasi) // Sıra sizde değilse
                    {
                        MessageBox.Show("SIRA SİZDE DEĞİL!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        kontrol = false;
                    }
                }
                else if (!odaKontrol.odaSahibi && !odaKontrol.odaRakip && !odaKontrol.odaRakip2 && odaKontrol.odaRakip3) // RAKİP3 İSENİZ;
                {
                    if (!btn.Tag.ToString().Contains("yesil")) // Yeşil taşa basmadıysanız
                    {
                        MessageBox.Show("DİĞER TAŞLARLA OYNAMA YETKİNİZ YOK!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                string notasyon = null, tasTuru = hamleVePozisyon.ToArray()[0].ToString(), pozisyon = hamleVePozisyon.ToArray()[1].ToString(), yeniPozisyon = hamleVePozisyon.ToArray()[2].ToString(), tasTuru2 = btn.Tag != null ? btn.Tag.ToString() : "--", yenenTas = "-";

                if (!rokKontrol && tasTuru[0] == tasTuru2[0] && pozisyon[1] == yeniPozisyon[1] && (tasTuru.Contains("Sah") && tasTuru2.Contains("Kale") || tasTuru.Contains("Kale") && tasTuru2.Contains("Sah"))) // Rok yapma
                {
                    if ((pozisyon[0] - yeniPozisyon[0] == -3 && hamleGoster((char)(pozisyon[0] + 1) + "" + pozisyon[1]).Tag == null && hamleGoster((char)(pozisyon[0] + 2) + "" + pozisyon[1]).Tag == null)
                     || (pozisyon[0] - yeniPozisyon[0] == 3 && hamleGoster((char)(pozisyon[0] - 1) + "" + pozisyon[1]).Tag == null && hamleGoster((char)(pozisyon[0] - 2) + "" + pozisyon[1]).Tag == null)) notasyon = "O-O"; // Küçük rok
                    else if ((pozisyon[0] - yeniPozisyon[0] == -4 && hamleGoster((char)(pozisyon[0] + 1) + "" + pozisyon[1]).Tag == null && hamleGoster((char)(pozisyon[0] + 2) + "" + pozisyon[1]).Tag == null && hamleGoster((char)(pozisyon[0] + 3) + "" + pozisyon[1]).Tag == null)
                     || (pozisyon[0] - yeniPozisyon[0] == 4 && hamleGoster((char)(pozisyon[0] - 1) + "" + pozisyon[1]).Tag == null && hamleGoster((char)(pozisyon[0] - 2) + "" + pozisyon[1]).Tag == null && hamleGoster((char)(pozisyon[0] - 3) + "" + pozisyon[1]).Tag == null)) notasyon = "O-O-O"; // Büyük rok
                }
                else if (btn.Tag != null) // Taş yeme
                {
                         if (tasTuru2 == "turuncuPiyon" || tasTuru2 == "kirmiziPiyon" || tasTuru2 == "maviPiyon" || tasTuru2 == "yesilPiyon") yenenTas = "";
                    else if (tasTuru2 == "turuncuKale" || tasTuru2 == "kirmiziKale" || tasTuru2 == "maviKale" || tasTuru2 == "yesilKale") yenenTas = "K";
                    else if (tasTuru2 == "turuncuAt" || tasTuru2 == "kirmiziAt" || tasTuru2 == "maviAt" || tasTuru2 == "yesilAt") yenenTas = "A";
                    else if (tasTuru2 == "turuncuFil" || tasTuru2 == "kirmiziFil" || tasTuru2 == "maviFil" || tasTuru2 == "yesilFil") yenenTas = "F";
                    else if (tasTuru2 == "turuncuSah" || tasTuru2 == "kirmiziSah" || tasTuru2 == "maviSah" || tasTuru2 == "yesilSah") yenenTas = "S";
                    else if (tasTuru2 == "turuncuVezir" || tasTuru2 == "kirmiziVezir" || tasTuru2 == "maviVezir" || tasTuru2 == "yesilVezir") yenenTas = "V";

                         if (tasTuru == "turuncuPiyon" || tasTuru == "kirmiziPiyon" || tasTuru == "maviPiyon" || tasTuru == "yesilPiyon") notasyon = pozisyon + "x" + yeniPozisyon;
                    else if (tasTuru == "turuncuKale" || tasTuru == "kirmiziKale" || tasTuru == "maviKale" || tasTuru == "yesilKale") notasyon = "Kx" + yeniPozisyon;
                    else if (tasTuru == "turuncuAt" || tasTuru == "kirmiziAt" || tasTuru == "maviAt" || tasTuru == "yesilAt") notasyon = "Ax" + yeniPozisyon;
                    else if (tasTuru == "turuncuFil" || tasTuru == "kirmiziFil" || tasTuru == "maviFil" || tasTuru == "yesilFil") notasyon = "Fx" + yeniPozisyon;
                    else if (tasTuru == "turuncuSah" || tasTuru == "kirmiziSah" || tasTuru == "maviSah" || tasTuru == "yesilSah") notasyon = "Sx" + yeniPozisyon;
                    else if (tasTuru == "turuncuVezir" || tasTuru == "kirmiziVezir" || tasTuru == "maviVezir" || tasTuru == "yesilVezir") notasyon = "Vx" + yeniPozisyon;
                }
                else // Yer değiştirme
                {
                         if (tasTuru == "turuncuPiyon" || tasTuru == "kirmiziPiyon" || tasTuru == "maviPiyon" || tasTuru == "yesilPiyon") notasyon = yeniPozisyon;
                    else if (tasTuru == "turuncuKale" || tasTuru == "kirmiziKale" || tasTuru == "maviKale" || tasTuru == "yesilKale") notasyon = "K" + yeniPozisyon;
                    else if (tasTuru == "turuncuAt" || tasTuru == "kirmiziAt" || tasTuru == "maviAt" || tasTuru == "yesilAt") notasyon = "A" + yeniPozisyon;
                    else if (tasTuru == "turuncuFil" || tasTuru == "kirmiziFil" || tasTuru == "maviFil" || tasTuru == "yesilFil") notasyon = "F" + yeniPozisyon;
                    else if (tasTuru == "turuncuSah" || tasTuru == "kirmiziSah" || tasTuru == "maviSah" || tasTuru == "yesilSah") notasyon = "S" + yeniPozisyon;
                    else if (tasTuru == "turuncuVezir" || tasTuru == "kirmiziVezir" || tasTuru == "maviVezir" || tasTuru == "yesilVezir") notasyon = "V" + yeniPozisyon;
                }
                //MessageBox.Show("Notasyon: " + notasyon + " | Pozisyon: " + pozisyon);
                if (tasTuru[0] == tasTuru2[0] && !(pozisyon[1] == yeniPozisyon[1] && (tasTuru.Contains("Sah") && tasTuru2.Contains("Kale") || tasTuru.Contains("Kale") && tasTuru2.Contains("Sah")))) MessageBox.Show("Kendi taşını yiyemezsin :)");
                else if (!controller.notasyonGonder(notasyon, pozisyon, yenenTas, 2)) MessageBox.Show(notasyon + " Hatalı");
                else
                {
                    Control eskiTas = hamleGoster(pozisyon);

                    if (yeniPozisyon[0] >= 'a' && yeniPozisyon[0] <= 'h' && (tasTuru == "kirmiziPiyon" && yeniPozisyon[1] >= '5' || tasTuru == "turuncuPiyon" && yeniPozisyon[1] <= '4' || tasTuru == "maviPiyon" && yeniPozisyon[0] >= 'e' || tasTuru == "yesilPiyon" && yeniPozisyon[0] <= 'd'))
                        btn.Tag = tasTuru.Split('P')[0] + "Vezir"; // Vezir çıkma
                    else if (notasyon == "O-O" || notasyon == "O-O-O") // Rok Yapma
                    { 
                        btn.Tag = null; Control rok1, rok2;

                            if (notasyon == "O-O")
                            {
                                rok1 = hamleGoster((char)(pozisyon[0] + 1) + "" + pozisyon[1]);      /***** TAG *****/   rok1.Tag = tasTuru.Contains("Sah") ? tasTuru2 : tasTuru;      /***** BACKGROUND IMAGE *****/    rok1.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject(rok1.Tag.ToString());
                                rok2 = hamleGoster((char)(pozisyon[0] + 2) + "" + pozisyon[1]);      /***** TAG *****/   rok2.Tag = tasTuru.Contains("Sah") ? tasTuru : tasTuru2;      /***** BACKGROUND IMAGE *****/    rok2.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject(rok2.Tag.ToString());
                            }
                            else if (notasyon == "O-O-O")
                            {
                                rok1 = hamleGoster((char)(pozisyon[0] - 1) + "" + pozisyon[1]);      /***** TAG *****/   rok1.Tag = tasTuru.Contains("Sah") ? tasTuru2 : tasTuru;      /***** BACKGROUND IMAGE *****/    rok1.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject(rok1.Tag.ToString());
                                rok2 = hamleGoster((char)(pozisyon[0] - 2) + "" + pozisyon[1]);      /***** TAG *****/   rok2.Tag = tasTuru.Contains("Sah") ? tasTuru : tasTuru2;      /***** BACKGROUND IMAGE *****/    rok2.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject(rok2.Tag.ToString());
                            } rokKontrol = true;
                    }
                    else btn.Tag = tasTuru;
                        btn.BackgroundImage = btn.Tag != null ? (Image)Properties.Resources.ResourceManager.GetObject(btn.Tag.ToString()) : null;

                    eskiTas.BackgroundImage = null;
                    eskiTas.Tag = null;
                }

                kontrol = false;
            }
        }

        private void timerShpGetir_Tick(object sender, EventArgs e)
        {
            kullanicilar sahip = new SatrancTahtasiController().sahipGetir(), rakip = new SatrancTahtasiController().rakipGetir(), rakip2 = new SatrancTahtasiController().rakip2Getir(), rakip3 = new SatrancTahtasiController().rakip3Getir(); bilgilerim bilgilerim = new bilgilerim();

            if (sahip != null)
            {
                Image pp = sahip.cinsiyet ? Properties.Resources.img_avatar1 : Properties.Resources.img_avatar2;

                    if (sahip.ID == bilgilerim.getir().ID) { adSoyad1.Text = sahip.Ad + " " + sahip.Soyad; profilePhoto1.Image = pp; elo1.Text = "ELO: " + sahip.ELO; rutbeGoster(sahip.ELO, sahip.cinsiyet, rutbeTas1, rutbeAd1); }
                    else if (rakip != null && rakip.ID == bilgilerim.getir().ID) { adSoyad2.Text = sahip.Ad + " " + sahip.Soyad; profilePhoto2.Image = pp; elo2.Text = "ELO: " + sahip.ELO; rutbeGoster(sahip.ELO, sahip.cinsiyet, rutbeTas2, rutbeAd2); }
                    else if (rakip2 != null && rakip2.ID == bilgilerim.getir().ID) { adSoyad4.Text = sahip.Ad + " " + sahip.Soyad; profilePhoto4.Image = pp; elo4.Text = "ELO: " + sahip.ELO; rutbeGoster(sahip.ELO, sahip.cinsiyet, rutbeTas4, rutbeAd4); }
                    else if (rakip3 != null && rakip3.ID == bilgilerim.getir().ID) { adSoyad3.Text = sahip.Ad + " " + sahip.Soyad; profilePhoto3.Image = pp; elo3.Text = "ELO: " + sahip.ELO; rutbeGoster(sahip.ELO, sahip.cinsiyet, rutbeTas3, rutbeAd3); }
            }
            else { adSoyad2.Text = "Oda Sahibi Bekleniyor..."; }
        }

        private void timerRkpGetir_Tick(object sender, EventArgs e)
        {
            kullanicilar rakip = new SatrancTahtasiController().rakipGetir(), rakip2 = new SatrancTahtasiController().rakip2Getir(), rakip3 = new SatrancTahtasiController().rakip3Getir();

            if (rakip != null || rakip2 != null || rakip3 != null)
            {
                Image rakipPP = rakip != null ? rakip.cinsiyet ? Properties.Resources.img_avatar1 : Properties.Resources.img_avatar2 : Properties.Resources.img_avatar3, rakip2PP = rakip2 != null ? rakip2.cinsiyet ? Properties.Resources.img_avatar1 : Properties.Resources.img_avatar2 : Properties.Resources.img_avatar3,
                      rakip3PP = rakip3 != null ? rakip3.cinsiyet ? Properties.Resources.img_avatar1 : Properties.Resources.img_avatar2 : Properties.Resources.img_avatar3;
                int rakipELO = rakip != null ? rakip.ELO : 0, rakip2ELO = rakip2 != null ? rakip2.ELO : 0, rakip3ELO = rakip3 != null ? rakip3.ELO : 0;

                if (rakip != null && rakip.ID == new bilgilerim().getir().ID)
                {
                    adSoyad1.Text = rakip.Ad + " " + rakip.Soyad; adSoyad3.Text = rakip3 != null ? rakip3.Ad + " " + rakip3.Soyad : null; adSoyad4.Text = rakip2 != null ? rakip2.Ad + " " + rakip2.Soyad : null;
                    profilePhoto1.Image = rakipPP; profilePhoto3.Image = rakip3PP; profilePhoto4.Image = rakip2PP;
                    elo1.Text = "ELO: " + rakip.ELO; elo3.Text = rakip3 != null ? "ELO: " + rakip3.ELO : "ELO: "; elo4.Text = rakip2 != null ? "ELO: " + rakip2.ELO: "ELO: ";

                         rutbeGoster(rakipELO, rakip.cinsiyet, rutbeTas1, rutbeAd1); rutbeGoster(rakip2ELO, rakip2 != null ? rakip2.cinsiyet : false, rutbeTas4, rutbeAd4); rutbeGoster(rakip3ELO, rakip3 != null ? rakip3.cinsiyet : false, rutbeTas3, rutbeAd3);
                }
                else if (rakip2 != null && rakip2.ID == new bilgilerim().getir().ID)
                {
                    adSoyad1.Text = rakip2.Ad + " " + rakip2.Soyad; adSoyad2.Text = rakip3 != null ? rakip3.Ad + " " + rakip3.Soyad : null; adSoyad3.Text = rakip != null ? rakip.Ad + " " + rakip.Soyad : null;
                    profilePhoto1.Image = rakip2PP; profilePhoto2.Image = rakip3PP; profilePhoto3.Image = rakipPP;
                    elo1.Text = "ELO: " + rakip2.ELO; elo2.Text = rakip3 != null ? "ELO: " + rakip3.ELO : "ELO: "; elo3.Text = rakip != null ? "ELO: " + rakip.ELO: "ELO: ";

                         rutbeGoster(rakipELO, rakip != null ? rakip.cinsiyet : false, rutbeTas3, rutbeAd3); rutbeGoster(rakip2ELO, rakip2.cinsiyet, rutbeTas1, rutbeAd1); rutbeGoster(rakip3ELO, rakip3 != null ? rakip3.cinsiyet : false, rutbeTas2, rutbeAd2);
                }
                else if (rakip3 != null && rakip3.ID == new bilgilerim().getir().ID)
                {
                    adSoyad1.Text = rakip3.Ad + " " + rakip3.Soyad; adSoyad2.Text = rakip2 != null ? rakip2.Ad + " " + rakip2.Soyad : null; adSoyad4.Text = rakip != null ? rakip.Ad + " " + rakip.Soyad : null;
                    profilePhoto1.Image = rakip3PP; profilePhoto2.Image = rakip2PP; profilePhoto4.Image = rakip2PP;
                    elo1.Text = "ELO: " + rakip3.ELO; elo2.Text = rakip2 != null ? "ELO: " + rakip2.ELO : "ELO: "; elo4.Text = rakip != null ? "ELO: " + rakip.ELO: "ELO: ";

                         rutbeGoster(rakipELO, rakip != null ? rakip.cinsiyet : false, rutbeTas4, rutbeAd4); rutbeGoster(rakip2ELO, rakip2 != null ? rakip2.cinsiyet : false, rutbeTas2, rutbeAd2); rutbeGoster(rakip3ELO, rakip3.cinsiyet, rutbeTas1, rutbeAd1);
                }
                else
                {
                    adSoyad2.Text = rakip != null ? rakip.Ad + " " + rakip.Soyad : null; adSoyad3.Text = rakip2 != null ? rakip2.Ad + " " + rakip2.Soyad : null; adSoyad4.Text = rakip3 != null ? rakip3.Ad + " " + rakip3.Soyad : null;
                    profilePhoto2.Image = rakipPP; profilePhoto3.Image = rakip2PP; profilePhoto4.Image = rakip3PP;
                    elo2.Text = rakip != null ? "ELO: " + rakip.ELO : "ELO: "; elo3.Text = rakip2 != null ? "ELO: " + rakip2.ELO: "ELO: "; elo4.Text = rakip3 != null ? "ELO: " + rakip3.ELO: "ELO: ";

                         rutbeGoster(rakipELO, rakip != null ? rakip.cinsiyet : false, rutbeTas2, rutbeAd2); rutbeGoster(rakip2ELO, rakip2 != null ? rakip2.cinsiyet : false, rutbeTas3, rutbeAd3); rutbeGoster(rakip3ELO, rakip3 != null ? rakip3.cinsiyet : false, rutbeTas4, rutbeAd4);
                }

                    if (rakip != null && rakip2 != null && rakip3 != null) { satrancTahtasiContainer.Enabled = true; odaSahibiContainer.Enabled = true; rakipContainer.Enabled = true; rakip2Container.Enabled = true; rakip3Container.Enabled = true; }
                    else { satrancTahtasiContainer.Enabled = false; odaSahibiContainer.Enabled = false; rakipContainer.Enabled = false; rakip2Container.Enabled = false; rakip3Container.Enabled = false; }
            }
            else
            {
                adSoyad2.Text = "Rakip Bekleniyor...";
                adSoyad3.Text = "Rakip Bekleniyor...";
                adSoyad4.Text = "Rakip Bekleniyor...";
                satrancTahtasiContainer.Enabled = false; odaSahibiContainer.Enabled = false; rakipContainer.Enabled = false; rakip2Container.Enabled = false; rakip3Container.Enabled = false;
            }
        }

        private void timerNtsynGetir_Tick(object sender, EventArgs e)
        {
            SatrancTahtasiController controller = new SatrancTahtasiController();
            SatrancTahtasiController.OdaKontrol odaKontrol = controller.odaKontrol(2);

            if (odaKontrol.odaSahibi && (odaKontrol.rakipHamle || odaKontrol.rakip2Hamle || odaKontrol.rakip3Hamle) || 
                odaKontrol.odaRakip && (odaKontrol.sahipHamle || odaKontrol.rakip2Hamle || odaKontrol.rakip3Hamle) || 
                odaKontrol.odaRakip2 && (odaKontrol.sahipHamle || odaKontrol.rakipHamle || odaKontrol.rakip3Hamle) || 
                odaKontrol.odaRakip3 && (odaKontrol.sahipHamle || odaKontrol.rakipHamle || odaKontrol.rakip2Hamle))
            {
                /*if (ntsyGetirKontrol)
                {*/
                    Models.satrancAlgoritmasi.NotasyonGetir hamleBilgisi = controller.notasyonGetir();

                    if (hamleBilgisi != null)
                    {
                        Control eskiTas = hamleGoster(hamleBilgisi.eskiPozisyon);
                        Control yeniTas = hamleGoster(hamleBilgisi.yeniPozisyon);

                        if (eskiTas.BackgroundImage != null && eskiTas.Tag != null)
                        {
                            string tasTuru = eskiTas.Tag.ToString();
                            if (yeniTas.Name[0] >= 'a' && yeniTas.Name[0] <= 'h' && (tasTuru == "kirmiziPiyon" && yeniTas.Name[1] >= '5' || tasTuru == "turuncuPiyon" && yeniTas.Name[1] <= '4' || tasTuru == "maviPiyon" && yeniTas.Name[0] >= 'e' || tasTuru == "yesilPiyon" && yeniTas.Name[0] <= 'd')) yeniTas.Tag = tasTuru.Split('P')[0] + "Vezir";
                            else if ((hamleBilgisi.rokTuru == "O-O" || hamleBilgisi.rokTuru == "O-O-O"))
                            {
                                string tasTuru2 = yeniTas.Tag.ToString(); yeniTas.Tag = null;
                                if (hamleBilgisi.rokTuru == "O-O")
                                {
                                    Control rok1 = hamleGoster((char)(hamleBilgisi.eskiPozisyon[0] + 1) + "" + hamleBilgisi.eskiPozisyon[1]);      /***** TAG *****/   rok1.Tag = tasTuru.Contains("Sah") ? tasTuru2 : tasTuru;      /***** BACKGROUND IMAGE *****/    rok1.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject(rok1.Tag.ToString());
                                    Control rok2 = hamleGoster((char)(hamleBilgisi.eskiPozisyon[0] + 2) + "" + hamleBilgisi.eskiPozisyon[1]);      /***** TAG *****/   rok2.Tag = tasTuru.Contains("Sah") ? tasTuru : tasTuru2;      /***** BACKGROUND IMAGE *****/    rok2.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject(rok2.Tag.ToString());
                                }
                                else if (hamleBilgisi.rokTuru == "O-O-O")
                                {
                                    Control rok1 = hamleGoster((char)(hamleBilgisi.eskiPozisyon[0] - 1) + "" + hamleBilgisi.eskiPozisyon[1]);      /***** TAG *****/   rok1.Tag = tasTuru.Contains("Sah") ? tasTuru2 : tasTuru;      /***** BACKGROUND IMAGE *****/    rok1.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject(rok1.Tag.ToString());
                                    Control rok2 = hamleGoster((char)(hamleBilgisi.eskiPozisyon[0] - 2) + "" + hamleBilgisi.eskiPozisyon[1]);      /***** TAG *****/   rok2.Tag = tasTuru.Contains("Sah") ? tasTuru : tasTuru2;      /***** BACKGROUND IMAGE *****/    rok2.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject(rok2.Tag.ToString());
                                }
                            } else yeniTas.Tag = eskiTas.Tag;
                            yeniTas.BackgroundImage = yeniTas.Tag != null ? (Image)Properties.Resources.ResourceManager.GetObject(yeniTas.Tag.ToString()) : null;
                        }

                        eskiTas.BackgroundImage = null;
                        eskiTas.Tag = null;
                    }
                    //ntsyGetirKontrol = false;
                //}
            }
            //else ntsyGetirKontrol = true;

        }

        private Button hucreOlustur(char j, int i)
        {
            Button btn = new Button();
            btn.Name = j + "" + i;
            btn.Size = new Size(38, 38);
            btn.Margin = Padding.Empty;
            btn.FlatStyle = FlatStyle.Flat;
            btn.Click += notasyonOlustur;
            btn.BackgroundImageLayout = ImageLayout.Stretch;
            return btn;
        }

        private void rutbeGoster(int ELO, bool cinsiyet, PictureBox rutbeTas, Label rutbeAd)
        {
                 if (ELO > 0 && ELO < 500) { rutbeTas.Image = Properties.Resources.cm; rutbeAd.Text = (cinsiyet ? "" : "W") + "CM (" + (cinsiyet ? "" : "Woman ") + "Candidate Master - " + (cinsiyet ? "" : "Kadın ") + "Usta Adayı)"; }
            else if (ELO >= 500 && ELO < 1000) { rutbeTas.Image = Properties.Resources.fm; rutbeAd.Text = (cinsiyet ? "" : "W") + "FM (" + (cinsiyet ? "" : "Woman ") + "FIDE Master - " + (cinsiyet ? "" : "Kadın ") + "FIDE Ustası)"; }
            else if (ELO >= 1000 && ELO < 1500) { rutbeTas.Image = Properties.Resources.im; rutbeAd.Text = (cinsiyet ? "" : "W") + "IM (" + (cinsiyet ? "" : "Woman ") + "International Master - " + (cinsiyet ? "" : "Kadın ") + "Uluslararası Usta)"; }
            else if (ELO >= 1500) { rutbeTas.Image = Properties.Resources.gm; rutbeAd.Text = (cinsiyet ? "" : "W") + "GM (" + (cinsiyet ? "" : "Woman ") + "Grand Master - " + (cinsiyet ? "" : "Kadın ") + "Büyük Usta)"; }
               else { rutbeTas.Image = null; rutbeAd.Text = "UNRANKED!"; }
        }

        private Control hamleGoster(string pozisyon)
        {
                 if (satrancTahtasiContainer.Controls.Find(pozisyon, true).Length != 0)       return   satrancTahtasiContainer.Controls.Find(pozisyon, true)[0];
            else if      (odaSahibiContainer.Controls.Find(pozisyon, true).Length != 0)       return        odaSahibiContainer.Controls.Find(pozisyon, true)[0];
            else if          (rakipContainer.Controls.Find(pozisyon, true).Length != 0)       return            rakipContainer.Controls.Find(pozisyon, true)[0];
            else if         (rakip2Container.Controls.Find(pozisyon, true).Length != 0)       return           rakip2Container.Controls.Find(pozisyon, true)[0];
            else if         (rakip3Container.Controls.Find(pozisyon, true).Length != 0)       return           rakip3Container.Controls.Find(pozisyon, true)[0]; return null;
        }
    }
}
