using Microsoft.AspNetCore.Mvc;

namespace WebThoiTrang.Controllers
{
    public class Cart : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
