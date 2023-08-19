using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BitirmeWebRazor_Temp.Models
{
    public class Kategori
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [DisplayName("Kategori Adı")]
        public string Ad { get; set; }
        [Range(1, 100, ErrorMessage = "Sipariş Sayısı 1-100 Aralığında Bir Sayı Olmalıdır")]
        [DisplayName("Sipariş Göster")]
        public int Siparis { get; set; }
    }
}
