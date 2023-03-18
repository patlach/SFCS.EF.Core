using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace EF.Core
{
    public class AppContext : DbContext
    {
        // Объекты таблицы Users
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        
        public DbSet<Genre> Genre { get; set; }


        public AppContext()
        {
            //Database.EnsureCreated();
        }

        internal IList<User> ToList()
        {
            throw new NotImplementedException();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\MSSQLSERVER01;Database=EF;Trusted_Connection=true;");
        }
    }
}
