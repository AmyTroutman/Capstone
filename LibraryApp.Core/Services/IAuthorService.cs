using LibraryApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.Core.Services
{
    public interface IAuthorService
    {
        Author Add(Author newAuthor);
        Author Update(Author updateAuthor);
        Author Get(int id);
        IEnumerable<Author> GetAll();
        void Remove(int id);
    }
}
