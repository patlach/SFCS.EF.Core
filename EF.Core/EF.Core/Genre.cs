using System;
using System.Collections.Generic;
using System.Text;

namespace EF.Core
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        public List<Book> Books { get; set; } = new List<Book>();
    }
}
