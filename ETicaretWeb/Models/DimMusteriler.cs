using System;
using System.Collections.Generic;

namespace ETicaretWeb.Models;

public partial class DimMusteriler
{
    public int MusteriKey { get; set; }

    public int? MusteriId { get; set; }

    public string? Ad { get; set; }

    public string? Soyad { get; set; }

    public string? TamAd { get; set; }

    public string? Email { get; set; }

    public string? Sehir { get; set; }

    public string? Ulke { get; set; }

    public DateTime? BaslangicTarihi { get; set; }

    public DateTime? BitisTarihi { get; set; }

    public bool? GuncelKayitMi { get; set; }

    public virtual ICollection<FactSatislar> FactSatislars { get; set; } = new List<FactSatislar>();
}
