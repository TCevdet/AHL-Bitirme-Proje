using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitirme.Models.ViewModels
{
    public class UrunVM
    {
        public Urun Urun { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> KategoriList { get; set; }
    }
}
