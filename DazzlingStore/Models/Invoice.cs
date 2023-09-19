using System;
using System.Collections.Generic;

namespace DazzlingStore.Models;

public partial class Invoice
{
    public int Id { get; set; }

    public int InvoiceNumber { get; set; }

    public int? PaymentMethodId { get; set; }

    public int AccountId { get; set; }

    public decimal? TotalAmount { get; set; }

    public DateTime? InvoiceDate { get; set; }

    public DateTime? DueDate { get; set; }

    public bool Status { get; set; }

    public string? Description { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual PaymentMethod? PaymentMethod { get; set; }
}
