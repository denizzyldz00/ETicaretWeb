using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ETicaretWeb.Models
{
    public class Siparis
    {
        [Key]
        public int SiparisID { get; set; }

        [ForeignKey("Musteri")]
        public int? MusteriID { get; set; }
        public virtual Musteri? Musteri { get; set; }

        public DateTime? SiparisTarihi { get; set; }

        public DateTime? TeslimTarihi { get; set; }

        [StringLength(20)]
        public string? SiparisDurumu { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? ToplamTutar { get; set; }

        [StringLength(500)]
        public string? TeslimatAdresi { get; set; }

        // Navigation property
        public virtual ICollection<SiparisDetay>? SiparisDetaylari { get; set; }
    }
}
