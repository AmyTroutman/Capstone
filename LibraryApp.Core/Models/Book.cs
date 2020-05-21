using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace LibraryApp.Core.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Notes { get; set; }
        public string Medium { get; set; }
        public string BranchName { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public int SeriesId { get; set; }
        public Series Series { get; set; }

        public int CatalogId { get; set; }
        public Catalog Catalog { get; set; }
    }
}
