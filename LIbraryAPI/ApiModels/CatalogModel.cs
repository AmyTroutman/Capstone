using LibraryApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp.ApiModels
{
    public class CatalogModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //if you add users:
        //public string UserId { get; set; }
        //public string OwnerName { get; set; }
    }
}
