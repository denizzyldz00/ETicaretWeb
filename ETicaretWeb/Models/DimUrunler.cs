using System;
using System.Collections.Generic;

namespace ETicaretWeb.Models;

public partial class DimUrunler
{
    public int UrunKey { get; set; }

    public int? UrunId { get; set; }

    public string? UrunAdi { get; set; }

    public string? KategoriAdi { get; set; }

    public decimal? BirimFiyat { get; set; }

    public string? TedarikciAdi { get; set; }

    public DateTime? BaslangicTarihi { get; set; }

    public DateTime? BitisTarihi { get; set; }

    public bool? GuncelKayitMi { get; set; }

    public virtual ICollection<FactSatislar> FactSatislars { get; set; } = new List<FactSatislar>();
}
