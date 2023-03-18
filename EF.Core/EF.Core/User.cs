using System;
using System.Collections.Generic;
using System.Text;

namespace EF.Core
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public string Phone { get; set; }

        public List<Book> Books { get; set; } = new List<Book>();
    }
}
