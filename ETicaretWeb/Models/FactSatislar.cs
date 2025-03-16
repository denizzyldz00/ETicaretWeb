using System;
using System.Collections.Generic;

namespace ETicaretWeb.Models;

public partial class FactSatislar
{
    public int SatisKey { get; set; }

    public int? MusteriKey { get; set; }

    public int? UrunKey { get; set; }

    public int? TarihKey { get; set; }

    public int? KategoriKey { get; set; }

    public int? SatisMiktari { get; set; }

    public decimal? BirimFiyat { get; set; }

    public decimal? ToplamTutar { get; set; }

    public decimal? IndirimTutari { get; set; }

    public decimal? NetTutar { get; set; }

    public int? SiparisId { get; set; }

    public int? SiparisDetayId { get; set; }

    public virtual DimKategoriler? KategoriKeyNavigation { get; set; }

    public virtual DimMusteriler? MusteriKeyNavigation { get; set; }

    public virtual DimTarih? TarihKeyNavigation { get; set; }

    public virtual DimUrunler? UrunKeyNavigation { get; set; }
}
