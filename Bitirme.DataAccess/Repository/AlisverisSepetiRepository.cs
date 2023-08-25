using Bitirme.DataAccess.Data;
using Bitirme.DataAccess.Repository.IRepository;
using Bitirme.Models;

namespace Bitirme.DataAccess.Repository
{
    public class AlisverisSepetiRepository : Repository<AlisverisSepeti>, IAlisverisSepetiRepository
    {
        private ApplicationDbContext _db;
        public AlisverisSepetiRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(AlisverisSepeti obj)
        {
            _db.AlisverisSepetleri.Update(obj);
        }
    }
}
