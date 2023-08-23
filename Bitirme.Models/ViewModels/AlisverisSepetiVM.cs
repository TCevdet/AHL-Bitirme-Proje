using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitirme.Models.ViewModels
{
    public class AlisverisSepetiVM
    {
        public IEnumerable<AlisverisSepeti> AlisverisSepetiList { get; set; }
        public double SiparisTutar { get; set; }
    }
}
