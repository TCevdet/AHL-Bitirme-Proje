using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitirme.Models
{
    public class Urun
    {
        [Key] public int Id { get; set; }
        [Required] public string? UrunAdi { get; set; }
        public string? Aciklama { get; set; }
        [Required] public string? UrunKodu { get; set; }
        [Required] public string? UrunMarka { get; set; }
        [Required] [Display(Name ="Liste Fiyatı")] [Range(1,10000000)] public double ListeFiyat { get; set; }


        //indirimli fiyat skala
        [Required][Display(Name = "1-50 Arası Fiyat")][Range(1, 100000000)] public double Fiyat { get; set; }
        [Required][Display(Name = "50-100 Arası Fiyat")][Range(1, 100000000)] public double Fiyat50 { get; set; }
        [Required][Display(Name = "100 ve Üzeri Fiyat")][Range(1, 100000000)] public double Fiyat100 { get; set; }

        public int KategoriId { get; set; }
        [ForeignKey("KategoriId")]
        [ValidateNever]
        public Kategori? Kategori { get; set; }
        [ValidateNever]
        public string? ResimUrl { get; set; }

    }
}
