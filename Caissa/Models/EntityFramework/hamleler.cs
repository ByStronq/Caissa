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
    
    public partial class hamleler
    {
        public int ID { get; set; }
        public string notasyon { get; set; }
        public string pozisyon { get; set; }
        public int odaNo { get; set; }
    
        public virtual satrancTahtalari satrancTahtalari { get; set; }
    }
}
