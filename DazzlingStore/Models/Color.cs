using System;
using System.Collections.Generic;

namespace DazzlingStore.Models;

public partial class Color
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? HexCode { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<ProductItem> ProductItems { get; set; } = new List<ProductItem>();
}
