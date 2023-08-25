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
    public class SiparisDetayRepository : Repository<SiparisDetay>, ISiparisDetayRepository
    {
        private ApplicationDbContext _db;
        public SiparisDetayRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(SiparisDetay obj)
        {
            _db.SiparisDetays.Update(obj);
        }
    }
}
