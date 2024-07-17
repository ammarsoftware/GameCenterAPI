using System;
using System.Collections.Generic;

namespace GameCenterAPI.Models;

/// <summary>
/// المخازن
/// </summary>
public partial class TbStore
{
    public int StoreId { get; set; }

    public string StoreName { get; set; } = null!;

    public string? StoreDetails { get; set; }

    public byte[]? StoreImg { get; set; }

    public virtual ICollection<TbItem> TbItems { get; set; } = new List<TbItem>();
}
