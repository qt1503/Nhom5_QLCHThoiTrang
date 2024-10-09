using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebHeavenOnline.Models;
using WebHeavenOnline.Models.EF;

namespace WebHeavenOnline.Controllers
{
	public class ProductController : Controller
	{
		private readonly ApplicationDbContext _context; // Giả sử bạn đang sử dụng EF Core hoặc DbContext nào đó

		public ProductController(ApplicationDbContext context)
		{
			_context = context;
		}

		// Action tìm kiếm sản phẩm
		[HttpGet]
		public ActionResult Search(string keyword)
		{
			if (string.IsNullOrEmpty(keyword))
			{
				return View(new List<Product>()); // Trả về một danh sách rỗng nếu từ khóa trống
			}

			var products = _context.Products
				.Where(p => p.Title.Contains(keyword) || p.Description.Contains(keyword))
				.ToList();

			return View(products); // Trả về view với danh sách sản phẩm tìm được
		}
	}
}