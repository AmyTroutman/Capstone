using LibraryApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.Core.Services
{
    public interface ICatalogService
    {
        Catalog Add(Catalog newCatalog);
        Catalog Update(Catalog updateCatalog);
        Catalog Get(int id);
        IEnumerable<Catalog> GetAll();
        void Remove(int id);
    }
}
