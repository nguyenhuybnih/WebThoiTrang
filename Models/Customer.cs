﻿using System;
using System.Collections.Generic;

namespace WebThoiTrang.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public DateTime? Birthday { get; set; }

    public string? Avatar { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public DateTime? LastLogin { get; set; }

    public bool IsActive { get; set; }
}
