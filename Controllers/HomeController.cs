using WebThoiTrang.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using PagedList.Core;
using Microsoft.EntityFrameworkCore;


namespace WebThoiTrang.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		private readonly ShopquanaoContext _context;
		
		public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _context = new ShopquanaoContext();

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

		/*public IActionResult Sphamtheoloai(int cateid ,int? page)
		{
			var pageNumber = page == null || page <= 0 ? 1 : page.Value;
			var pageSize = 5;
			var lsPro = _context.Products.AsNoTracking().Where(x=>x.CategoryProductId==cateid).OrderByDescending(x => x.ProductId);
			PagedList<Product> sp = new PagedList<Product>(lsPro, pageNumber, pageSize);

			ViewBag.CurrentPage = pageNumber;
			return View(sp);
		}*/


		public IActionResult Privacy()
        {
            return View();
        }
		


		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}