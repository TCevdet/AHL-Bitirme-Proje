﻿using Bitirme.DataAccess.Data;
using Bitirme.DataAccess.Repository.IRepository;
using Bitirme.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Bitirme.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public IKategoriRepository Kategori { get; private set; }
        public  IUrunRepository Urun { get; private set; }
        public IAlisverisSepetiRepository AlisverisSepeti { get; private set; }
        public IApplicationUserRepository ApplicationUser { get; private set; }
        
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            ApplicationUser = new ApplicationUserRepository(_db);
            Kategori = new KategoriRepository(_db);
            Urun = new UrunRepository(_db);
            AlisverisSepeti = new AlisverisSepetiRepository(_db);
        }
        

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
