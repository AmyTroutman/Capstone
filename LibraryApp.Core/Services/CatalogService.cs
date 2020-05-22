using LibraryApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace LibraryApp.Core.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly ICatalogRepository _catalogRepository;

        public CatalogService(ICatalogRepository catalogRepository)
        {
            _catalogRepository = catalogRepository;
        }

        public Catalog Add(Catalog catalog)
        {
            return _catalogRepository.Add(catalog);
        }

        public Catalog Update(Catalog catalog)
        {
            return _catalogRepository.Update(catalog);
        }

        public Catalog Get(int id)
        {
            return _catalogRepository.Get(id);
        }

        public IEnumerable<Catalog> GetAll()
        {
            return _catalogRepository.GetAll();
        }

        public void Remove(int id)
        {
            var catalog = _catalogRepository.Get(id);
            _catalogRepository.Remove(catalog);
        }

    }
}
