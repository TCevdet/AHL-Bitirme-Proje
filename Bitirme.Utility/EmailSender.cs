using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitirme.Utility
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {   
            //EMAIL servisim olmadığı için şimdilik return Task.CompletedTask ile işlemi geçiyorum
            //E-Mail servisi kullanılacağı zaman implemente edileceği mantık kısmı burası:
            return Task.CompletedTask;
        }
    }
}
