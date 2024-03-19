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

		
		

		public IActionResult Index()
		{
			return View();
		}
	}
}
