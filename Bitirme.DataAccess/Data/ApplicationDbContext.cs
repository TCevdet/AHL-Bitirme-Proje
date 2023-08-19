using Bitirme.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Bitirme.DataAccess.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Urun> Urunler { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kategori>().HasData(
                new Kategori { Id = 1, Ad = "GramAltin", Siparis = 1 },
                new Kategori { Id = 2, Ad = "KulceAltin", Siparis = 2 },
                new Kategori { Id = 3, Ad = "ZiynetAltin", Siparis = 3 },
                new Kategori { Id = 4, Ad = "Diger", Siparis = 4 });


            modelBuilder.Entity<Urun>().HasData(

                new Urun
                {
                    Id = 1,
                    UrunAdi = "Gram Altın",
                    UrunMarka = "Ahlatcı Rafineri",
                    Aciklama = "Rafineri onaylı ve belgeli, özel kutusunda gram altın ",
                    UrunKodu = "grm01",
                    ListeFiyat = 1900,
                    Fiyat = 1900,
                    Fiyat50 = 1890,
                    Fiyat100 = 1880,
                    KategoriId =1,
                    ResimUrl=""
                },
                new Urun
                {
                    Id = 2,
                    UrunAdi = "Çeyrek Altın",
                    UrunMarka = "Ahlatcı Rafineri",
                    Aciklama = "Rafineri onaylı ve belgeli, özel kutusunda gram altın ",
                    UrunKodu = "cyr01",
                    ListeFiyat = 3500,
                    Fiyat = 3500,
                    Fiyat50 = 3480,
                    Fiyat100 = 3470,
                    KategoriId = 4,
                    ResimUrl = ""
                },
                new Urun
                {
                    Id = 3,
                    UrunAdi = "Yarım Altın",
                    UrunMarka = "Ahlatcı Rafineri",
                    Aciklama = "Rafineri onaylı ve belgeli, özel kutusunda gram altın ",
                    UrunKodu = "yrm01",
                    ListeFiyat = 5000,
                    Fiyat = 5000,
                    Fiyat50 = 4990,
                    Fiyat100 = 4750,
                    KategoriId = 1,
                    ResimUrl = ""
                },
                new Urun
                {
                    Id = 4,
                    UrunAdi = "10 Gram Külçe Altın",
                    UrunMarka = "Ahlatcı Rafineri",
                    Aciklama = "Rafineri onaylı ve belgeli, özel kutusunda 10 Gram Külçe Altın ",
                    UrunKodu = "Kulce0001",
                    ListeFiyat = 18000,
                    Fiyat = 18000,
                    Fiyat50 = 17800,
                    Fiyat100 = 17500,
                    KategoriId = 2,
                    ResimUrl = ""
                },
                new Urun
                {
                    Id = 5,
                    UrunAdi = "30 Gram Altın Bileklik",
                    UrunMarka = "Ahlatcı Rafineri",
                    Aciklama = "Rafineri onaylı ve belgeli, özel kutusunda 30 gram 18 Ayar şık kadın bilekliği ",
                    UrunKodu = "Ziynet001",
                    ListeFiyat = 50000,
                    Fiyat = 50000,
                    Fiyat50 = 49800,
                    Fiyat100 = 49700,
                    KategoriId = 2,
                    ResimUrl = ""
                },
                new Urun
                {
                    Id = 6,
                    UrunAdi = "50 Gram Burma Bilezik",
                    UrunMarka = "Ahlatcı Rafineri",
                    Aciklama = "Rafineri onaylı ve belgeli, özel hediye kutusunda 50 gram 22 Ayar Burma Bilezik ",
                    UrunKodu = "Ziynet002",
                    ListeFiyat = 85000,
                    Fiyat = 85000,
                    Fiyat50 = 84850,
                    Fiyat100 = 84600,
                    KategoriId = 3,
                    ResimUrl = ""
                }
                );
        }
    }
}
