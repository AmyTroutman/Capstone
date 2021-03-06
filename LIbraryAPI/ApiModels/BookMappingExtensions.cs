﻿using LibraryApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp.ApiModels
{
    public static class BookMappingExtensions
    {
        public static BookModel ToApiModel(this Book book)
        {
            return new BookModel
            {
                Id = book.Id,
                Title = book.Title,
                Genre = book.Genre,
                Notes = book.Notes,
                Medium = book.Medium,
                AuthorId = book.AuthorId,
                Author = book.Author != null ? book.Author.LastName + ", " + book.Author.FirstName : null,
                SeriesId = book.SeriesId,
                Series =  book.Series?.Name,
                NumInSeries = book.NumInSeries,
                CatalogId = book.CatalogId,
                Catalog = book.Catalog?.Name
            };
        }

        public static Book ToDomainModel(this BookModel bookModel)
        {
            return new Book
            {
                Id = bookModel.Id,
                Title = bookModel.Title,
                Genre = bookModel.Genre,
                Notes = bookModel.Notes,
                Medium = bookModel.Medium,
                AuthorId = bookModel.AuthorId,
                SeriesId = bookModel.SeriesId,
                NumInSeries = bookModel.NumInSeries,
                CatalogId = bookModel.CatalogId
            };
        }

        //todo check if this should tie to catalog or user, rather than author
        public static IEnumerable<BookModel> ToApiModels(this IEnumerable<Book> books)
        {
            return books.Select(a => a.ToApiModel());
        }

        public static IEnumerable<Book> ToDomainModel(this IEnumerable<BookModel> bookModels)
        {
            return bookModels.Select(a => a.ToDomainModel());
        }
    }
}
