using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.Core.Models
{
    public class Catalog
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //if adding users, uncomment
        public string UserId { get; set; }
        public User User { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
