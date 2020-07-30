using System;
using System.Linq;
using Caïssa.Models.EntityFramework;
using Caïssa.Models;
using System.Collections.Generic;

namespace Caïssa.Controllers
{
    public class SatrancTahtasiController
    {
        OnlineSatrancEntities db = new OnlineSatrancEntities();
        kullanicilar bilgilerim = new bilgilerim().getir();
        int odaNo = Properties.Settings.Default.odaNo;

        public satrancTahtalari getir(int odaTuru, int forceSira)
        {
            satrancTahtalari odaBilgisi = db.satrancTahtalari.Where(s => s.ID == odaNo).FirstOrDefault();

            if (odaTuru == 1)
            {
                if (odaBilgisi.odaSahibi != bilgilerim.ID && odaBilgisi.kullanicilar.ELO >= bilgilerim.ELO - 500 && odaBilgisi.kullanicilar.ELO <= bilgilerim.ELO + 500 && forceSira == 0) // Odanın sahibi ben değilsem
                {
                    if (odaBilgisi.rakip == null || odaBilgisi.rakip == bilgilerim.ID) odaBilgisi.rakip = bilgilerim.ID; // Rakip kısmına benim ismimi yaz
                }
                else if (forceSira == 2) { odaBilgisi.rakip = bilgilerim.ID; db.SaveChanges(); }
            }
            else if (odaTuru == 2)
            {
                if (odaBilgisi.odaSahibi != bilgilerim.ID && odaBilgisi.kullanicilar.ELO >= bilgilerim.ELO - 500 && odaBilgisi.kullanicilar.ELO <= bilgilerim.ELO + 500 && forceSira == 0) // Odanın sahibi ben değilsem
                {
                    if (odaBilgisi.rakip == null || odaBilgisi.rakip == bilgilerim.ID) odaBilgisi.rakip = bilgilerim.ID; // Rakip kısmına benim ismimi yaz
                    else if (odaBilgisi.rakip2 == null || odaBilgisi.rakip2 == bilgilerim.ID) odaBilgisi.rakip2 = bilgilerim.ID; // Rakip2 kısmına benim ismimi yaz
                    else if (odaBilgisi.rakip3 == null || odaBilgisi.rakip3 == bilgilerim.ID) odaBilgisi.rakip3 = bilgilerim.ID; // Rakip3 kısmına benim ismimi yaz
                    db.SaveChanges();
                }
                else if (forceSira == 2) { odaBilgisi.rakip = bilgilerim.ID; db.SaveChanges(); }
                else if (forceSira == 3) { odaBilgisi.rakip2 = bilgilerim.ID; db.SaveChanges(); }
                else if (forceSira == 4) { odaBilgisi.rakip3 = bilgilerim.ID; db.SaveChanges(); }
            }

            return odaBilgisi;
        }

        public int OdaKur(bool BOT, int odaTuru)
        {
            satrancTahtalari satrancTahtasi = db.satrancTahtalari.Where(s => s.odaSahibi == bilgilerim.ID || s.rakip == bilgilerim.ID || s.rakip2 == bilgilerim.ID || s.rakip3 == bilgilerim.ID).FirstOrDefault();
            if (satrancTahtasi != null) return satrancTahtasi.ID;

            satrancTahtalari model = db.satrancTahtalari.Add(new satrancTahtalari { odaSahibi = bilgilerim.ID, odaTuru = odaTuru });

            if (BOT) model.rakip = 6258; // Botlarla oyun başlatılmışsa
            
                db.SaveChanges();

            return model.ID;
        }

        public int Eslestir(int odaTuru)
        {
            List<satrancTahtalari> eslesenOdalar = null;
            
                if (odaTuru == 1) eslesenOdalar = db.satrancTahtalari.Where(s => s.kullanicilar.ELO >= bilgilerim.ELO - 500 && s.kullanicilar.ELO <= bilgilerim.ELO + 500 && (s.rakip == null || s.rakip == bilgilerim.ID)).ToList();
                else if (odaTuru == 2) eslesenOdalar = db.satrancTahtalari.Where(s => s.kullanicilar.ELO >= bilgilerim.ELO - 500 && s.kullanicilar.ELO <= bilgilerim.ELO + 500 && (s.rakip == null || s.rakip == bilgilerim.ID || s.rakip2 == null || s.rakip2 == bilgilerim.ID || s.rakip3 == null || s.rakip3 == bilgilerim.ID)).ToList();

            if (eslesenOdalar.Count != 0)  return eslesenOdalar.ElementAt(new Random().Next(0, eslesenOdalar.Count - 1)).ID; return 0;
        }

        public kullanicilar sahipGetir() => new OnlineSatrancEntities().satrancTahtalari.Where(s => s.ID == odaNo).FirstOrDefault().odaSahibi != null ? new OnlineSatrancEntities().satrancTahtalari.Where(s => s.ID == odaNo).FirstOrDefault().kullanicilar : null;
        public kullanicilar rakipGetir() => new OnlineSatrancEntities().satrancTahtalari.Where(s => s.ID == odaNo).FirstOrDefault().rakip != null ? new OnlineSatrancEntities().satrancTahtalari.Where(s => s.ID == odaNo).FirstOrDefault().kullanicilar1 : null;
        public kullanicilar rakip2Getir() => new OnlineSatrancEntities().satrancTahtalari.Where(s => s.ID == odaNo).FirstOrDefault().rakip2 != null ? new OnlineSatrancEntities().satrancTahtalari.Where(s => s.ID == odaNo).FirstOrDefault().kullanicilar2 : null;
        public kullanicilar rakip3Getir() => new OnlineSatrancEntities().satrancTahtalari.Where(s => s.ID == odaNo).FirstOrDefault().rakip3 != null ? new OnlineSatrancEntities().satrancTahtalari.Where(s => s.ID == odaNo).FirstOrDefault().kullanicilar3 : null;

        public bool notasyonGonder(string notasyon, string pozisyon, string yenenTas, int odaTuru)
        {
            bool jsonSonuc = false;
            int tasRenk = 0;

                 if  (db.satrancTahtalari.Where(s => s.ID == odaNo).FirstOrDefault().kullanicilar.ID == bilgilerim.ID) tasRenk = 1;
            else if (db.satrancTahtalari.Where(s => s.ID == odaNo).FirstOrDefault().kullanicilar2.ID == bilgilerim.ID) tasRenk = 2;
            else if (db.satrancTahtalari.Where(s => s.ID == odaNo).FirstOrDefault().kullanicilar3.ID == bilgilerim.ID) tasRenk = 3;

            satrancAlgoritmasi satranc = new satrancAlgoritmasi(notasyon, pozisyon, odaNo, tasRenk, yenenTas, odaTuru);

            if (satranc.HamleKontrol())
            {
                satranc.notasyonGonder();
                jsonSonuc = true;
            }

            return jsonSonuc;
        }

        public satrancAlgoritmasi.NotasyonGetir notasyonGetir()
        {
            int tasRenk = 0;

                     if  (sahipGetir() != null && sahipGetir().ID == bilgilerim.ID) tasRenk = 1;
                else if (rakip2Getir() != null && rakip2Getir().ID == bilgilerim.ID) tasRenk = 2;
                else if (rakip3Getir() != null && rakip3Getir().ID == bilgilerim.ID) tasRenk = 3;

            return new satrancAlgoritmasi(odaNo).notasyonGetir(tasRenk);
        }

        public OdaKontrol odaKontrol(int odaTuru)
        {
            int hamleAdedi = db.satrancTahtalari.Where(s => s.ID == odaNo).FirstOrDefault().hamleler.Count();
            bool sahip = false, rakip = true, sira = true, sahipHamleYaptiMi = false, rakipHamleYaptiMi = false;

            if (odaTuru == 1)
            {
                    if (getir(odaTuru, 0).odaSahibi == bilgilerim.ID) { sahip = true; rakip = false; } else if (getir(odaTuru, 0).rakip == bilgilerim.ID) { sahip = false; rakip = true; } else { sahip = false; rakip = false; }

                if (hamleAdedi % 2 == 0)
                {
                    if (rakip == true)
                        sira = false;

                    sahipHamleYaptiMi = false;
                    rakipHamleYaptiMi = true;

                    if (hamleAdedi == 0) rakipHamleYaptiMi = false;
                }
                else if (hamleAdedi % 2 == 1)
                {
                    if (sahip == true)
                        sira = false;

                    sahipHamleYaptiMi = true;
                    rakipHamleYaptiMi = false;

                    if (db.satrancTahtalari.Where(s => s.ID == odaNo).FirstOrDefault().rakip == 6258) // Odada bot var ise
                    {
                        int hamleSayisi = db.hamleler.Where(s => s.odaNo == odaNo).Count();

                        int hamle = hamleSayisi / 2; // Botun kayıtlı hamlelerinde sırada olan

                        db.hamleler.Add(new hamleler
                        {
                            notasyon = db.hamleler.Where(s => s.odaNo == 9805).ToList().ElementAt(hamle).notasyon,
                            pozisyon = db.hamleler.Where(s => s.odaNo == 9805).ToList().ElementAt(hamle).pozisyon,
                            odaNo = odaNo
                        });
                        db.SaveChanges();

                        sira = true;
                        sahipHamleYaptiMi = false;
                        rakipHamleYaptiMi = true;

                    }
                }

                return new OdaKontrol { odaSahibi = sahip, odaRakip = rakip, hamleSirasi = sira, sahipHamle = sahipHamleYaptiMi, rakipHamle = rakipHamleYaptiMi };
            }
            else if (odaTuru == 2)
            { bool rakip2 = false, rakip3 = false, rakip2HamleYaptiMi = false, rakip3HamleYaptiMi = false;

                    if (getir(odaTuru, 0).odaSahibi == bilgilerim.ID) { sahip = true; rakip = false; rakip2 = false; rakip3 = false; }
                    else if (getir(odaTuru, 0).rakip == bilgilerim.ID) { sahip = false; rakip = true; rakip2 = false; rakip3 = false; }
                    else if (getir(odaTuru, 0).rakip2 == bilgilerim.ID) { sahip = false; rakip = false; rakip2 = true; rakip3 = false; }
                    else if (getir(odaTuru, 0).rakip3 == bilgilerim.ID) { sahip = false; rakip = false; rakip2 = false; rakip3 = true; }
                    else { sahip = false; rakip = false; rakip2 = false; rakip3 = false; }

                if (hamleAdedi % 4 == 0)
                {
                    if (rakip || rakip2 || rakip3) sira = false;

                    sahipHamleYaptiMi = false;
                    rakipHamleYaptiMi = false;
                    rakip2HamleYaptiMi = false;
                    rakip3HamleYaptiMi = true;

                    if (hamleAdedi == 0) rakip3HamleYaptiMi = false;
                }
                else if (hamleAdedi % 4 == 1)
                {
                    if (sahip || rakip2 || rakip3) sira = false;

                    sahipHamleYaptiMi = true;
                    rakipHamleYaptiMi = false;
                    rakip2HamleYaptiMi = false;
                    rakip3HamleYaptiMi = false;
                }
                else if (hamleAdedi % 4 == 2)
                {
                    if (sahip || rakip || rakip3) sira = false;

                    sahipHamleYaptiMi = false;
                    rakipHamleYaptiMi = true;
                    rakip2HamleYaptiMi = false;
                    rakip3HamleYaptiMi = false;
                }
                else if (hamleAdedi % 4 == 3)
                {
                    if (sahip || rakip || rakip2) sira = false;

                    sahipHamleYaptiMi = false;
                    rakipHamleYaptiMi = false;
                    rakip2HamleYaptiMi = true;
                    rakip3HamleYaptiMi = false;
                }

                return new OdaKontrol { odaSahibi = sahip, odaRakip = rakip, odaRakip2 = rakip2, odaRakip3 = rakip3, hamleSirasi = sira, sahipHamle = sahipHamleYaptiMi, rakipHamle = rakipHamleYaptiMi, rakip2Hamle = rakip2HamleYaptiMi, rakip3Hamle = rakip3HamleYaptiMi };
            } return null;
        }

        public class OdaKontrol
        {
            public bool odaSahibi { get; set; }
            public bool odaRakip { get; set; }
            public bool odaRakip2 { get; set; }
            public bool odaRakip3 { get; set; }
            public bool hamleSirasi { get; set; }
            public bool sahipHamle { get; set; }
            public bool rakipHamle { get; set; }
            public bool rakip2Hamle { get; set; }
            public bool rakip3Hamle { get; set; }
        }
    }
}