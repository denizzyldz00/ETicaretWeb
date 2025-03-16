using System;
using System.Collections.Generic;

namespace ETicaretWeb.Models;

public partial class Urunler
{
    public int UrunId { get; set; }

    public string UrunAdi { get; set; } = null!;

    public int? KategoriId { get; set; }

    public int? TedarikciId { get; set; }

    public decimal BirimFiyat { get; set; }

    public int StokMiktari { get; set; }

    public string? UrunAciklamasi { get; set; }

    public DateTime? EklenmeTarihi { get; set; }

    public virtual Kategoriler? Kategori { get; set; }

    public virtual ICollection<SiparisDetaylari> SiparisDetaylaris { get; set; } = new List<SiparisDetaylari>();

    public virtual Tedarikciler? Tedarikci { get; set; }
}
