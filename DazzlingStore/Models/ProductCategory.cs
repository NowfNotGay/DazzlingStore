﻿using System;
using System.Collections.Generic;

namespace DazzlingStore.Models;

public partial class ProductCategory
{
    public int ProductId { get; set; }

    public int CategoryId { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
