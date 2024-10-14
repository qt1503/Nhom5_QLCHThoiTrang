
using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using QLCHThoiTrang.Models;

namespace QLCHThoiTrang.Controllers
{
    public class ProductController : Controller
    {
        private readonly QuanLyCuaHangThoiTrangEntities db; // Đánh dấu là readonly

        public ProductController()
        {
            db = new QuanLyCuaHangThoiTrangEntities(); // Gán giá trị trong constructor
        }

        // GET: SanPhams
        public ActionResult Index()
        {
            var sanPhams = db.SanPhams.Include(s => s.DanhMuc);
            return View(sanPhams.ToList());
        }

        // GET: SanPhams/Details
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            SanPham sanPham = db.SanPhams.Include(s => s.DanhMuc).FirstOrDefault(s => s.MaSP == id);

            if (sanPham == null)
            {
                return HttpNotFound();
            }

            return View(sanPham);
        }

        // GET: SanPhams/Create
        public ActionResult Create()
        {
            ViewBag.MaDM = new SelectList(db.DanhMucs, "MaDM", "TenDanhMuc");
            return View();
        }

        // POST: SanPhams/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TenSP,ChiTiet,GiaBan,SoLuong,HinhAnh,MaDM")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                // Sinh MaSP tự động nếu không sử dụng DatabaseGeneratedOption.Identity
                sanPham.MaSP = Guid.NewGuid().ToString();

                try
                {
                    db.SanPhams.Add(sanPham);
                    db.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var validationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            Console.WriteLine("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                        }
                    }
                }
                return RedirectToAction("Index");
            }

            ViewBag.MaDM = new SelectList(db.DanhMucs, "MaDM", "TenDanhMuc", sanPham.MaDM);
            return View(sanPham);
        }


        // GET: SanPhams/Edit
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            SanPham sanPham = db.SanPhams.Find(id);

            if (sanPham == null)
            {
                return HttpNotFound();
            }

            ViewBag.MaDM = new SelectList(db.DanhMucs, "MaDM", "TenDanhMuc", sanPham.MaDM);
            return View(sanPham);
        }

        // POST: SanPhams/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSP,TenSP,ChiTiet,GiaBan,SoLuong,HinhAnh,MaDM")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDM = new SelectList(db.DanhMucs, "MaDM", "TenDanhMuc", sanPham.MaDM);
            return View(sanPham);
        }

        
        

        // Dispose
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
