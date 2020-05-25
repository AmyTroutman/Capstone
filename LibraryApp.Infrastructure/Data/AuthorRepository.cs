using LibraryApp.Core.Models;
using LibraryApp.Core.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryApp.Infrastructure.Data
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly AppDbContext _appDbContext;

        public AuthorRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Author Add(Author author)
        {
            _appDbContext.Authors.Add(author);
            _appDbContext.SaveChanges();
            return author;
        }

        public Author Get(int id)
        {
            return _appDbContext.Authors
                .Include(a => a.Books)
               // .Include(a => a.Books.Series)
                .SingleOrDefault();
        }

        public IEnumerable<Author> GetAll()
        {
            return _appDbContext.Authors
                .Include(a => a.Books)
               // .Include(a => a.Series)
                .ToList();
        }

        public void Remove(Author author)
        {
            _appDbContext.Authors.Remove(author);
            _appDbContext.SaveChanges();
        }

        public Author Update(Author updateAuthor)
        {
            var currentAuthor = _appDbContext.Authors.Find(updateAuthor.Id);
            if (currentAuthor == null) return null;

            _appDbContext.Entry(currentAuthor)
                .CurrentValues
                .SetValues(updateAuthor);

            _appDbContext.Authors.Update(currentAuthor);
            _appDbContext.SaveChanges();
            return currentAuthor;
        }
    }
}
