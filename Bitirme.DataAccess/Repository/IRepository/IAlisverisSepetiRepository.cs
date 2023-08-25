using Bitirme.Models;

namespace Bitirme.DataAccess.Repository.IRepository
{
    public interface IAlisverisSepetiRepository : IRepository<AlisverisSepeti>
    {
		void Update(AlisverisSepeti obj);
        
    }
}
