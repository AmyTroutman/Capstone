using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace LibraryApp.ApiModels
{
    public class BookModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Notes { get; set; }
        public string Medium { get; set; }
        //public string BranchName { get; set; }

        public int AuthorId { get; set; }
        public string Author { get; set; }

        public int SeriesId { get; set; }
        public string Series { get; set; }

        /*public int CatalogId { get; set; }
        public string Catalog { get; set; }*/
    }
}
