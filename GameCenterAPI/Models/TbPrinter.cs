using System;
using System.Collections.Generic;

namespace GameCenterAPI.Models;

public partial class TbPrinter
{
    public int PrinterId { get; set; }

    public string? PrinterLocation { get; set; }

    public string PrinterName { get; set; } = null!;

    public string? PrinterDetails { get; set; }

    public virtual ICollection<TbItem> TbItems { get; set; } = new List<TbItem>();
}
