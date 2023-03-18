using System;
using System.Collections.Generic;
using System.Text;

namespace EF.Core
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int YearOfIssue { get; set; }

        public int UserID;
        public User User { get; set; }

        public List<Genre> GenreList { get; set; } = new List<Genre>();
    }
}
