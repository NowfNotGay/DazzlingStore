using System;
using System.Collections.Generic;

namespace DazzlingStore.Models;

public partial class InvoiceDetail
{
    public int InvoiceId { get; set; }

    public int ProductItemId { get; set; }

    public int Quantity { get; set; }

    public int Cost { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Invoice Invoice { get; set; } = null!;

    public virtual ProductItem ProductItem { get; set; } = null!;
}
