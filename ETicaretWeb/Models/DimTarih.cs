using System;
using System.Collections.Generic;

namespace ETicaretWeb.Models;

public partial class DimTarih
{
    public int TarihKey { get; set; }

    public DateOnly? Tarih { get; set; }

    public int? Yil { get; set; }

    public int? Ay { get; set; }

    public int? Gun { get; set; }

    public int? Ceyrek { get; set; }

    public string? AyAdi { get; set; }

    public string? GunAdi { get; set; }

    public int? HaftaninGunu { get; set; }

    public int? YilinHaftasi { get; set; }

    public virtual ICollection<FactSatislar> FactSatislars { get; set; } = new List<FactSatislar>();
}
