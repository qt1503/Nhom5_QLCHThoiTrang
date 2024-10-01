using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CuaHangThoiTrangHeaven.Models;

namespace CuaHangThoiTrangHeaven.Controllers
{
    public class TaiKhoansController : Controller
    {
        private QuanLyCuaHangThoiTrang3Entities db = new QuanLyCuaHangThoiTrang3Entities();

        // GET: TaiKhoans
        public async Task<ActionResult> Index()
        {
            return View(await db.TaiKhoans.ToListAsync());
        }

        // GET: TaiKhoans/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiKhoan taiKhoan = await db.TaiKhoans.FindAsync(id);
            if (taiKhoan == null)
            {
                return HttpNotFound();
            }
            return View(taiKhoan);
        }

        // GET: TaiKhoans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TaiKhoans/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MaTaiKhoan,MatKhau,SoDienThoai,Email,LoaiTaiKhoan")] TaiKhoan taiKhoan)
        {
            if (ModelState.IsValid)
            {
                db.TaiKhoans.Add(taiKhoan);
                await db.SaveChangesAsync();
                return RedirectToAction("Login");
            }

            return View(taiKhoan);
        }

        // GET: TaiKhoans/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiKhoan taiKhoan = await db.TaiKhoans.FindAsync(id);
            if (taiKhoan == null)
            {
                return HttpNotFound();
            }
            return View(taiKhoan);
        }

        // POST: TaiKhoans/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MaTaiKhoan,MatKhau,SoDienThoai,Email,LoaiTaiKhoan")] TaiKhoan taiKhoan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taiKhoan).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(taiKhoan);
        }

        // GET: TaiKhoans/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiKhoan taiKhoan = await db.TaiKhoans.FindAsync(id);
            if (taiKhoan == null)
            {
                return HttpNotFound();
            }
            return View(taiKhoan);
        }

        // POST: TaiKhoans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TaiKhoan taiKhoan = await db.TaiKhoans.FindAsync(id);
            db.TaiKhoans.Remove(taiKhoan);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Login()
        {
            return View();
        }

        // POST: TaiKhoans/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string emailOrPhone, string matkhau)
        {
            // Check if the model state is valid
            if (ModelState.IsValid)
            {
                // Check if the user exists with the given email or phone number and password
                var user = db.TaiKhoans
                             .FirstOrDefault(t => (t.Email == emailOrPhone || t.SoDienThoai == emailOrPhone) && t.MatKhau == matkhau);

                // If user is not found, set an error message
                if (user == null)
                {
                    ViewBag.error = "Sai tên đăng nhập hoặc mật khẩu";
                    return View(); // Return the view to show the error
                }

                // If user is found, store user information in the session
                Session["LoggedInUser"] = user.Email ?? user.SoDienThoai; // Use email or phone number
                Session["UserId"] = user.MaTaiKhoan; // Store user ID in session if needed

                // Redirect to the home page after successful login
                return RedirectToAction("Index", "Home");
            }

            // If model state is invalid or the user is not found, return the login view
            ModelState.AddModelError("", "Thông tin đăng nhập không chính xác.");
            return View(); // Return to the login view to show errors
        }
    }
}
