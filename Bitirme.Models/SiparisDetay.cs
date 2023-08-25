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
    public class SiparisDetay
    {
        public int Id { get; set; }
        [Required]
        public int SiparisBaslikId { get; set; }
        [ForeignKey("SiparisBaslikId")]
        [ValidateNever]
        public SiparisBaslik SiparisBaslik { get; set; }


        [Required]
        public int UrunId { get; set; }
        [ForeignKey("UrunId")]
        [ValidateNever]
        public Urun  Urun { get; set; }

        public int Adet { get; set; }
        public double Fiyat { get; set; }



    }
}
