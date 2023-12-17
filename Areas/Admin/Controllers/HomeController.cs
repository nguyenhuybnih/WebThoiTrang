using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebThoiTrang.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
