using LibraryApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.Core.Services
{
    public interface IAuthorRepository
    {
        Author Add(Author author);
        Author Update(Author author);
        Author Get(int id);
        IEnumerable<Author> GetAll();
        void Remove(Author author);

    }
}
