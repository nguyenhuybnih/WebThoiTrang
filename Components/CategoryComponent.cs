using Microsoft.AspNetCore.Mvc;
using WebThoiTrang.Models;

namespace WebThoiTrang.Components
{
	[ViewComponent(Name = "MenuLoaiSp")]

	public class CategoryComponent : ViewComponent
	{
		private ShopquanaoContext _context;

		public CategoryComponent(ShopquanaoContext context)
		{
			_context = context;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var item1 = _context.ProductCategories.Where(m => (bool)m.IsActive).OrderBy(m => m.Position).ToList();
			return await Task.FromResult((IViewComponentResult)View("Default", item1));
		}
	}
}
