//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Caïssa.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class mesajlar
    {
        public int ID { get; set; }
        public int gonderenID { get; set; }
        public int aliciID { get; set; }
        public string mesaj { get; set; }
        public System.DateTime tarih { get; set; }
    
        public virtual kullanicilar kullanicilar { get; set; }
        public virtual kullanicilar kullanicilar1 { get; set; }
    }
}
