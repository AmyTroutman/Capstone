using LibraryApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.Core.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepo;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepo = authorRepository;
        }

        public Author Add(Author author)
        {
            return _authorRepo.Add(author);
        }

        public Author Update(Author author)
        {
            return _authorRepo.Update(author);
        }

        public Author Get(int id)
        {
            return _authorRepo.Get(id);
        }

        public IEnumerable<Author> GetAll()
        {
            return _authorRepo.GetAll();
        }

        public void Remove(int id)
        {
            var author = _authorRepo.Get(id);
            _authorRepo.Remove(author);
        }
    }
}
