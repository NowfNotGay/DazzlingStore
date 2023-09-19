using System;
using System.Collections.Generic;

namespace DazzlingStore.Models;

public partial class Voucher
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string VarietyCode { get; set; } = null!;

    public decimal Discount { get; set; }

    public decimal Condition { get; set; }

    public int Quantity { get; set; }

    public DateTime TimeStart { get; set; }

    public DateTime TimeEnd { get; set; }

    public bool? Status { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
