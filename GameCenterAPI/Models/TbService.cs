using System;
using System.Collections.Generic;

namespace GameCenterAPI.Models;

public partial class TbService
{
    public int SeId { get; set; }

    public int SeIId { get; set; }

    public int? SeQty { get; set; }

    public double? SePrice { get; set; }

    public double? SeDiscount { get; set; }

    /// <summary>
    /// بداية وقت اللعب
    /// </summary>
    public TimeOnly? SeStart { get; set; }

    /// <summary>
    /// عند اضافة مادة نفس الوقت بدء ونهاية
    /// </summary>
    public TimeOnly? SeEnd { get; set; }

    public int? SeTNumber { get; set; }

    public bool SeIsdel { get; set; }

    public int SeMenu { get; set; }

    public bool SePrint { get; set; }

    public string? SeMargeTo { get; set; }

    public virtual TbItem SeI { get; set; } = null!;
}
