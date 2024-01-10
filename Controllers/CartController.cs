using Microsoft.AspNetCore.Mvc;
using AspNetCoreHero.ToastNotification.Abstractions;
using WebThoiTrang.ModelViews;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using WebThoiTrang.Models;
using WebThoiTrang.Extensions;

namespace WebThoiTrang.Controllers
{
	public class CartController : Controller
	{
		private readonly ShopquanaoContext _context;
		public INotyfService notyfService { get;  }
		public CartController(ShopquanaoContext context, INotyfService notyfService)
		{
			_context = context;
			notyfService = notyfService;
		}

		public List<CartItem> GioHang
		{
			get
			{
				var cartItems = HttpContext.Session.Get<List<CartItem>>("Giohang");
				var gh = cartItems;
				if (gh == null)
				{
					return new List<CartItem>();
				}
				return gh;
			}
		}
		

		public IActionResult Index()
		{
			return View();
		}
	}
}
