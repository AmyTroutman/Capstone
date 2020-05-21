using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.Core.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Book> Books { get; set; }

        public ICollection<Series> Series { get; set; }
    }
}
