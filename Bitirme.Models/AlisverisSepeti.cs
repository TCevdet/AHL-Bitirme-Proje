﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitirme.Models
{
    public class AlisverisSepeti
    {
        public int Id { get; set; }
        public int UrunId { get; set; }
        [ForeignKey("UrunId")]
        [ValidateNever]
        public Urun Urun { get; set; }
        [Range(1,1000, ErrorMessage="1 ile 1000 arasında bir sayı giriniz")]
        public int Adet { get; set; }
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }

        [NotMapped] public double Fiyat { get; set;}






    }
}
