using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ETicaretWeb.Models
{
    public class SiparisDetay
    {
        [Key]
        public int SiparisDetayID { get; set; }

        [ForeignKey("Siparis")]
        public int? SiparisID { get; set; }
        public virtual Siparis? Siparis { get; set; }

        [ForeignKey("Urun")]
        public int? UrunID { get; set; }
        public virtual Urun? Urun { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal BirimFiyat { get; set; }

        [Required]
        public int Miktar { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? Indirim { get; set; }
    }
}
