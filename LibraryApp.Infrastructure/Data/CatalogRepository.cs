using LibraryApp.Core.Models;
using LibraryApp.Core.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryApp.Infrastructure.Data
{
    public class CatalogRepository : ICatalogRepository
    {
        private readonly AppDbContext _appDbContext;
        public CatalogRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Catalog Add(Catalog catalog)
        {            
            _appDbContext.Catalogs.Add(catalog);
            _appDbContext.SaveChanges();
            return catalog;
        }

        public Catalog Get(int id)
        {
            return _appDbContext.Catalogs
                .Include(c => c.Books)
                .ThenInclude(b => b.Author)
                .ThenInclude(b => b.Series)
                .SingleOrDefault(c => c.Id == id);
        }

        public IEnumerable<Catalog> GetAll()
        {
            return _appDbContext.Catalogs
                .Include(c => c.Books)
                .ThenInclude(b => b.Author)
                .ThenInclude(b => b.Series)
                .ToList();
        }

        public void Remove(Catalog catalog)
        {
            _appDbContext.Remove(catalog);
            _appDbContext.SaveChanges();
        }

        public Catalog Update(Catalog updateCatalog)
        {
            var existingCatalog = _appDbContext.Catalogs.Find(updateCatalog.Id);
            if(existingCatalog == null) return null;
            _appDbContext.Entry(existingCatalog)
                .CurrentValues
                .SetValues(updateCatalog);
            _appDbContext.Catalogs.Update(existingCatalog);
            _appDbContext.SaveChanges();
            return existingCatalog;
        }
    }
}
