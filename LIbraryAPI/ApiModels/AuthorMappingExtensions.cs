using LibraryApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp.ApiModels
{
    public static class AuthorMappingExtensions
    {
        public static AuthorModel ToApiModel(this Author author)
        {
            return new AuthorModel
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
            };
        }

        public static Author ToDomainModel(this AuthorModel authorModel)
        {
            return new Author
            {
                Id = authorModel.Id,
                FirstName = authorModel.FirstName,
                LastName = authorModel.LastName
            };
        }

        //todo check if this should tie to something else?
        public static IEnumerable<AuthorModel> ToApiModels(this IEnumerable<Author> authors)
        {
            return authors.Select(a => a.ToApiModel());
        }

        public static IEnumerable<Author> ToDomainModel(this IEnumerable<AuthorModel> authorModels)
        {
            return authorModels.Select(a => a.ToDomainModel());
        }
    }
}
