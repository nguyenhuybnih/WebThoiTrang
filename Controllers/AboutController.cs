using Microsoft.AspNetCore.Mvc;
using WebThoiTrang.Models;

namespace WebThoiTrang.Controllers
{
	public class AboutController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
