//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace mvcstokyucedag.Models.entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblurunler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblurunler()
        {
            this.tblsatis = new HashSet<tblsatis>();
        }
    
        public int urunID { get; set; }
        public string urunad { get; set; }
        public string urunmarka { get; set; }
        public Nullable<short> urunkategori { get; set; }
        public Nullable<decimal> urunfiyat { get; set; }
        public Nullable<byte> urunstok { get; set; }
    
        public virtual tblkategoriler tblkategoriler { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblsatis> tblsatis { get; set; }
    }
}