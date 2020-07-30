using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Caïssa.Models.EntityFramework;
using System.Security.Cryptography;

namespace Caïssa
{
    public partial class KayitOl : Form
    {
        private Form1 frm1;
        public KayitOl()
        {
            InitializeComponent();
        }

        private void kayitBtn_Click(object sender, EventArgs e)
        {
            frm1 = Application.OpenForms.OfType<Form1>().SingleOrDefault();
            string pwPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";
            string eMailPattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            string telNoPattern = @"^[0][1-9]\d{9}$|^[1-9]\d{9}$";
            OnlineSatrancEntities db = new OnlineSatrancEntities();
            if (String.IsNullOrEmpty(ad.Text) ||
                String.IsNullOrEmpty(soyad.Text) ||
                String.IsNullOrEmpty(kAdi.Text) ||
                String.IsNullOrEmpty(sifre.Text) ||
                String.IsNullOrEmpty(ePosta.Text) ||
                String.IsNullOrEmpty(gsm.Text)) MessageBox.Show("Boş alan bırakmayınız!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (!Regex.IsMatch(sifre.Text, pwPattern)) MessageBox.Show("Şifreniz şunları içermelidir:" + "\n" + 
                                                                            "- En az sekiz karakter" + "\n" + 
                                                                            "- En az bir büyük harf (A-Z)" + "\n" +
                                                                            "- Bir küçük harf (a-z)" + "\n" +
                                                                            "- Bir sayı (0-9)" + "\n" +
                                                                            "- Bir özel karakter (@$!%*?&)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (!Regex.IsMatch(ePosta.Text, eMailPattern)) MessageBox.Show("Geçerli bir e-Posta adresi giriniz!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (!Regex.IsMatch(gsm.Text, telNoPattern)) MessageBox.Show("Geçerli bir telefon numarası giriniz!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (!erkek.Checked && !kadin.Checked) MessageBox.Show("Cinsiyet seçiniz!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (db.kullanicilar.Where(s => s.kAdi == kAdi.Text).Count() > 0) MessageBox.Show("Bu kullanıcı adı daha önce alınmış!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (db.kullanicilar.Where(s => s.ePosta == ePosta.Text).Count() > 0) MessageBox.Show("Bu e-posta adresi kullanımda!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (db.kullanicilar.Where(s => s.gsm == gsm.Text).Count() > 0) MessageBox.Show("Bu telefon numarası kullanımda!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                kullanicilar kullanicilar = new kullanicilar();

                kullanicilar.Ad = ad.Text;
                kullanicilar.Soyad = soyad.Text;
                kullanicilar.kAdi = kAdi.Text;
                kullanicilar.ePosta = ePosta.Text;

                UTF8Encoding utf8 = new UTF8Encoding();
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
                kullanicilar.sifre = BitConverter.ToString(md5.ComputeHash(utf8.GetBytes(BitConverter.ToString(sha1.ComputeHash(utf8.GetBytes(sifre.Text))))));
                kullanicilar.gsm = gsm.Text;
                kullanicilar.dgmTarihi = dgmTarihi.Value;

                if (erkek.Checked) kullanicilar.cinsiyet = true;
                else if (kadin.Checked) kullanicilar.cinsiyet = false;

                db.kullanicilar.Add(kullanicilar);
                db.SaveChanges(); MessageBox.Show("Kayıt Başarılı!");
                Properties.Settings.Default.kAdi = null;
                Properties.Settings.Default.sifre = null;
                Properties.Settings.Default.Save();
                this.Close();
                frm1.openChildForm(new GirisYap());
            }
        }

        private void geriDon_Click(object sender, EventArgs e)
        {
            frm1 = Application.OpenForms.OfType<Form1>().SingleOrDefault();
            frm1.openChildForm(new GirisYap());
        }
    }
}
