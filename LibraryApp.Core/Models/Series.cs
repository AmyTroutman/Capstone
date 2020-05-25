using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.Core.Models
{
    public class Series
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumInSeries { get; set; }

        public ICollection<Book> Books { get; set; }

        /*public int AuthorId { get; set; }
        public Author Author { get; set; }*/
    }
}
