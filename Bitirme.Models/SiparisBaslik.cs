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
    public class SiparisBaslik
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }
        public DateTime SiparisZamani { get; set; }
        public DateTime GonderimZamani { get; set; }
        public double SiparisToplamTutar { get; set; }
        public string? SiparisDurumu { get; set; }
        public string? OdemeDurumu { get; set; }
        public string? KargoTakipNo { get; set; }
        public string? KargoFirmasi { get; set; }

        public string? PaymentIntentId { get; set; }

        [Required]
        public string TelefonNo { get; set; }
        [Required]
        public string Adres { get; set; }
        [Required]
        public string Sehir { get; set; }
        [Required]
        public string Ilce { get; set; }
        [Required]
        public string PostaKodu { get; set; }
        [Required]
        public string Isim { get; set; }

    }
}
