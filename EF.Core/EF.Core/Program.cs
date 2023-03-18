using System;
using System.Linq;

namespace EF.Core
{
    internal class Program
    {
        static void Main(string[] args)
        {

            using (var db = new AppContext())
            {
                var user1 = new User { Name = "Egor" };
                var user2 = new User { Name = "Fikus" };

                var book1 = new Book { Name = "Book1", Author = "Bookov", YearOfIssue = 2001 };
                var book2 = new Book { Name = "Book2", Author = "Bookov", YearOfIssue = 2002 };
                var book3 = new Book { Name = "Book3", Author = "Bookov", YearOfIssue = 2003 };

                book1.User = user1;
                book2.User = user1;
                book3.User = user2;

                user1.Books.Add(book1);
                user1.Books.Add(book2);

                db.Books.AddRange(book1, book2, book3);
                db.Users.AddRange(user1, user2);
                db.SaveChanges();

                //BookRepository bookRepository = new BookRepository();

                //var user = db.Users.Where(x => x.Name == "Egor").First();
                //var genre = db.Genre.Where(x => x.Name == "pop").First();

                //var a = bookRepository.ListOfBookByGenreBetweenYears(db, genre, 2006, 2007);


                //foreach(Book book in a)
                //{
                //   Console.WriteLine(@"{0}, {1}" ,book.Name, book.YearOfIssue);
                //}
            }
        }
    }
}
