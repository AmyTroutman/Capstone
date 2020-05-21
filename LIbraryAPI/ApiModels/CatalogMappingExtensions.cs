using LibraryApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp.ApiModels
{
    public static class CatalogMappingExtensions
    {
        public static CatalogModel ToApiModel(this Catalog catalog)
        {
            return new CatalogModel
            {
                Id = catalog.Id,
                Name = catalog.Name,
                UserId = catalog.UserId,
                OwnerName = catalog.User.FullName
            };
        }

        public static Catalog ToDomainModel(this CatalogModel catalogModel)
        {
            return new Catalog
            {
                Id = catalogModel.Id,
                Name = catalogModel.Name,
                UserId = catalogModel.UserId,
                OwnerName = catalogModel.User
            };
        }

        //todo check if this should tie to Users
        public static IEnumerable<CatalogModel> ToApiModels(this IEnumerable<Catalog> Users)
        {
            return Users.Select(a => a.ToApiModel());
        }

        public static IEnumerable<Catalog> ToDomainModels(this IEnumerable<CatalogModel> UserModels)
        {
            return UserModels.Select(a => a.ToDomainModel());
        }
    }
}
