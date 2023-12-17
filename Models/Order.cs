﻿using System;
using System.Collections.Generic;

namespace WebThoiTrang.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public string? Code { get; set; }

    public int? TotalAmount { get; set; }

    public int? Quanlity { get; set; }

    public int? OrderStatusId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual OrderStatus? OrderStatus { get; set; }
}
