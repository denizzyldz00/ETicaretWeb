using System.ComponentModel.DataAnnotations;

namespace ETicaretWeb.Models
{
    public class Tedarikci
    {
        [Key]
        public int TedarikciID { get; set; }

        [Required(ErrorMessage = "Firma adı zorunludur")]
        [StringLength(100)]
        public string FirmaAdi { get; set; }

        [StringLength(50)]
        public string? YetkiliAdi { get; set; }

        [StringLength(15)]
        public string? Telefon { get; set; }

        [StringLength(100)]
        public string? Email { get; set; }

        [StringLength(500)]
        public string? Adres { get; set; }

        [StringLength(20)]
        public string? VergiNo { get; set; }

        // Navigation property
        public virtual ICollection<Urun>? Urunler { get; set; }
    }
}
