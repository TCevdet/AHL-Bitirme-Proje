using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bitirme.Models
{
    public class Kategori
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [DisplayName("Kategori Adı")]
        public required string Ad { get; set; }
        [Range(1, 100, ErrorMessage = "Sipariş Sayısı 1-100 Aralığında Bir Sayı Olmalıdır")]
        [DisplayName("Sipariş Göster")]
        public int Siparis { get; set; }
        
    }
}
