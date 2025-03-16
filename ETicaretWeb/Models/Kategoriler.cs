using System;
using System.Collections.Generic;

namespace ETicaretWeb.Models;

public partial class Kategoriler
{
    public int KategoriId { get; set; }

    public string KategoriAdi { get; set; } = null!;

    public string? Aciklama { get; set; }

    public virtual ICollection<Urunler> Urunlers { get; set; } = new List<Urunler>();
}
