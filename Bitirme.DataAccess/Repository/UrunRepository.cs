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
    public class UrunRepository : Repository<Urun>, IUrunRepository 
    {
        private readonly ApplicationDbContext _db;
        public UrunRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        

        public void Update(Urun obj)
        {
            var objFromDb = _db.Urunler.FirstOrDefault(u=>u.Id == obj.Id);
            if (objFromDb!=null)
            {
                objFromDb.UrunAdi = obj.UrunAdi;
                objFromDb.UrunKodu = obj.UrunKodu;
                objFromDb.Fiyat= obj.Fiyat;
                objFromDb.Fiyat50 = obj.Fiyat50;
                objFromDb.Fiyat100 = obj.Fiyat100;
                objFromDb.Aciklama= obj.Aciklama;
                objFromDb.KategoriId= obj.KategoriId;
                objFromDb.UrunMarka= obj.UrunMarka;

                if (obj.ResimUrl!=null)
                {
                    objFromDb.ResimUrl = obj.ResimUrl;
                }
            }
        }
    }
}
