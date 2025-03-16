using System;
using System.Collections.Generic;

namespace ETicaretWeb.Models;

public partial class DimKategoriler
{
    public int KategoriKey { get; set; }

    public int? KategoriId { get; set; }

    public string? KategoriAdi { get; set; }

    public string? Aciklama { get; set; }

    public DateTime? BaslangicTarihi { get; set; }

    public DateTime? BitisTarihi { get; set; }

    public bool? GuncelKayitMi { get; set; }

    public virtual ICollection<FactSatislar> FactSatislars { get; set; } = new List<FactSatislar>();
}
