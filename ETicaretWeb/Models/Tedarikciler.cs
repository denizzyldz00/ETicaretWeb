using System;
using System.Collections.Generic;

namespace ETicaretWeb.Models;

public partial class Tedarikciler
{
    public int TedarikciId { get; set; }

    public string FirmaAdi { get; set; } = null!;

    public string? YetkiliAdi { get; set; }

    public string? Telefon { get; set; }

    public string? Email { get; set; }

    public string? Adres { get; set; }

    public string? VergiNo { get; set; }

    public virtual ICollection<Urunler> Urunlers { get; set; } = new List<Urunler>();
}
