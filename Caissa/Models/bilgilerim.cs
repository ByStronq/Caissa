using System;
using System.Linq;
using Caïssa.Models.EntityFramework;

namespace Caïssa.Models
{
    public class bilgilerim
    {
        public kullanicilar getir()
        {
            OnlineSatrancEntities db = new OnlineSatrancEntities();
            kullanicilar kullanici = db.kullanicilar.Where(s => s.kAdi == Properties.Settings.Default.kAdi).FirstOrDefault();

            return kullanici;
        }
    }
}
