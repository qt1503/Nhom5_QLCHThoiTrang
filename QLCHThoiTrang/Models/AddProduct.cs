using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLCHThoiTrang.Models
{
    using System;
    using System.Collections.Generic;
    public class AddProduct
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public string ChiTiet { get; set; }
        public Nullable<int> GiaBan { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public IFormFile HinhAnh { get; set; }

        public virtual DanhMuc DanhMuc { get; set; }
    }
}