//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLCHThoiTrang.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class LoaiKH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiKH()
        {
            this.KhachHangs = new HashSet<KhachHang>();
        }
    
        public string MaLoaiKH { get; set; }
        public string TenLoaiKH { get; set; }
        public Nullable<double> UuDai { get; set; }
        public string ChiTiet { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KhachHang> KhachHangs { get; set; }
    }
}
