using Microsoft.AspNetCore.Mvc;
using WebThoiTrang.Models;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;

namespace WebThoiTrang.Controllers
{
	public class ProductController : Controller
	{
		private readonly ShopquanaoContext _context;
		public ProductController(ShopquanaoContext context)
		{
			_context = context;
		}

		public IActionResult Index(int? page)
		{
			var pageNumber = page == null || page <= 0 ? 1 : page.Value;
			var pageSize = 5;
			var lsPro = _context.Products.AsNoTracking().OrderByDescending(x => x.ProductId);
			PagedList<Product> models = new PagedList<Product>(lsPro, pageNumber, pageSize);

			ViewBag.CurrentPage = pageNumber;
			return View(models);

		}
		[Route("/Product/{Alias}-{id}.html", Name = "Prodetails")]
		public IActionResult Details(int id)
		{
			var Bl = _context.Products.AsNoTracking().SingleOrDefault(x => x.ProductId == id);
			if (Bl == null)
			{
				return Redirect("Index");
			}
			return View(Bl);
		}

	}
}
