using WebThoiTrang.Models;
using Microsoft.AspNetCore.Mvc;
namespace WebThoiTrang.Components
{
    [ViewComponent(Name = "MenuView")]
    public class MenuViewComponent : ViewComponent
    {
        private  ShopquanaoContext _context;

        public MenuViewComponent(ShopquanaoContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
			var items = _context.Menus.Where(m => (bool)m.IsActive).OrderBy(m => m.Position).ToList();
			return await Task.FromResult((IViewComponentResult)View("Default", items));
        }
    }
}
