using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitirme.Utility
{
    public static class SD
    {
        public const string Role_Customer = "Üye";
        public const string Role_Admin = "Admin";
		public const string Role_Company = "Kurumsal";
		public const string Role_Employee = "Çalışan";


        public const string StatusPending = "Beklemede";
		public const string StatusApproved = "Onaylanmış";
		public const string StatusInProcess = "İşlemde";
		public const string StatusShipped = "Gönderildi";
		public const string StatusCancelled = "İptal Edildi";
		public const string StatusRefunded = "İade Edildi";


		public const string PaymentStatusPending = "Ödeme Beklemede";
		public const string PaymentStatusApproved = "Ödeme Onaylandı";
		public const string PaymentStatusDelayedPayment = "Ödeme Gecikti";
		public const string PaymentStatusRejected = "Ödeme İptal Edildi";

	}
}
