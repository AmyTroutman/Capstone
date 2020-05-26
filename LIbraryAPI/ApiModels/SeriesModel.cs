using LibraryApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp.ApiModels
{
    public class SeriesModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<BookModel> Books { get; set; }

        public int AuthorId { get; set; }
        public string Author { get; set; }
    }
}
