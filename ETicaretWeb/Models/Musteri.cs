using System.ComponentModel.DataAnnotations;

namespace ETicaretWeb.Models
{
    public class Musteri
    {
        [Key]
        public int MusteriID { get; set; }

        [Required(ErrorMessage = "Ad alanı zorunludur")]
        [StringLength(50)]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Soyad alanı zorunludur")]
        [StringLength(50)]
        public string Soyad { get; set; }

        [Required(ErrorMessage = "Email alanı zorunludur")]
        [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz")]
        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(15)]
        public string? Telefon { get; set; }

        [StringLength(500)]
        public string? Adres { get; set; }

        public DateTime? KayitTarihi { get; set; }

        // Navigation property
        public virtual ICollection<Siparis>? Siparisler { get; set; }
    }
}
