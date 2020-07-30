using System;
using System.Windows.Forms;
using Caïssa.Models.EntityFramework;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Caïssa
{
    public partial class GirisYap : Form
    {
        private Form1 frm1;
        public GirisYap()
        {
            InitializeComponent();
            Init_Data();
        }

        private void girisBtn_Click(object sender, EventArgs e)
        {
            frm1 = Application.OpenForms.OfType<Form1>().SingleOrDefault();
            UTF8Encoding utf8 = new UTF8Encoding();
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
            string md5SHA1_PW = BitConverter.ToString(md5.ComputeHash(utf8.GetBytes(BitConverter.ToString(sha1.ComputeHash(utf8.GetBytes(sifre.Text))))));
            OnlineSatrancEntities db = new OnlineSatrancEntities();

            if (db.kullanicilar.FirstOrDefault(x => (x.kAdi == kAdi.Text || x.ePosta == kAdi.Text || x.gsm == kAdi.Text) && x.sifre == md5SHA1_PW) != null)
            {
                Save_Data();
                frm1.openChildForm(new Home());

                    /************** BUTONLARIN AKTİF HALE GETİRİLMESİ **************/

                        frm1 .         klasik   .Enabled    =   true;
                        frm1 .  dortluSatranc   .Enabled    =   true;
                        frm1 . takimliSatranc   .Enabled    =   true;
                        frm1 .     soloMacKur   .Enabled    =   true;
                        frm1 .  dortluMacKur    .Enabled    =   true;
                        frm1 .          kolay   .Enabled    =   true;
                        frm1 .           orta   .Enabled    =   true;
                        frm1 .            zor   .Enabled    =   true;
                        
                            if (Properties.Settings.Default.kAdi.ToLower() == "bystrong") 
                                frm1.test.Visible = true;

                    /************** BUTONLARIN AKTİF HALE GETİRİLMESİ **************/
            }
            else
            {
                MessageBox.Show("Giriş Başarısız. (Yanlış Kullanıcı Adı veya Şifre)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                    kAdi.Text = null;
                    sifre.Text = null;
                    kAdiHatirla.Checked = false;
                    sifreHatirla.Checked = false;

                        Properties.Settings.Default.kAdi = null;
                        Properties.Settings.Default.Save();
            }
        }

        private void kayitBtn_Click(object sender, EventArgs e)
        {
            frm1 = Application.OpenForms.OfType<Form1>().SingleOrDefault();
            frm1.openChildForm(new KayitOl());
        }

        private void Init_Data()
        {
            if (Properties.Settings.Default.kAdi != string.Empty)
            {
                if (Properties.Settings.Default.kAdiHatirla)
                {
                    kAdi.Text = Properties.Settings.Default.kAdi;
                    kAdiHatirla.Checked = true;
                }
                else if (Properties.Settings.Default.sifreHatirla)
                {
                    kAdi.Text = Properties.Settings.Default.kAdi;
                    sifre.Text = Properties.Settings.Default.sifre;
                    sifreHatirla.Checked = true;
                }
            }
        }

        private void Save_Data()
        {
            if (kAdiHatirla.Checked)
            {
                Properties.Settings.Default.kAdi = kAdi.Text;
                Properties.Settings.Default.kAdiHatirla = true;
                Properties.Settings.Default.Save();
            }
            else if (sifreHatirla.Checked)
            {
                Properties.Settings.Default.kAdi = kAdi.Text;
                Properties.Settings.Default.sifre = sifre.Text;
                Properties.Settings.Default.kAdiHatirla = false;
                Properties.Settings.Default.sifreHatirla = true;
                Properties.Settings.Default.Save();
            }
        }
    }
}
