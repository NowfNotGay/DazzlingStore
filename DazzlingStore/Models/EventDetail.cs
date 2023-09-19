using System;
using System.Collections.Generic;

namespace DazzlingStore.Models;

public partial class EventDetail
{
    public int ProductItemId { get; set; }

    public int EventId { get; set; }

    public int Price { get; set; }

    public int LimitedQuantity { get; set; }

    public int RemainingQuantity { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual Event Event { get; set; } = null!;

    public virtual ProductItem ProductItem { get; set; } = null!;
}
