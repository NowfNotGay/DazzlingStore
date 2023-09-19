using System;
using System.Collections.Generic;

namespace DazzlingStore.Models;

public partial class Order
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public decimal TotalPrice { get; set; }

    public int StatusId { get; set; }

    public int AddressId { get; set; }

    public int? VoucherId { get; set; }

    public int PaymentMethodId { get; set; }

    public int? InvoiceId { get; set; }

    public DateTime OrderDate { get; set; }

    public DateTime? ShippingDate { get; set; }

    public string? Note { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual AddressProfile Address { get; set; } = null!;

    public virtual Invoice? Invoice { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual PaymentMethod PaymentMethod { get; set; } = null!;

    public virtual OrderStatus Status { get; set; } = null!;

    public virtual Voucher? Voucher { get; set; }
}
