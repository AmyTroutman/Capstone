using LibraryApp.Core.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
                //UserId = catalog.User.Id,
                //User = catalog.User.FullName
            };
        }

        public static Catalog ToDomainModel(this CatalogModel catalogModel)
        {
            return new Catalog
            {
                Id = catalogModel.Id,
                Name = catalogModel.Name,
                //UserId = catalogModel.UserId
            };
        }

        //todo check if this should tie to Users
        public static IEnumerable<CatalogModel> ToApiModels(this IEnumerable<Catalog> catalogs)
        {
            return catalogs.Select(a => a.ToApiModel());
        }

        public static IEnumerable<Catalog> ToDomainModels(this IEnumerable<CatalogModel> catalogModels)
        {
            return catalogModels.Select(a => a.ToDomainModel());
        }
    }
}
