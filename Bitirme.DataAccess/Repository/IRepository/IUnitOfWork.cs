using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitirme.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IKategoriRepository Kategori { get; }
        IUrunRepository Urun { get; }
        IAlisverisSepetiRepository AlisverisSepeti { get; }
        IApplicationUserRepository ApplicationUser { get; }
        void Save();
    }
    
}
