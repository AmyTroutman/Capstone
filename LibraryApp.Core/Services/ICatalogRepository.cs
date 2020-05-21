using LibraryApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.Core.Services
{
    public interface ICatalogRepository
    {
        Catalog Add(Catalog catalog);
        Catalog Update(Catalog catalog);
        Catalog Get(int id);
        IEnumerable<Catalog> GetAll();
        void Remove(Catalog catalog);
    }
}
