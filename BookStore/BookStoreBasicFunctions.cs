using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    public static class BookStoreBasicFunctions
    {
        public static Book? GetBookByTitle(string title)
        {
            using(var context = new Se407BookstoreContext())
            {
                return context.Books.FirstOrDefault(t => t.BookTitle == title);
            }
        }
        public static List<Book> GetAllBooks()
        {
            using (var context = new Se407BookstoreContext())
            {
                return context.Books.ToList();
            }
        }
        public static List<Book> GetBooksbyAuthor(String last) 
        {
            using (var context = new Se407BookstoreContext())
            {
                return context.Authors.Where(l => l.AuthorLast.Equals(last)).Join
                    (
                        context.Books,
                        t => t.AuthorId,
                        m => m.AuthorId,
                        (t, m) => m
                    ).ToList();
            }
        }
    }
}
