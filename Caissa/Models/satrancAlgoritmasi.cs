using System;
using System.Collections.Generic;
using System.Linq;
using Caïssa.Models.EntityFramework;

namespace Caïssa.Models
{
    public class satrancAlgoritmasi
    {
        OnlineSatrancEntities db = new OnlineSatrancEntities();

        private string notasyon, pozisyon, yenenTas;
        private int odaNo, odaTuru, tasRenk;
        private char[] hamleKomut;
        private char sutun, satir;

        public satrancAlgoritmasi(int gelenOdaNo)
        {
            odaNo = gelenOdaNo;
        }

        public satrancAlgoritmasi(string gelenNotasyon, string gelenPozisyon, int gelenOdaNo, int gelenTasRenk, string gelenYenenTas, int gelenOdaTuru)
        {
            notasyon = gelenNotasyon;
            pozisyon = gelenPozisyon;
            odaNo = gelenOdaNo;
            tasRenk = gelenTasRenk;
            yenenTas = gelenYenenTas;
            odaTuru = gelenOdaTuru;

            if (notasyon == null) hamleKomut = null; else hamleKomut = notasyon.ToCharArray();
            sutun = pozisyon.ToCharArray()[0];
            satir = pozisyon.ToCharArray()[1];
        }

        public List<string> olasiHamleler()
        {
            List<string> hamleList = new List<string>();
            return hamleList;
        }

        public bool HamleKontrol()
        {
            if (hamleKomut == null) return false;
            if (odaTuru == 1)
            {
                if (hamleKomut[1] == 'x')
                {
                    hamleKomut[1] = hamleKomut[2];
                    hamleKomut[2] = hamleKomut[3];
                }

                switch (hamleKomut[0])
                {
                    case 'Ş': // Taş Şah ise
                        if (hamleKomut[1] == sutun && hamleKomut[2] != satir) // Aşağı-Yukarı
                        {
                            if (hamleKomut[2] == satir + 1) return true; // 1 Adım Yukarı
                            else if (hamleKomut[2] == satir - 1) return true; // 1 Adım Aşağı
                        }
                        else if (hamleKomut[1] != sutun && hamleKomut[2] == satir) // Sağa-Sola
                        {
                            if (hamleKomut[1] == sutun + 1) return true; // 1 Adım Sağa
                            else if (hamleKomut[1] == sutun - 1) return true; // 1 Adım Sola
                        }
                        else // Çapraz
                            if (hamleKomut[1] == sutun + 1 && hamleKomut[2] == satir + 1) return true; // 1 Adım Sağ-Yukarı
                        else if (hamleKomut[1] == sutun + 1 && hamleKomut[2] == satir - 1) return true; // 1 Adım Sağ-Aşağı
                        else if (hamleKomut[1] == sutun - 1 && hamleKomut[2] == satir + 1) return true; // 1 Adım Sol-Yukarı
                        else if (hamleKomut[1] == sutun - 1 && hamleKomut[2] == satir - 1) return true; // 1 Adım Sol-Aşağı
                        break;
                    case 'V': // Taş Vezir ise
                        if (kabiliyet("Yukarı-Aşağı") || kabiliyet("Sağa-Sola") || kabiliyet("Çapraz")) return true;
                        break;
                    case 'F': // Taş Fil ise
                        if (kabiliyet("Çapraz")) return true;
                        break;
                    case 'A': // Taş At ise
                        if (hamleKomut[1] == sutun + 2 && hamleKomut[2] == satir + 1) return true; // 3 sağa 1 yukarı
                        else if (hamleKomut[1] == sutun + 2 && hamleKomut[2] == satir - 1) return true; // 3 sağa 1 aşağı
                        else if (hamleKomut[1] == sutun - 2 && hamleKomut[2] == satir + 1) return true; // 3 sola 1 yukarı
                        else if (hamleKomut[1] == sutun - 2 && hamleKomut[2] == satir - 1) return true; // 3 sola 1 aşağı
                        else if (hamleKomut[1] == sutun + 1 && hamleKomut[2] == satir + 2) return true; // 3 yukarı 1 sağa
                        else if (hamleKomut[1] == sutun - 1 && hamleKomut[2] == satir + 2) return true; // 3 yukarı 1 sola
                        else if (hamleKomut[1] == sutun + 1 && hamleKomut[2] == satir - 2) return true; // 3 aşağı 1 sağa
                        else if (hamleKomut[1] == sutun - 1 && hamleKomut[2] == satir - 2) return true; // 3 aşağı 1 sola
                        break;
                    case 'K': // Taş Kale ise
                        if (kabiliyet("Yukarı-Aşağı") || kabiliyet("Sağa-Sola")) return true;
                        break;
                    default: // Taş piyon ise
                        /*if (hamleKomut.Length == 5 && hamleKomut[2] == 'x')
                        {
                            hamleKomut[0] = hamleKomut[3];
                            hamleKomut[1] = hamleKomut[4];

                                if (tasRenk == true && hamleKomut[0] == sutun + 1 && hamleKomut[1] == satir + 1 || tasRenk == false && hamleKomut[0] == sutun + 1 && hamleKomut[1] == satir - 1) return true; // Sağ-Çapraz yeme
                                else if (tasRenk == true && hamleKomut[0] == sutun - 1 && hamleKomut[1] == satir + 1 || tasRenk == false && hamleKomut[0] == sutun - 1 && hamleKomut[1] == satir - 1) return true; // Sol-Çapraz yeme
                        }else
                        {*/
                        if (hamleKomut[0] == sutun && hamleKomut[1] != satir)
                        { // Yukarı-Aşağı
                            if ((tasRenk == 1 && hamleKomut[1] == satir + 1) || (tasRenk == 0 && hamleKomut[1] == satir - 1)) return true; // 1 Adım Yukarı
                            else if ((tasRenk == 1 && satir == '2' && hamleKomut[1] == satir + 2) || (tasRenk == 0 && satir == '7' && hamleKomut[1] == satir - 2)) return true; // piyon ilk hamlede iki adım gidebilir
                        }
                        else if (hamleKomut[3] != sutun && hamleKomut[4] != satir) // Capraz
                            if ((tasRenk == 1 && hamleKomut[4] == satir + 1 && (hamleKomut[3] == sutun + 1 || hamleKomut[3] == sutun - 1)) || (tasRenk == 0 && hamleKomut[4] == satir - 1 && (hamleKomut[3] == sutun + 1 || hamleKomut[3] == sutun - 1))) return true; // Çapraz taş yeme
                                                                                                                                                                                                                                                                              //}
                        break;
                }
            }
            else if (odaTuru == 2)
            {
                if (hamleKomut[1] == 'x' && !Char.IsNumber(hamleKomut[2]))
                {
                    hamleKomut[1] = hamleKomut[2];
                    hamleKomut[2] = hamleKomut[3];
                }

                switch (hamleKomut[0])
                {
                    case 'Ş': // Taş Şah ise
                        if (hamleKomut[1] == sutun && hamleKomut[2] != satir) // Aşağı-Yukarı
                        {
                            if (hamleKomut[2] == satir + 1) return true; // 1 Adım Yukarı
                            else if (hamleKomut[2] == satir - 1) return true; // 1 Adım Aşağı
                        }
                        else if (hamleKomut[1] != sutun && hamleKomut[2] == satir) // Sağa-Sola
                        {
                            if (hamleKomut[1] == sutun + 1) return true; // 1 Adım Sağa
                            else if (hamleKomut[1] == sutun - 1) return true; // 1 Adım Sola
                        }
                        else // Çapraz
                            if (hamleKomut[1] == sutun + 1 && hamleKomut[2] == satir + 1) return true; // 1 Adım Sağ-Yukarı
                        else if (hamleKomut[1] == sutun + 1 && hamleKomut[2] == satir - 1) return true; // 1 Adım Sağ-Aşağı
                        else if (hamleKomut[1] == sutun - 1 && hamleKomut[2] == satir + 1) return true; // 1 Adım Sol-Yukarı
                        else if (hamleKomut[1] == sutun - 1 && hamleKomut[2] == satir - 1) return true; // 1 Adım Sol-Aşağı
                        break;
                    case 'V': // Taş Vezir ise
                        if (kabiliyet("Yukarı-Aşağı") || kabiliyet("Sağa-Sola") || kabiliyet("Çapraz")) return true;
                        break;
                    case 'F': // Taş Fil ise
                        if (kabiliyet("Çapraz")) return true;
                        break;
                    case 'A': // Taş At ise
                             if (hamleKomut[1] == sutun + 2 && hamleKomut[2] == satir + 1) return true; // 3 sağa 1 yukarı
                        else if (hamleKomut[1] == sutun + 2 && hamleKomut[2] == satir - 1) return true; // 3 sağa 1 aşağı
                        else if (hamleKomut[1] == sutun - 2 && hamleKomut[2] == satir + 1) return true; // 3 sola 1 yukarı
                        else if (hamleKomut[1] == sutun - 2 && hamleKomut[2] == satir - 1) return true; // 3 sola 1 aşağı
                        else if (hamleKomut[1] == sutun + 1 && hamleKomut[2] == satir + 2) return true; // 3 yukarı 1 sağa
                        else if (hamleKomut[1] == sutun - 1 && hamleKomut[2] == satir + 2) return true; // 3 yukarı 1 sola
                        else if (hamleKomut[1] == sutun + 1 && hamleKomut[2] == satir - 2) return true; // 3 aşağı 1 sağa
                        else if (hamleKomut[1] == sutun - 1 && hamleKomut[2] == satir - 2) return true; // 3 aşağı 1 sola

                        else if (sutun >= 'i' && sutun <= 'p')
                        {
                            if (satir >= '1' && satir <= '3')
                            {
                                     if (hamleKomut[1] == sutun - 6 && hamleKomut[2] == satir - 2) return true; // Kırmızı'dan 3 sağa 1 yukarı
                                else if (hamleKomut[1] == sutun + 6 && hamleKomut[2] == satir + 2) return true; // Kırmızı'ya 3 sola 1 aşağı
                                else if (hamleKomut[1] == sutun + 10 && hamleKomut[2] == satir + 2) return true; // Kırmızı'ya 3 sağa 1 aşağı
                                else if (hamleKomut[1] == sutun - 10 && hamleKomut[2] == satir - 2) return true; // Kırmızı'dan 3 sola 1 yukarı
                                else if (hamleKomut[1] == sutun - 7 && hamleKomut[2] == satir - 1) return true; // Kırmızı'dan 3 yukarı 1 sağa
                                else if (hamleKomut[1] == sutun + 7 && hamleKomut[2] == satir + 1) return true; // Kırmızı'ya 3 aşağı 1 sola
                                else if (hamleKomut[1] == sutun + 9 && hamleKomut[2] == satir + 1) return true; // Kırmızı'ya 3 aşağı 1 sağa
                                else if (hamleKomut[1] == sutun - 9 && hamleKomut[2] == satir - 1) return true; // Kırmızı'dan 3 yukarı 1 sola
                            }
                            else if (satir >= '4' && satir <= '6')
                            {
                                     if (hamleKomut[1] == sutun - 10 && hamleKomut[2] == satir + 4) return true; // Turuncu'dan 3 sağa 1 yukarı
                                else if (hamleKomut[1] == sutun + 10 && hamleKomut[2] == satir - 4) return true; // Turuncu'ya 3 sola 1 aşağı
                                else if (hamleKomut[1] == sutun + 6 && hamleKomut[2] == satir - 4) return true; // Turuncu'ya 3 sağa 1 aşağı
                                else if (hamleKomut[1] == sutun - 6 && hamleKomut[2] == satir + 4) return true; // Turuncu'dan 3 sola 1 yukarı
                                else if (hamleKomut[1] == sutun - 9 && hamleKomut[2] == satir + 3) return true; // Turuncu'dan 3 yukarı 1 sağa
                                else if (hamleKomut[1] == sutun + 9 && hamleKomut[2] == satir - 3) return true; // Turuncu'ya 3 aşağı 1 sola
                                else if (hamleKomut[1] == sutun + 7 && hamleKomut[2] == satir - 3) return true; // Turuncu'ya 3 aşağı 1 sağa
                                else if (hamleKomut[1] == sutun - 7 && hamleKomut[2] == satir + 3) return true; // Turuncu'dan 3 yukarı 1 sola
                            }
                        }
                        else if (sutun >= 'q' && sutun <= 'x')
                        {
                            if (satir >= '1' && satir <= '3')
                            {
                                     if (sutun - hamleKomut[1] == 16 && hamleKomut[2] - satir == 3 || sutun - hamleKomut[1] == 17 && hamleKomut[2] - satir == 2 || sutun - hamleKomut[1] == 18 && hamleKomut[2] - satir == 1 || sutun - hamleKomut[1] == 19 && hamleKomut[2] - satir == 0 || sutun - hamleKomut[1] == 20 && hamleKomut[2] - satir == -1 || sutun - hamleKomut[1] == 21 && hamleKomut[2] - satir == -2) return true; // Mavi'den 3 sağa 1 yukarı
                                else if (hamleKomut[1] - sutun == 16 && satir - hamleKomut[2] == 3 || hamleKomut[1] - sutun == 17 && satir - hamleKomut[2] == 2 || hamleKomut[1] - sutun == 18 && satir - hamleKomut[2] == 1 || hamleKomut[1] - sutun == 19 && satir - hamleKomut[2] == 0 || hamleKomut[1] - sutun == 20 && satir - hamleKomut[2] == -1 || hamleKomut[1] - sutun == 21 && satir - hamleKomut[2] == -2) return true; // Mavi'ye 3 sola 1 aşağı
                                else if (hamleKomut[1] - sutun == 18 && satir - hamleKomut[2] == 5 || hamleKomut[1] - sutun == 19 && satir - hamleKomut[2] == 4 || hamleKomut[1] - sutun == 20 && satir - hamleKomut[2] == 3 || hamleKomut[1] - sutun == 21 && satir - hamleKomut[2] == 2 || hamleKomut[1] - sutun == 22 && satir - hamleKomut[2] == 1 || hamleKomut[1] - sutun == 23 && satir - hamleKomut[2] == 0) return true; // Mavi'ye 3 sağa 1 aşağı
                                else if (sutun - hamleKomut[1] == 18 && hamleKomut[2] - satir == 5 || sutun - hamleKomut[1] == 19 && hamleKomut[2] - satir == 4 || sutun - hamleKomut[1] == 20 && hamleKomut[2] - satir == 3 || sutun - hamleKomut[1] == 21 && hamleKomut[2] - satir == 2 || sutun - hamleKomut[1] == 22 && hamleKomut[2] - satir == 1 || sutun - hamleKomut[1] == 23 && hamleKomut[2] - satir == 0) return true; // Mavi'den 3 sola 1 yukarı
                                else if (sutun - hamleKomut[1] == 15 && hamleKomut[2] - satir == 4 || sutun - hamleKomut[1] == 16 && hamleKomut[2] - satir == 3 || sutun - hamleKomut[1] == 17 && hamleKomut[2] - satir == 2 || sutun - hamleKomut[1] == 18 && hamleKomut[2] - satir == 1 || sutun - hamleKomut[1] == 19 && hamleKomut[2] - satir == 0 || sutun - hamleKomut[1] == 20 && hamleKomut[2] - satir == -1 || sutun - hamleKomut[1] == 21 && hamleKomut[2] - satir == -2) return true; // Mavi'den 3 yukarı 1 sağa
                                else if (hamleKomut[1] - sutun == 15 && satir - hamleKomut[2] == 4 || hamleKomut[1] - sutun == 16 && satir - hamleKomut[2] == 3 || hamleKomut[1] - sutun == 17 && satir - hamleKomut[2] == 2 || hamleKomut[1] - sutun == 18 && satir - hamleKomut[2] == 1 || hamleKomut[1] - sutun == 19 && satir - hamleKomut[2] == 0 || hamleKomut[1] - sutun == 20 && satir - hamleKomut[2] == -1 || hamleKomut[1] - sutun == 21 && satir - hamleKomut[2] == -2) return true; // Mavi'ye 3 aşağı 1 sola
                                else if (hamleKomut[1] - sutun == 16 && satir - hamleKomut[2] == 5 || hamleKomut[1] - sutun == 17 && satir - hamleKomut[2] == 4 || hamleKomut[1] - sutun == 18 && satir - hamleKomut[2] == 3 || hamleKomut[1] - sutun == 19 && satir - hamleKomut[2] == 2 || hamleKomut[1] - sutun == 20 && satir - hamleKomut[2] == 1 || hamleKomut[1] - sutun == 21 && satir - hamleKomut[2] == 0 || hamleKomut[1] - sutun == 22 && satir - hamleKomut[2] == -1) return true; // Mavi'ye 3 aşağı 1 sağa
                                else if (sutun - hamleKomut[1] == 16 && hamleKomut[2] - satir == 5 || sutun - hamleKomut[1] == 17 && hamleKomut[2] - satir == 4 || sutun - hamleKomut[1] == 18 && hamleKomut[2] - satir == 3 || sutun - hamleKomut[1] == 19 && hamleKomut[2] - satir == 2 || sutun - hamleKomut[1] == 20 && hamleKomut[2] - satir == 1 || sutun - hamleKomut[1] == 21 && hamleKomut[2] - satir == 0 || sutun - hamleKomut[1] == 22 && hamleKomut[2] - satir == -1) return true; // Mavi'den 3 yukarı 1 sola
                            }
                            else if (satir >= '4' && satir <= '6')
                            {
                                     if (sutun - hamleKomut[1] == 11 && hamleKomut[2] - satir == 4 || sutun - hamleKomut[1] == 12 && hamleKomut[2] - satir == 3 || sutun - hamleKomut[1] == 13 && hamleKomut[2] - satir == 2 || sutun - hamleKomut[1] == 14 && hamleKomut[2] - satir == 1 || sutun - hamleKomut[1] == 15 && hamleKomut[2] - satir == 0 || sutun - hamleKomut[1] == 16 && hamleKomut[2] - satir == -1) return true; // Yeşil'den 3 sağa 1 yukarı
                                else if (hamleKomut[1] - sutun == 11 && satir - hamleKomut[2] == 4 || hamleKomut[1] - sutun == 12 && satir - hamleKomut[2] == 3 || hamleKomut[1] - sutun == 13 && satir - hamleKomut[2] == 2 || hamleKomut[1] - sutun == 14 && satir - hamleKomut[2] == 1 || hamleKomut[1] - sutun == 15 && satir - hamleKomut[2] == 0 || hamleKomut[1] - sutun == 16 && satir - hamleKomut[2] == -1) return true; // Yeşil'e 3 sola 1 aşağı
                                else if (hamleKomut[1] - sutun == 9 && satir - hamleKomut[2] == 2 || hamleKomut[1] - sutun == 10 && satir - hamleKomut[2] == 1 || hamleKomut[1] - sutun == 11 && satir - hamleKomut[2] == 0 || hamleKomut[1] - sutun == 12 && satir - hamleKomut[2] == -1 || hamleKomut[1] - sutun == 13 && satir - hamleKomut[2] == -2 || hamleKomut[1] - sutun == 14 && satir - hamleKomut[2] == -3) return true; // Yeşil'e 3 sağa 1 aşağı
                                else if (sutun - hamleKomut[1] == 9 && hamleKomut[2] - satir == 2 || sutun - hamleKomut[1] == 10 && hamleKomut[2] - satir == 1 || sutun - hamleKomut[1] == 11 && hamleKomut[2] - satir == 0 || sutun - hamleKomut[1] == 12 && hamleKomut[2] - satir == -1 || sutun - hamleKomut[1] == 13 && hamleKomut[2] - satir == -2 || sutun - hamleKomut[1] == 14 && hamleKomut[2] - satir == -3) return true; // Yeşil'den 3 sola 1 yukarı
                                else if (sutun - hamleKomut[1] == 11 && hamleKomut[2] - satir == 4 || sutun - hamleKomut[1] == 12 && hamleKomut[2] - satir == 3 || sutun - hamleKomut[1] == 13 && hamleKomut[2] - satir == 2 || sutun - hamleKomut[1] == 14 && hamleKomut[2] - satir == 1 || sutun - hamleKomut[1] == 15 && hamleKomut[2] - satir == 0 || sutun - hamleKomut[1] == 16 && hamleKomut[2] - satir == -1 || sutun - hamleKomut[1] == 17 && hamleKomut[2] - satir == -2) return true; // Yeşil'den 3 yukarı 1 sağa
                                else if (hamleKomut[1] - sutun == 11 && satir - hamleKomut[2] == 4 || hamleKomut[1] - sutun == 12 && satir - hamleKomut[2] == 3 || hamleKomut[1] - sutun == 13 && satir - hamleKomut[2] == 2 || hamleKomut[1] - sutun == 14 && satir - hamleKomut[2] == 1 || hamleKomut[1] - sutun == 15 && satir - hamleKomut[2] == 0 || hamleKomut[1] - sutun == 16 && satir - hamleKomut[2] == -1 || hamleKomut[1] - sutun == 17 && satir - hamleKomut[2] == -2) return true; // Yeşil'e 3 aşağı 1 sola
                                else if (hamleKomut[1] - sutun == 10 && satir - hamleKomut[2] == 3 || hamleKomut[1] - sutun == 11 && satir - hamleKomut[2] == 2 || hamleKomut[1] - sutun == 12 && satir - hamleKomut[2] == 1 || hamleKomut[1] - sutun == 13 && satir - hamleKomut[2] == 0 || hamleKomut[1] - sutun == 14 && satir - hamleKomut[2] == -1 || hamleKomut[1] - sutun == 15 && satir - hamleKomut[2] == -2 || hamleKomut[1] - sutun == 16 && satir - hamleKomut[2] == -3) return true; // Yeşil'e 3 aşağı 1 sağa
                                else if (sutun - hamleKomut[1] == 10 && hamleKomut[2] - satir == 3 || sutun - hamleKomut[1] == 11 && hamleKomut[2] - satir == 2 || sutun - hamleKomut[1] == 12 && hamleKomut[2] - satir == 1 || sutun - hamleKomut[1] == 13 && hamleKomut[2] - satir == 0 || sutun - hamleKomut[1] == 14 && hamleKomut[2] - satir == -1 || sutun - hamleKomut[1] == 15 && hamleKomut[2] - satir == -2 || sutun - hamleKomut[1] == 16 && hamleKomut[2] - satir == -3) return true; // Yeşil'den 3 yukarı 1 sola
                            }
                        }
                        break;
                    case 'K': // Taş Kale ise
                        if (kabiliyet("Yukarı-Aşağı") || kabiliyet("Sağa-Sola")) return true;
                        break;
                    default: // Taş piyon ise
                        /*if (hamleKomut.Length == 5 && hamleKomut[2] == 'x')
                        {
                            hamleKomut[0] = hamleKomut[3];
                            hamleKomut[1] = hamleKomut[4];

                                if (tasRenk == true && hamleKomut[0] == sutun + 1 && hamleKomut[1] == satir + 1 || tasRenk == false && hamleKomut[0] == sutun + 1 && hamleKomut[1] == satir - 1) return true; // Sağ-Çapraz yeme
                                else if (tasRenk == true && hamleKomut[0] == sutun - 1 && hamleKomut[1] == satir + 1 || tasRenk == false && hamleKomut[0] == sutun - 1 && hamleKomut[1] == satir - 1) return true; // Sol-Çapraz yeme
                        }else
                        {*/
                        if (notasyon == "O-O" || notasyon == "O-O-O") return true;
                        if ((hamleKomut[0] == sutun && hamleKomut[1] != satir) || ((tasRenk == 0 || tasRenk == 1) && sutun - hamleKomut[0] == 8) || (tasRenk == 2 && sutun - hamleKomut[0] >= 16 && sutun - hamleKomut[0] < 24) || (tasRenk == 3 && sutun - hamleKomut[0] > 8 && sutun - hamleKomut[0] <= 16))
                        { // Yukarı-Aşağı
                            if (((tasRenk == 1 || tasRenk == 2) && hamleKomut[1] == satir + 1) || ((tasRenk == 0 || tasRenk == 3) && hamleKomut[1] == satir - 1)) return true; // 1 Adım Yukarı
                            else if (((tasRenk == 1 || tasRenk == 2) && sutun - hamleKomut[0] == 8 && hamleKomut[1] == satir - 2) || ((tasRenk == 0 || tasRenk == 3) && hamleKomut[1] == satir - 1)) return true; // Kırmızı'dan 1 Adım Yukarı
                            else if (((tasRenk == 1 || tasRenk == 2) && satir == '2' && hamleKomut[1] == satir - 1) || ((tasRenk == 0 || tasRenk == 3) && satir == '5' && hamleKomut[1] == satir + 3)) return true; // piyon ilk hamlede iki adım gidebilir
                        }
                        else if (hamleKomut[3] != sutun) // Capraz
                        {
                            if (((tasRenk == 1 || tasRenk == 2) && hamleKomut[4] == satir + 1 && (hamleKomut[3] == sutun + 1 || hamleKomut[3] == sutun - 1)) || ((tasRenk == 0 || tasRenk == 3) && hamleKomut[4] == satir - 1 && (hamleKomut[3] == sutun + 1 || hamleKomut[3] == sutun - 1))) return true; // Çapraz taş yeme
                                                                                                                                                                                                                                                                                                           //}
                            else if ((hamleKomut[3] - sutun >= 16 && hamleKomut[3] - sutun < 24) && (((tasRenk == 1 || tasRenk == 3) && satir - hamleKomut[4] >= -2 && satir - hamleKomut[4] <= 4) || tasRenk == 0 && satir - hamleKomut[4] >= -1 && satir - hamleKomut[4] <= 5)) return true;// A SÜTUNUN'DAN MAVİ'YE ÇAPRAZ
                            //else if ((hamleKomut[3] - sutun >= 8 && hamleKomut[3] - sutun <= 16) && ()) return true;// H SÜTUNUN'DAN YEŞİL'E ÇAPRAZ
                        }
                        break;
                }
            }         

            return false; // Notasyon uymuyorsa;
        }

        public bool kabiliyet(string yon)
        {
            switch (yon)
            {
                case "Yukarı-Aşağı":
                    if (hamleKomut[1] == sutun && hamleKomut[2] != satir) // Yukarı-Aşağı
                    {
                        if (hamleKomut[2] > satir) { if (aradaTasVarMi("Yukarı") == false) return true; }  // Yukarı
                        else if (hamleKomut[2] < satir) { if (aradaTasVarMi("Aşağı") == false) return true; }  // Aşağı
                    }
                    else if (sutun - hamleKomut[1] == 8 || sutun - hamleKomut[1] == -8) return true; // Kırmızı-Turuncu için Yukarı-Aşağı
                    else if ((hamleKomut[1] >= 'a' && hamleKomut[1] <= 'h' &&
                            ((sutun == 'q' && hamleKomut[2] == '8') || (sutun == 'r' && hamleKomut[2] == '7') || (sutun == 's' && hamleKomut[2] == '6') || (sutun == 't' && hamleKomut[2] == '5') || (sutun == 'u' && hamleKomut[2] == '4') || (sutun == 'v' && hamleKomut[2] == '3') || (sutun == 'w' && hamleKomut[2] == '2') || (sutun == 'x' && hamleKomut[2] == '1'))) ||
                            sutun >= 'a' && sutun <= 'h' &&
                            ((hamleKomut[1] == 'q' && satir == '8') || (hamleKomut[1] == 'r' && satir == '7') || (hamleKomut[1] == 's' && satir == '6') || (hamleKomut[1] == 't' && satir == '5') || (hamleKomut[1] == 'u' && satir == '4') || (hamleKomut[1] == 'v' && satir == '3') || (hamleKomut[1] == 'w' && satir == '2') || (hamleKomut[1] == 'x' && satir == '1')))
                        return true; // Mavi-Yeşil için Yukarı-Aşağı
                    break;
                case "Sağa-Sola":
                    if (hamleKomut[1] != sutun && hamleKomut[2] == satir) // Sağa-Sola
                    {
                        if (hamleKomut[1] > sutun) { if (aradaTasVarMi("Sağ") == false) return true; }  // Sağa
                        else if (hamleKomut[1] < sutun) { if (aradaTasVarMi("Sol") == false) return true; }  // Sola
                    }
                    else if ((hamleKomut[1] >= 'a' && hamleKomut[1] <= 'h' &&
                            ((sutun == 'q' && hamleKomut[2] == '8') || (sutun == 'r' && hamleKomut[2] == '7') || (sutun == 's' && hamleKomut[2] == '6') || (sutun == 't' && hamleKomut[2] == '5') || (sutun == 'u' && hamleKomut[2] == '4') || (sutun == 'v' && hamleKomut[2] == '3') || (sutun == 'w' && hamleKomut[2] == '2') || (sutun == 'x' && hamleKomut[2] == '1'))) ||
                            sutun >= 'a' && sutun <= 'h' &&
                            ((hamleKomut[1] == 'q' && satir == '8') || (hamleKomut[1] == 'r' && satir == '7') || (hamleKomut[1] == 's' && satir == '6') || (hamleKomut[1] == 't' && satir == '5') || (hamleKomut[1] == 'u' && satir == '4') || (hamleKomut[1] == 'v' && satir == '3') || (hamleKomut[1] == 'w' && satir == '2') || (hamleKomut[1] == 'x' && satir == '1')))
                        return true; // Kırmızı-Turuncu için Sağa-Sola
                    else if (sutun - hamleKomut[1] == 8 || sutun - hamleKomut[1] == -8) return true; // Mavi-Yeşil için Sağa-Sola
                    break;
                case "Çapraz":
                    if (hamleKomut[1] == sutun + 1 && hamleKomut[2] == satir + 1 || hamleKomut[1] == sutun + 2 && hamleKomut[2] == satir + 2 || hamleKomut[1] == sutun + 3 && hamleKomut[2] == satir + 3
                        || hamleKomut[1] == sutun + 4 && hamleKomut[2] == satir + 4 || hamleKomut[1] == sutun + 5 && hamleKomut[2] == satir + 5 || hamleKomut[1] == sutun + 6 && hamleKomut[2] == satir + 6
                        || hamleKomut[1] == sutun + 7 && hamleKomut[2] == satir + 7) { if (!aradaTasVarMi("Sağ-Yukarı")) return true; } //Sağ-Yukarı arada taş yoksa
                    else if (hamleKomut[1] == sutun + 1 && hamleKomut[2] == satir - 1 || hamleKomut[1] == sutun + 2 && hamleKomut[2] == satir - 2 || hamleKomut[1] == sutun + 3 && hamleKomut[2] == satir - 3
                            || hamleKomut[1] == sutun + 4 && hamleKomut[2] == satir - 4 || hamleKomut[1] == sutun + 5 && hamleKomut[2] == satir - 5 || hamleKomut[1] == sutun + 6 && hamleKomut[2] == satir - 6
                            || hamleKomut[1] == sutun + 7 && hamleKomut[2] == satir - 7) { if (!aradaTasVarMi("Sağ-Aşağı")) return true; } //Sağ-Aşağı arada taş yoksa
                    else if (hamleKomut[1] == sutun - 1 && hamleKomut[2] == satir + 1 || hamleKomut[1] == sutun - 2 && hamleKomut[2] == satir + 2 || hamleKomut[1] == sutun - 3 && hamleKomut[2] == satir + 3
                            || hamleKomut[1] == sutun - 4 && hamleKomut[2] == satir + 4 || hamleKomut[1] == sutun - 5 && hamleKomut[2] == satir + 5 || hamleKomut[1] == sutun - 6 && hamleKomut[2] == satir + 6
                            || hamleKomut[1] == sutun - 7 && hamleKomut[2] == satir + 7) { if (!aradaTasVarMi("Sol-Yukarı")) return true; } // Sol-Yukarı arada taş yoksa
                    else if (hamleKomut[1] == sutun - 1 && hamleKomut[2] == satir - 1 || hamleKomut[1] == sutun - 2 && hamleKomut[2] == satir - 2 || hamleKomut[1] == sutun - 3 && hamleKomut[2] == satir - 3
                            || hamleKomut[1] == sutun - 4 && hamleKomut[2] == satir - 4 || hamleKomut[1] == sutun - 5 && hamleKomut[2] == satir - 5 || hamleKomut[1] == sutun - 6 && hamleKomut[2] == satir - 6
                            || hamleKomut[1] == sutun - 7 && hamleKomut[2] == satir - 7) { if (!aradaTasVarMi("Sol-Aşağı")) return true; } // Sol-Aşağı arada taş yoksa

                    else if (sutun >= 'i' && sutun <= 'p')
                    {
                            if (hamleKomut[1] == sutun - 7 && hamleKomut[2] == satir - 2 || hamleKomut[1] == sutun - 6 && hamleKomut[2] == satir - 1 || hamleKomut[1] == sutun - 5 && hamleKomut[2] == satir
                                || hamleKomut[1] == sutun - 4 && hamleKomut[2] == satir + 1 || hamleKomut[1] == sutun - 3 && hamleKomut[2] == satir + 2 || hamleKomut[1] == sutun - 2 && hamleKomut[2] == satir + 3
                                || hamleKomut[1] == sutun - 1 && hamleKomut[2] == satir + 4) { if (!aradaTasVarMi("Sağ-Yukarı")) return true; } // Kırmızı'dan Sağ-Yukarı arada taş yoksa
                        else if (hamleKomut[1] == sutun - 7 && hamleKomut[2] == satir + 4 || hamleKomut[1] == sutun - 6 && hamleKomut[2] == satir + 3 || hamleKomut[1] == sutun - 5 && hamleKomut[2] == satir + 2
                                || hamleKomut[1] == sutun - 4 && hamleKomut[2] == satir + 1 || hamleKomut[1] == sutun - 3 && hamleKomut[2] == satir || hamleKomut[1] == sutun - 2 && hamleKomut[2] == satir - 1
                                || hamleKomut[1] == sutun - 1 && hamleKomut[2] == satir - 2) { if (!aradaTasVarMi("Sağ-Aşağı")) return true; } // Turuncu'dan Sağ-Aşağı arada taş yoksa
                        else if (hamleKomut[1] == sutun - 9 && hamleKomut[2] == satir - 2 || hamleKomut[1] == sutun - 10 && hamleKomut[2] == satir - 1 || hamleKomut[1] == sutun - 11 && hamleKomut[2] == satir
                                || hamleKomut[1] == sutun - 12 && hamleKomut[2] == satir + 1 || hamleKomut[1] == sutun - 13 && hamleKomut[2] == satir + 2 || hamleKomut[1] == sutun - 14 && hamleKomut[2] == satir + 3
                                || hamleKomut[1] == sutun - 15 && hamleKomut[2] == satir + 4) { if (!aradaTasVarMi("Sol-Yukarı")) return true; } // Kırmızı'dan Sol-Yukarı arada taş yoksa
                        else if (hamleKomut[1] == sutun - 9 && hamleKomut[2] == satir + 4 || hamleKomut[1] == sutun - 10 && hamleKomut[2] == satir + 3 || hamleKomut[1] == sutun - 11 && hamleKomut[2] == satir + 2
                                || hamleKomut[1] == sutun - 12 && hamleKomut[2] == satir + 1 || hamleKomut[1] == sutun - 13 && hamleKomut[2] == satir || hamleKomut[1] == sutun - 14 && hamleKomut[2] == satir - 1
                                || hamleKomut[1] == sutun - 15 && hamleKomut[2] == satir - 2) { if (!aradaTasVarMi("Sol-Aşağı")) return true; } // Turuncu'dan Sol-Aşağı arada taş yoksa
                    }
                    else if (sutun >= 'q' && sutun <= 'x')
                    {
                            if (hamleKomut[1] == sutun - 16 && hamleKomut[2] == satir + 4 || (hamleKomut[1] == sutun - 15 || hamleKomut[1] == sutun - 17) && hamleKomut[2] == satir + 3 || (hamleKomut[1] == sutun - 14 || hamleKomut[1] == sutun - 16 || hamleKomut[1] == sutun - 18) && hamleKomut[2] == satir + 2
                                || (hamleKomut[1] == sutun - 13 || hamleKomut[1] == sutun - 15 || hamleKomut[1] == sutun - 17 || hamleKomut[1] == sutun - 19) && hamleKomut[2] == satir + 1 || (hamleKomut[1] == sutun - 12 || hamleKomut[1] == sutun - 14 || hamleKomut[1] == sutun - 16 || hamleKomut[1] == sutun - 18 || hamleKomut[1] == sutun - 20) && hamleKomut[2] == satir
                                || (hamleKomut[1] == sutun - 11 || hamleKomut[1] == sutun - 13 || hamleKomut[1] == sutun - 15 || hamleKomut[1] == sutun - 17 || hamleKomut[1] == sutun - 19 || hamleKomut[1] == sutun - 21) && hamleKomut[2] == satir - 1
                                || (hamleKomut[1] == sutun - 10 || hamleKomut[1] == sutun - 12 || hamleKomut[1] == sutun - 14 || hamleKomut[1] == sutun - 16 || hamleKomut[1] == sutun - 18 || hamleKomut[1] == sutun - 20 || hamleKomut[1] == sutun - 22) && hamleKomut[2] == satir - 2) { if (!aradaTasVarMi("Sağ-Yukarı")) return true; } // Mavi'den Sağ-Yukarı arada taş yoksa
                        else if (hamleKomut[1] == sutun - 9 && hamleKomut[2] == satir + 3 || hamleKomut[1] == sutun - 10 && hamleKomut[2] == satir + 2 || hamleKomut[1] == sutun - 11 && hamleKomut[2] == satir + 1
                                || hamleKomut[1] == sutun - 12 && hamleKomut[2] == satir || hamleKomut[1] == sutun - 13 && hamleKomut[2] == satir - 1 || hamleKomut[1] == sutun - 14 && hamleKomut[2] == satir - 2
                                || hamleKomut[1] == sutun - 15 && hamleKomut[2] == satir - 3) { if (!aradaTasVarMi("Sağ-Aşağı")) return true; } // Yeşil'den Sağ-Aşağı arada taş yoksa
                        else if (hamleKomut[1] == sutun - 23 && hamleKomut[2] == satir - 1 || hamleKomut[1] == sutun - 22 && hamleKomut[2] == satir || hamleKomut[1] == sutun - 21 && hamleKomut[2] == satir + 1
                                || hamleKomut[1] == sutun - 20 && hamleKomut[2] == satir + 2 || hamleKomut[1] == sutun - 19 && hamleKomut[2] == satir + 3 || hamleKomut[1] == sutun - 18 && hamleKomut[2] == satir + 4
                                || hamleKomut[1] == sutun - 17 && hamleKomut[2] == satir + 5) { if (!aradaTasVarMi("Sağ-Aşağı")) return true; } // Mavi'den Sol-Yukarı arada taş yoksa
                        else if (hamleKomut[1] == sutun - 16 && hamleKomut[2] == satir - 2 || (hamleKomut[1] == sutun - 17 || hamleKomut[1] == sutun - 15) && hamleKomut[2] == satir - 1 || (hamleKomut[1] == sutun - 18 || hamleKomut[1] == sutun - 16 || hamleKomut[1] == sutun - 14) && hamleKomut[2] == satir
                                || (hamleKomut[1] == sutun - 19 || hamleKomut[1] == sutun - 17 || hamleKomut[1] == sutun - 15 || hamleKomut[1] == sutun - 13) && hamleKomut[2] == satir + 1 || (hamleKomut[1] == sutun - 20 || hamleKomut[1] == sutun - 18 || hamleKomut[1] == sutun - 16 || hamleKomut[1] == sutun - 14 || hamleKomut[1] == sutun - 12) && hamleKomut[2] == satir + 2
                                || (hamleKomut[1] == sutun - 21 || hamleKomut[1] == sutun - 19 || hamleKomut[1] == sutun - 17 || hamleKomut[1] == sutun - 15 || hamleKomut[1] == sutun - 13 || hamleKomut[1] == sutun - 11) && hamleKomut[2] == satir + 3
                                || (hamleKomut[1] == sutun - 22 || hamleKomut[1] == sutun - 20 || hamleKomut[1] == sutun - 18 || hamleKomut[1] == sutun - 16 || hamleKomut[1] == sutun - 14 || hamleKomut[1] == sutun - 12 || hamleKomut[1] == sutun - 10) && hamleKomut[2] == satir + 4) { if (!aradaTasVarMi("Sağ-Aşağı")) return true; } // Yeşil'den Sol-Aşağı arada taş yoksa
                    }
                    break;
            }

            return false;
        }

        public bool aradaTasVarMi(string yon)
        {
            string[] ayir = yon.Split('-');
            List<string> yonler = new List<string>();

            if (ayir.Count() == 1) { yonler.Add(ayir[0]); yonler.Add(""); }
            else if (ayir.Count() == 2) { yonler.Add(ayir[0]); yonler.Add(ayir[1]); }

            List<char> satirlar = new List<char>(); satirlar.Add(satir);
            List<char> sutunlar = new List<char>(); sutunlar.Add(sutun);

            var notasyonDefteri = db.satrancTahtalari.Where(x => x.ID == odaNo).FirstOrDefault().hamleler.OrderByDescending(u => u.ID);

            if (odaTuru == 1)
            {
                if (yonler[0] == "Yukarı" || yonler[1] == "Yukarı") for (char n = (char)(satir + 1); n <= (char)(hamleKomut[2] - 1); n++) satirlar.Add(n);
                else if (yonler[0] == "Aşağı" || yonler[1] == "Aşağı") for (char n = (char)(satir - 1); n >= (char)(hamleKomut[2] + 1); n--) satirlar.Add(n);
                if (yonler[0] == "Sağ") for (char n = (char)(sutun + 1); n <= (char)(hamleKomut[1] - 1); n++) sutunlar.Add(n);
                else if (yonler[0] == "Sol") for (char n = (char)(sutun - 1); n >= (char)(hamleKomut[1] + 1); n--) sutunlar.Add(n);

                    foreach (var aralik1 in satirlar) foreach (var aralik2 in sutunlar)
                    {
                        if (aralik1 == satirlar.ElementAt(0) && aralik2 == sutunlar.ElementAt(0)) continue;

                            hamleler varMi = notasyonDefteri.Where(y => y.notasyon.ToCharArray()[y.notasyon.Length - 1] == aralik1 && y.notasyon.ToCharArray()[y.notasyon.Length - 2] == aralik2).FirstOrDefault();
                            hamleler halaOrdaMi = notasyonDefteri.Where(y => y.pozisyon.ToCharArray()[y.pozisyon.Length - 1] == aralik1 && y.pozisyon.ToCharArray()[y.pozisyon.Length - 2] == aralik2).FirstOrDefault();

                        if (varMi != null && halaOrdaMi != null && halaOrdaMi.ID > varMi.ID) return true;
                    }
            }
            else if (odaTuru == 2)
            {

            }

            return false;
        }

        public void notasyonGonder()
        {
            var hamle = db.hamleler.Add(new hamleler { notasyon = notasyon, pozisyon = pozisyon, odaNo = odaNo });
            int puan = 0;

            if (yenenTas != "-")
                if (yenenTas == "Ş") puan = 99;
                else if (yenenTas == "V") puan = 9;
                else if (yenenTas == "F") puan = 3;
                else if (yenenTas == "A") puan = 3;
                else if (yenenTas == "K") puan = 5;
                else puan = 1;

            if (tasRenk == 1)
            {
                db.satrancTahtalari.Find(odaNo).kullanicilar.ELO += puan;
                db.satrancTahtalari.Find(odaNo).kullanicilar1.ELO -= puan;
            }
            else if (tasRenk == 0)
            {
                db.satrancTahtalari.Find(odaNo).kullanicilar.ELO -= puan;
                db.satrancTahtalari.Find(odaNo).kullanicilar1.ELO += puan;
            }

            if (yenenTas == "Ş") // Şah yeniyorsa
            {
                db.hamleler.RemoveRange(db.hamleler.Where(w => w.odaNo == odaNo)); // Hamleleri sil
                db.satrancTahtalari.Remove(db.satrancTahtalari.Where(w => w.ID == odaNo).FirstOrDefault()); // Odayı sil.
            }

            db.SaveChanges();
        }

        public NotasyonGetir notasyonGetir(int tasRenk)
        {
            string notasyon = "", pozisyon = "", yeniHucre = "";
            char tasCik = '-';
            bool sahCek = false;
            string rok = "";

            var hamleler = db.hamleler.Where(s => s.odaNo == odaNo).OrderByDescending(s => s.ID);
            var hamle = hamleler.FirstOrDefault();
            notasyon = hamle.notasyon;
            pozisyon = hamle.pozisyon;

            if (hamle == null) return null;

            char[] notasyonParca = notasyon.ToCharArray();

            // NOTASYON KONTROL BAŞLANGICI = TAŞIN ESKİ HÜCRESİ => TAŞIN YENİ HÜCRESİ //
            if (notasyonParca[0] == 'Ş' || notasyonParca[0] == 'V' || notasyonParca[0] == 'F' || notasyonParca[0] == 'A' || notasyonParca[0] == 'K') // Şah, Vezir, Fil, At veya Kale;
                if (notasyonParca[1] == 'x' || notasyon.ToCharArray()[1] == '+')
                {
                    yeniHucre = (notasyonParca[2] + "" + notasyonParca[3]);   // Bir taşı yiyor veya şah çekiyorsa yeniPozisyonu
                    if (notasyonParca[1] == '+') sahCek = true;
                }
                else yeniHucre = (notasyonParca[1] + "" + notasyonParca[2]);       // Yer değiştiriyorsa yeniPozisyonu
            else        // Taş piyon ise;    
                if (notasyonParca.Count() >= 3 && (notasyonParca[2] == 'x' || notasyon.ToCharArray()[2] == '+'))
            {
                yeniHucre = (notasyonParca[3] + "" + notasyonParca[4]);       // Bir taşı yiyor veya şah çekiyorsa yeniPozisyonu
                if (notasyonParca[2] == '+') sahCek = true;
            }
            else
            {
                yeniHucre = (notasyonParca[0] + "" + notasyonParca[1]);       // Yer değiştiriyorsa yeniPozisyonu
                if (notasyonParca.Count() >= 3 && (notasyonParca[2] == 'V' || notasyonParca[2] == 'K')) tasCik = notasyonParca[2];
            }    // Piyon Vezir veya Kale taşı çıkıyorsa
                 // NOTASYON KONTROL BİTİŞİ = TAŞIN ESKİ HÜCRESİ => TAŞIN YENİ HÜCRESİ //

                    if (hamle.notasyon == "O-O") { yeniHucre = (char)(hamle.pozisyon[0] + 3) + "" + hamle.pozisyon[1]; rok = "O-O"; }// Küçük Rok
                    else if (hamle.notasyon == "O-O-O") { yeniHucre = (char)(hamle.pozisyon[0] - 4) + "" + hamle.pozisyon[1]; rok = "O-O-O"; } // Büyük Rok

            char yenenTas = notasyonParca[1] == 'x' || notasyonParca.Count() >= 3 && notasyonParca[2] == 'x' ? hamleler.Where(s => s.notasyon.EndsWith(yeniHucre)).ToList().ElementAt(1).notasyon.ToCharArray()[0] : '-';
            int puan = 0;
                if (yenenTas != '-')
                    if (yenenTas == 'Ş') puan = 99;
                    else if (yenenTas == 'V') puan = 9;
                    else if (yenenTas == 'F') puan = 3;
                    else if (yenenTas == 'A') puan = 3;
                    else if (yenenTas == 'K') puan = 5;
                    else puan = 1;

                if (tasRenk == 1)
                {
                    db.satrancTahtalari.Find(odaNo).kullanicilar.ELO += puan;
                    db.satrancTahtalari.Find(odaNo).kullanicilar1.ELO -= puan;
                }
                else if (tasRenk == 0)
                {
                    db.satrancTahtalari.Find(odaNo).kullanicilar.ELO -= puan;
                    db.satrancTahtalari.Find(odaNo).kullanicilar1.ELO += puan;
                } db.SaveChanges();

            return new NotasyonGetir  {

                eskiPozisyon = pozisyon,
                yeniPozisyon = yeniHucre,
                tasCikma = tasCik,
                sahCekme = sahCek,
                rokTuru = rok

            };

        }

        public class NotasyonGetir
        {
            public string eskiPozisyon { get; set; }
            public string yeniPozisyon { get; set; }
            public char tasCikma { get; set; }
            public bool sahCekme { get; set; }
            public string rokTuru { get; set; }
        }

    }
}