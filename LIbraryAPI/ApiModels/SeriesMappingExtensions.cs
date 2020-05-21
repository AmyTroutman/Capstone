using LibraryApp.Core.Models;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp.ApiModels
{
    public static class SeriesMappingExtensions
    {
        public static SeriesModel ToApiModel(this Series series)
        {
            return new SeriesModel
            {
                Id = series.Id,
                Name = series.Name,
                NumInSeries = series.NumInSeries,
                AuthorId = series.AuthorId,
                Author = series.Author != null ? series.Author.LastName + ", " + series.Author.FirstName : null
            };
        }

        public static Series ToDomainModel(this SeriesModel seriesModel)
        {
            return new Series
            {
                Id = seriesModel.Id,
                Name = seriesModel.Name,
                NumInSeries = seriesModel.NumInSeries,
                AuthorId = seriesModel.AuthorId
            };
        }

        //todo check, but pretty sure I want series tied to author
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
