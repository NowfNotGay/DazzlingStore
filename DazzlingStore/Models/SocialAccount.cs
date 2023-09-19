using System;
using System.Collections.Generic;

namespace DazzlingStore.Models;

public partial class SocialAccount
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public string Provider { get; set; } = null!;

    public string ProviderUserId { get; set; } = null!;

    public string AccessToken { get; set; } = null!;

    public DateTime? Expiry { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Account Account { get; set; } = null!;
}
