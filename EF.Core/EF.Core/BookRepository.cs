using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF.Core
{
    public class BookRepository
    {
        public Book SelectByID(AppContext context, int id)
        {
            return context.Books.FirstOrDefault(x => x.Id == id);
        }

        public IList<Book> SelectAll(AppContext context)
        {
            return context.Books.ToList();
        }

        public void Add(AppContext context, Book book)
        {
            try
            {
                context.Books.Add(book);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Update(AppContext context, int bookIdForUpdate, Book updateBookData)
        {
            var book = context.Books.FirstOrDefault(x => x.Id == bookIdForUpdate);

            book.Name = updateBookData.Name;
            book.Author = updateBookData.Author;
            book.YearOfIssue = updateBookData.YearOfIssue;

            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //Задание 25.5.4
        //1. 
        public List<Book> ListOfBookByGenreBetweenYears(AppContext context, Genre genre, int startYear, int endYear)
        {
            return context.Books
                .Select(x => x)
                .Where(x => x.GenreList.Contains(genre) && x.YearOfIssue >= startYear && x.YearOfIssue <= endYear)
                .ToList();
        }

        //2.  
        public int TotalBooksByAuthor (AppContext context, string author)
        {
            return context.Books.Count(x => x.Author == author);
        } 

        //3.  
        public int TotalBooksByGenre(AppContext context, Genre genre)
        {
            return context.Books.Count(x => x.GenreList.Contains(genre));
        }

        //4.  
        public bool IsHaveBookByNameAndAuthor(AppContext context, string name, string author)
        {
            return context.Books.Any(x => x.Name == name && x.Author == author);
        }

        //5.  
        public bool BookUseByUserName(AppContext context, string userName, string bookName)
        {
            return context.Books.Any(x => x.Name == bookName && x.User.Name == userName);
        }

        //6. 
        public int TotalBooksOfUser(AppContext context, string user)
        {
            return context.Books.Where(x => x.User.Name == user).Count();
        }

        //7.  
        public Book BookByLastYear(AppContext context)
        {
            return context.Books.OrderByDescending(x => x.YearOfIssue).First();
        }

        //8.  
        public List<Book> AllBooksDesk(AppContext context)
        {
            return context.Books.OrderBy(x => x.Name).ToList();
        }

        //9.  
        public List<Book> AllBooksByYearAsc(AppContext context)
        {
            return context.Books.OrderByDescending(X => X.YearOfIssue).ToList();
        }
    }
}
