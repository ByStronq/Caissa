using Caïssa.Models;
using Caïssa.Models.EntityFramework;
using Caïssa.Properties;
using System;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Caïssa
{
    public partial class profilim : Form
    {
        private Form1 frm1;
        private kullanicilar bilgilerim = new bilgilerim().getir();
        public profilim()
        {
            InitializeComponent();
        }

        private void profilim_Load(object sender, EventArgs e)
        {
            kAdi.Text = bilgilerim.kAdi;
            rutbeGoster(bilgilerim.ELO, bilgilerim.cinsiyet, rutbeTas, rutbeAd);
            rutbeELO.Text = bilgilerim.ELO.ToString();
            ad.Text = bilgilerim.Ad;
            soyad.Text = bilgilerim.Soyad;
            ePosta.Text = bilgilerim.ePosta;
            gsm.Text = bilgilerim.gsm;
            dgmTarihi.Value = (DateTime) bilgilerim.dgmTarihi;
            
                if (bilgilerim.cinsiyet)
                {
                    erkek.Checked = true;
                    pictureBox1.Image = Resources.img_avatar1;
                }
                else
                {
                    kadin.Checked = true;
                    pictureBox1.Image = Resources.img_avatar2;
                }
        }

        private void GuncelleBtn_Click(object sender, EventArgs e)
        {
            
            frm1 = Application.OpenForms.OfType<Form1>().SingleOrDefault();
            string pwPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";
            string eMailPattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            string telNoPattern = @"^[0][1-9]\d{9}$|^[1-9]\d{9}$";
            OnlineSatrancEntities db = new OnlineSatrancEntities();
            if (String.IsNullOrEmpty(ad.Text) ||
                String.IsNullOrEmpty(soyad.Text) ||
                String.IsNullOrEmpty(kAdi.Text) ||
                String.IsNullOrEmpty(ePosta.Text) ||
                String.IsNullOrEmpty(gsm.Text)) MessageBox.Show("Boş alan bırakmayınız!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (sifre.Text != "" && !Regex.IsMatch(sifre.Text, pwPattern)) MessageBox.Show("Şifreniz şunları içermelidir:" + "\n" + 
                                                                                                "- En az sekiz karakter" + "\n" + 
                                                                                                "- En az bir büyük harf (A-Z)" + "\n" +
                                                                                                "- Bir küçük harf (a-z)" + "\n" +
                                                                                                "- Bir sayı (0-9)" + "\n" +
                                                                                                "- Bir özel karakter (@$!%*?&)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (!Regex.IsMatch(ePosta.Text, eMailPattern)) MessageBox.Show("Geçerli bir e-Posta adresi giriniz!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (!Regex.IsMatch(gsm.Text, telNoPattern)) MessageBox.Show("Geçerli bir telefon numarası giriniz!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                kullanicilar kullanicilar = db.kullanicilar.Where(s => s.ID == bilgilerim.ID).FirstOrDefault();

                kullanicilar.Ad = ad.Text;
                kullanicilar.Soyad = soyad.Text;
                kullanicilar.kAdi = kAdi.Text;
                kullanicilar.ePosta = ePosta.Text;

                UTF8Encoding utf8 = new UTF8Encoding();
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
                kullanicilar.sifre = sifre.Text != "" ? BitConverter.ToString(md5.ComputeHash(utf8.GetBytes(BitConverter.ToString(sha1.ComputeHash(utf8.GetBytes(sifre.Text)))))) : kullanicilar.sifre;
                kullanicilar.gsm = gsm.Text;
                kullanicilar.dgmTarihi = dgmTarihi.Value;

                if (erkek.Checked) kullanicilar.cinsiyet = true;
                else if (kadin.Checked) kullanicilar.cinsiyet = false;

                db.SaveChanges(); MessageBox.Show("Güncelleme Başarılı!");
                Settings.Default.kAdi = null;
                Settings.Default.sifre = null;
                Settings.Default.kAdiHatirla = false;
                Settings.Default.sifreHatirla = false;
                Settings.Default.Save();
                this.Close();
                frm1.openChildForm(new GirisYap());
            }
        }

        private void erkek_CheckedChanged(object sender, EventArgs e)
        {
            if (erkek.Checked) pictureBox1.Image = Resources.img_avatar1;
        }

        private void kadin_CheckedChanged(object sender, EventArgs e)
        {
            if (kadin.Checked) pictureBox1.Image = Resources.img_avatar2;
        }
        private void rutbeGoster(int ELO, bool cinsiyet, PictureBox rutbeTas, Label rutbeAd)
        {
            if (ELO > 0 && ELO < 500) { rutbeTas.Image = Resources.cm; rutbeAd.Text = (cinsiyet ? "" : "W") + "CM"; }
            else if (ELO >= 500 && ELO < 1000) { rutbeTas.Image = Resources.fm; rutbeAd.Text = (cinsiyet ? "" : "W") + "FM"; }
            else if (ELO >= 1000 && ELO < 1500) { rutbeTas.Image = Resources.im; rutbeAd.Text = (cinsiyet ? "" : "W") + "IM"; }
            else if (ELO >= 1500) { rutbeTas.Image = Resources.gm; rutbeAd.Text = (cinsiyet ? "" : "W") + "GM"; }
            else { rutbeTas.Image = null; rutbeAd.Text = "UNRANKED!"; }
        }
    }
}
