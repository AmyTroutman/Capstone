﻿using LibraryApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.Core.Services
{
    public interface IBookRepository
    {
        Book Add(Book book);
        Book Update(Book book);
        Book Get(int id);
        IEnumerable<Book> GetAll();
        IEnumerable<Book> GetBooksForAuthor(int authorId);
        IEnumerable<Book> GetBooksForSeries(int seriesId);
        IEnumerable<Book> GetBooksForCatalog(int catalogId);
        void Remove(Book book);
    }
}
