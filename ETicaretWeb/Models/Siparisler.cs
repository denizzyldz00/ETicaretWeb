using System;
using System.Collections.Generic;

namespace ETicaretWeb.Models;

public partial class Siparisler
{
    public int SiparisId { get; set; }

    public int? MusteriId { get; set; }

    public DateTime? SiparisTarihi { get; set; }

    public DateTime? TeslimTarihi { get; set; }

    public string? SiparisDurumu { get; set; }

    public decimal? ToplamTutar { get; set; }

    public string? TeslimatAdresi { get; set; }

    public virtual Musteriler? Musteri { get; set; }

    public virtual ICollection<SiparisDetaylari> SiparisDetaylaris { get; set; } = new List<SiparisDetaylari>();
}
