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
    
    public partial class SanPham
    {
        public string MaSP { get; set; } 
        public string TenSP { get; set; } 
        public string ChiTiet { get; set; } 
        public Nullable<int> GiaBan { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public byte[] HinhAnh { get; set; } 
        public string MaDM { get; set; }

        public virtual DanhMuc DanhMuc { get; set; } 
    }
}