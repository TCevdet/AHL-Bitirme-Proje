using Bitirme.DataAccess.Data;
using Bitirme.DataAccess.Repository.IRepository;

namespace Bitirme.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public IKategoriRepository Kategori { get; private set; }
        public IUrunRepository Urun { get; private set; }
        public ICompanyRepository Company { get; private set; }
        public IAlisverisSepetiRepository AlisverisSepeti { get; private set; }
        public IApplicationUserRepository ApplicationUser { get; private set; }

        public ISiparisBaslikRepository SiparisBaslik { get; private set; }
        public ISiparisDetayRepository SiparisDetay { get; private set; }
        
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            AlisverisSepeti = new AlisverisSepetiRepository(_db);
            ApplicationUser = new ApplicationUserRepository(_db);
            Kategori = new KategoriRepository(_db);
            Urun = new UrunRepository(_db);
            Company = new CompanyRepository(_db);
            SiparisBaslik = new SiparisBaslikRepository(_db);
            SiparisDetay = new SiparisDetayRepository(_db);
            
        }
        

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
