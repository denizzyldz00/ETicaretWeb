using System.ComponentModel.DataAnnotations;

namespace ETicaretWeb.Models
{
    public class Kategori
    {
        [Key]
        public int KategoriID { get; set; }

        [Required(ErrorMessage = "Kategori adı zorunludur")]
        [StringLength(50)]
        public string KategoriAdi { get; set; }

        [StringLength(500)]
        public string? Aciklama { get; set; }

        // Navigation property
        public virtual ICollection<Urun>? Urunler { get; set; }
    }
}
