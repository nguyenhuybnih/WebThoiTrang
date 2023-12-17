using System;
using System.Collections.Generic;

namespace WebThoiTrang.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string? Title { get; set; }

    public string? Alias { get; set; }

    public int? CategoryProductId { get; set; }

    public string? Description { get; set; }

    public string? Detail { get; set; }

    public string? Image { get; set; }

    public int? Price { get; set; }

    public int? Quantity { get; set; }

    public string? Size { get; set; }

    public string? Color { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public bool IsNew { get; set; }

    public bool IsBestSeller { get; set; }

    public int? UnitInStock { get; set; }

    public bool IsActive { get; set; }

    public virtual ProductCategory? CategoryProduct { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
