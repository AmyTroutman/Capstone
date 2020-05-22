using LibraryApp.Core.Models;
using LibraryApp.Core.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryApp.Infrastructure.Data
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _appDbContext;

        public BookRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Book Add(Book newBook)
        {
            _appDbContext.Books.Add(newBook);
            _appDbContext.SaveChanges();
            return newBook;
        }

        public Book Update(Book updateBook)
        {
            var currentBook = _appDbContext.Books.Find(updateBook.Id);

            if (currentBook == null) return null;

            _appDbContext.Entry(currentBook).CurrentValues.SetValues(updateBook);

            _appDbContext.Books.Update(currentBook);
            _appDbContext.SaveChanges();
            return currentBook;
        }

        public Book Get(int id)
        {
            return _appDbContext.Books
                .Include(b => b.Author)
                .Include(b => b.Series)
                .SingleOrDefault(b => b.Id == id);
                
        }

        public IEnumerable<Book> GetAll()
        {
            return _appDbContext.Books
                .Include(b => b.Author)
                .Include(b => b.Series)
                .ToList();
        }

        public IEnumerable<Book> GetBooksForAuthor(int authorId)
        {
            return _appDbContext.Books
                .Include(b => b.Author)
                .Include(b => b.Series)
                .Where(b => b.AuthorId == authorId)
                .ToList();
        }

        public IEnumerable<Book> GetBooksForSeries(int seriesId)
        {
            return _appDbContext.Books
                .Include(b => b.Series)
                .Include(b => b.Author)
                .Where(b => b.SeriesId == seriesId)
                .ToList();
        }

        public void Remove(Book book)
        {
            _appDbContext.Books.Remove(book);
            _appDbContext.SaveChanges();
        }
    }
}
