using Microsoft.AspNetCore.Mvc;
using WebThoiTrang.Models;

namespace WebThoiTrang.Controllers
{
    public class ContactController : Controller
    {
        private readonly ShopquanaoContext _context;

        public ContactController(ShopquanaoContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

		[HttpPost]
		public async Task<bool> Create(string Email, string Phone, string Message)
		{
			try
			{
				Contact contact = new Contact();
				contact.Email = Email;
				contact.Phone = Phone;
				contact.Message = Message;
				contact.CreatedDate = DateTime.Now;
				_context.Add(contact);
				await _context.SaveChangesAsync();
				return true;
			}
			catch
			{
				return false;
			}

		}
	}
}
