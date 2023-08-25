using Bitirme.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitirme.DataAccess.Repository.IRepository
{
    public interface ISiparisDetayRepository : IRepository<SiparisDetay>
    {
        void Update(SiparisDetay obj);
        
    }
}
