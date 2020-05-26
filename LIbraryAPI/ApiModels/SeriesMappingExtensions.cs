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
                AuthorId = seriesModel.AuthorId
            };
        }

        //todo check if this is correct
        public static IEnumerable<SeriesModel> ToApiModels(this IEnumerable<Series> series)
        {
            return series.Select(a => a.ToApiModel());
        }

        public static IEnumerable<Series> ToDomainModel(this IEnumerable<SeriesModel> seriesModels)
        {
            return seriesModels.Select(a => a.ToDomainModel());
        }
    }
}
