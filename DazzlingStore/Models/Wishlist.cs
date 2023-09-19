using System;
using System.Collections.Generic;

namespace DazzlingStore.Models;

public partial class Wishlist
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int ProductItemId { get; set; }

    public DateTime? AddedAt { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual ProductItem ProductItem { get; set; } = null!;
}
