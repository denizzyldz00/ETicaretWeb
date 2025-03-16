using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ETicaretWeb.Models
{
    public class Urun
    {
        [Key]
        public int UrunID { get; set; }

        [Required(ErrorMessage = "Ürün adı zorunludur")]
        [StringLength(100)]
        public string UrunAdi { get; set; }

        [ForeignKey("Kategori")]
        public int? KategoriID { get; set; }
        public virtual Kategori? Kategori { get; set; }

        [ForeignKey("Tedarikci")]
        public int? TedarikciID { get; set; }
        public virtual Tedarikci? Tedarikci { get; set; }

        [Required(ErrorMessage = "Birim fiyat zorunludur")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal BirimFiyat { get; set; }

        [Required(ErrorMessage = "Stok miktarı zorunludur")]
        public int StokMiktari { get; set; }

        public string? UrunAciklamasi { get; set; }

        public DateTime? EklenmeTarihi { get; set; }

        // Navigation property
        public virtual ICollection<SiparisDetay>? SiparisDetaylari { get; set; }
    }
}
