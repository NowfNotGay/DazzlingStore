using System;
using System.Collections.Generic;

namespace DazzlingStore.Models;

public partial class ProductItem
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int SizeId { get; set; }

    public int ColorId { get; set; }

    public int Quantity { get; set; }

    public int Price { get; set; }

    public int Cost { get; set; }

    public int SaleCost { get; set; }

    public string ImageOfProductItem { get; set; } = null!;

    public bool Status { get; set; }

    public bool Hot { get; set; }

    public bool? Sale { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Color Color { get; set; } = null!;

    public virtual ICollection<EventDetail> EventDetails { get; set; } = new List<EventDetail>();

    public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Product Product { get; set; } = null!;

    public virtual Size Size { get; set; } = null!;

    public virtual ICollection<Wishlist> Wishlists { get; set; } = new List<Wishlist>();
}
