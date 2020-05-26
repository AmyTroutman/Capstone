using LibraryApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.Core.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepo;
        private readonly ICatalogRepository _catalogRepo;
        private readonly IUserService _userService;

        public BookService(IBookRepository bookRepo, ICatalogRepository catalogRepo, IUserService userService)
        {
            _bookRepo = bookRepo;
            _catalogRepo = catalogRepo;
            _userService = userService;
        }

        public Book Add(Book book)
        {
            var currentUserId = _userService.CurrentUserId;
            //var catalogId = _catalogRepo.Get(book.CatalogId);

            /*if(currentUserId != catalogId.UserId)
            {
                throw new ApplicationException("You are not allowed to add a book to another user's catalog.");
            }*/
            return _bookRepo.Add(book);
        }

        public Book Update(Book book)
        {
            return _bookRepo.Update(book);
        }

        public Book Get(int id)
        {
            return _bookRepo.Get(id);
        }

        public IEnumerable<Book> GetAll()
        {
            return _bookRepo.GetAll();
        }

        public IEnumerable<Book> GetBooksForAuthor(int authorId)
        {
            return _bookRepo.GetBooksForAuthor(authorId);
        }

        public IEnumerable<Book> GetBooksForSeries(int seriesId)
        {
            return _bookRepo.GetBooksForSeries(seriesId);
        }

        public IEnumerable<Book> GetBooksForCatalog(int catalogId)
        {
            return _bookRepo.GetBooksForCatalog(catalogId);
        }

        public void Remove(int id)
        {
            var book = _bookRepo.Get(id);
            _bookRepo.Remove(book);
        }
    }
}
