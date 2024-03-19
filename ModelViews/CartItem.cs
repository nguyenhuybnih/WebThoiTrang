using WebThoiTrang.Models;
namespace WebThoiTrang.ModelViews
{
	public class CartItem
	{
		public Product pr { get; set; }
		public int amount { get; set; }
		public double total => amount * pr.Price.Value;
		public double total => amount * pr.Price.Value;
	}
}
