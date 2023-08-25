using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitirme.Models
{
	public class Company
	{
		public int Id { get; set; }
		[Required]
		public string Isim { get; set; }
		public string? Adres { get; set; }
		public string? Sehir { get; set; }
		public string? Ilce { get; set; }
		public string? PostaKodu { get; set; }
		public string? TelefonNo { get; set; }

	}
}
