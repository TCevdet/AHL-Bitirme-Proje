using Bitirme.DataAccess.Data;
using Bitirme.DataAccess.Repository.IRepository;
using Bitirme.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
