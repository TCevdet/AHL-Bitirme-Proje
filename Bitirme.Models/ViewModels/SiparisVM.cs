using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitirme.Models.ViewModels
{
    public class SiparisVM
    {
        public SiparisBaslik SiparisBaslik { get; set; }
        public IEnumerable<SiparisDetay> SiparisDetay { get; set; }
    }
}
