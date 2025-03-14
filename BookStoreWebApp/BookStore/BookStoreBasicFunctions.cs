using BookStore.Models;
using Microsoft.EntityFrameworkCore;
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
        public static Book? GetBookById(int id)
        {
            using (var context = new Se407BookstoreContext())
            {
                var book = context.Books
                    .Include(d => d.Genre)
                    .Include(d => d.Author)
                    .Where(d => d.BookId == id)
                    .FirstOrDefault();

                return book;
            }
        }

        public static List<Book> GetAllBooks()
        {
            using (var context = new Se407BookstoreContext())
            {
                var books = context.Books
                    .Include(books => books.Genre)
                    .Include(books => books.Author)
                    .ToList();
                
                return books;
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
        public static List<Genre> GetAllGenres()
        {
            using (var context = new Se407BookstoreContext())
            {
                return context.Genres.ToList();
            }
        }
        public static Genre? GetGenreById(int id)
        {
            using (var context = new Se407BookstoreContext())
            {
                return context.Genres.FirstOrDefault(g => g.GenreId == id);
            }
        }

        public static List<Author> GetAllAuthors()
        {
            using (var context = new Se407BookstoreContext())
            {
                return context.Authors.ToList();
            }
        }

        public static Author? GetAuthorById(int id)
        {
            using (var context = new Se407BookstoreContext())
            {
                return context.Authors.FirstOrDefault(a => a.AuthorId == id);
            }
        }
    }
}
