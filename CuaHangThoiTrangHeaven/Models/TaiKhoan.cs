namespace Mvc.Models
{
    using System;
    using System.Collections.Generic;

    public partial class TaiKhoan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TaiKhoan()
        {
            this.KhachHangs = new HashSet<KhachHang>();
            this.NhanViens = new HashSet<NhanVien>();
        }

        public int MaTaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string LoaiTaiKhoan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KhachHang> KhachHangs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}
