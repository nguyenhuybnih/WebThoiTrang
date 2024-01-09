using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using WebThoiTrang.Models;

namespace WebThoiTrang.Controllers
{
	public class CategoryController : Controller
	{
		private readonly ShopquanaoContext _context;
		public CategoryController(ShopquanaoContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult Sphamtheoloai(int cateid, int? page)
		{
			var pageNumber = page == null || page <= 0 ? 1 : page.Value;
			var pageSize = 5;
			var lsPro = _context.Products.AsNoTracking().Where(x => x.CategoryProductId == cateid).OrderByDescending(x => x.ProductId);
			PagedList<Product> sp = new PagedList<Product>(lsPro, pageNumber, pageSize);
			ViewBag.cateid = cateid;
			
			return View(sp);
		}
	}
}
