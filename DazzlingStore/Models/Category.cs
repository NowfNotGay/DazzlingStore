using System;
using System.Collections.Generic;

namespace DazzlingStore.Models;

public partial class Category
{
    public int Id { get; set; }

    public int Name { get; set; }

    public int ParentId { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Category> InverseParent { get; set; } = new List<Category>();

    public virtual Category Parent { get; set; } = null!;

    public virtual ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();
}
