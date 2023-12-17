using System;
using System.Collections.Generic;

namespace WebThoiTrang.Models;

public partial class Contact
{
    public int ContactId { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Message { get; set; }

    public int? IsRead { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }
}
