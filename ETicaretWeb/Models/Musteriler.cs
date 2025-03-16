using System;
using System.Collections.Generic;

namespace ETicaretWeb.Models;

public partial class Musteriler
{
    public int MusteriId { get; set; }

    public string Ad { get; set; } = null!;

    public string Soyad { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Telefon { get; set; }

    public string? Adres { get; set; }

    public DateTime? KayitTarihi { get; set; }

    public virtual ICollection<Siparisler> Siparislers { get; set; } = new List<Siparisler>();
}
