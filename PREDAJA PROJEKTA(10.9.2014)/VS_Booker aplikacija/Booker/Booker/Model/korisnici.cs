//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Booker.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class korisnici
    {
        public korisnici()
        {
            this.knjiga = new HashSet<knjiga>();
            this.komentari = new HashSet<komentari>();
            this.posudba = new HashSet<posudba>();
            this.posudba1 = new HashSet<posudba>();
        }
    
        public int id_korisnici { get; set; }
        public string kor_ime { get; set; }
        public string lozinka { get; set; }
        public string email { get; set; }
        public int pravaid_prava { get; set; }
    
        public virtual ICollection<knjiga> knjiga { get; set; }
        public virtual ICollection<komentari> komentari { get; set; }
        public virtual prava prava { get; set; }
        public virtual ICollection<posudba> posudba { get; set; }
        public virtual ICollection<posudba> posudba1 { get; set; }
    }
}