using LibraryApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.Core.Services
{
    public interface IBookService
    {
        Book Add(Book newBook);
        Book Update(Book updateBook);
        Book Get(int id);
        IEnumerable<Book> GetAll();
        IEnumerable<Book> GetBooksForAuthor(int id);
        //assuming I also need to be able to get books for series
        IEnumerable<Book> GetBooksForSeries(int id);
        IEnumerable<Book> GetBooksForCatalog(int id);
        void Remove(int id);
    }
}
