using Microsoft.AspNetCore.Identity;
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
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string Isim { get; set; }
        public string? Adres { get; set; }
        public string? Sehir { get; set; }
        public string? Ilce { get; set; }
        public string? PostaKodu { get; set; }
        public string? TelefonNo { get; set; }
        public int? CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        [ValidateNever]
        public Company Company { get; set; }


    }
}
