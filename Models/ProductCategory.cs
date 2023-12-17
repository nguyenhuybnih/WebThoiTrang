using System;
using System.Collections.Generic;

namespace WebThoiTrang.Models;

public partial class ProductCategory
{
    public int CategoryProductId { get; set; }

    public string? Title { get; set; }

    public string? Alias { get; set; }

    public string? Description { get; set; }

    public int? Position { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? Modified { get; set; }

    public string? ModifiedBy { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
