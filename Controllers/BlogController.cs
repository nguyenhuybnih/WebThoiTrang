using Microsoft.AspNetCore.Mvc;
using WebThoiTrang.Models;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;

namespace WebThoiTrang.Controllers
{
	public class BlogController : Controller
	{
		private readonly ShopquanaoContext _context;

		public BlogController(ShopquanaoContext context)
		{
			_context = context;
		}
		public IActionResult Index(int? page)
		{	
			
			var pageNumber = page == null || page <= 0 ? 1 : page.Value;
			var pageSize = 1;
			var lsBlog = _context.Blogs.AsNoTracking().OrderByDescending(x => x.BlogId);
			PagedList<Blog> models = new PagedList<Blog>(lsBlog, pageNumber, pageSize);

			ViewBag.CurrentPage = pageNumber;
			return View(models);
			
		}
		[Route("/Blog/{Alias}-{id}.html", Name = "TinDetails")]
		public IActionResult Details(int id)
		{
			var Bl = _context.Blogs.AsNoTracking().SingleOrDefault(x => x.BlogId == id);
			if (Bl == null)
			{
				return Redirect("Index");
			}
			return View(Bl);
		}

	}
}
