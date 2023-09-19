using System;
using System.Collections.Generic;

namespace DazzlingStore.Models;

public partial class AccountRole
{
    public int AccountId { get; set; }

    public int RoleId { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual Role Role { get; set; } = null!;
}
