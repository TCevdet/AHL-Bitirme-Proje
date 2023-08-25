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
    public class SiparisBaslikRepository : Repository<SiparisBaslik>, ISiparisBaslikRepository
    {
        private ApplicationDbContext _db;
        public SiparisBaslikRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(SiparisBaslik obj)
        {
            _db.SiparisBasliks.Update(obj);
        }
    }
}
