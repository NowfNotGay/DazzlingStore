using System;
using System.Collections.Generic;

namespace DazzlingStore.Models;

public partial class ProductImage
{
    public int Id { get; set; }

    public string Image { get; set; } = null!;

    public int? IndexOf { get; set; }

    public int ProductId { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Product Product { get; set; } = null!;
}
