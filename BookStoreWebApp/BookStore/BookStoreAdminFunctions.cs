using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore
{
    public class BookStoreAdminFunctions
    {
        public static void AddBook(Book book)
        {
            try
            {
                using (var db = new Se407BookstoreContext())
                {
                    db.Books.Add(book);
                    db.SaveChanges();
                }
            }catch (Exception ex) { }
        }

        public static void AddGenre(Genre genre)
        {
            try
            {
                using (var db = new Se407BookstoreContext())
                {
                    db.Genres.Add(genre);
                    db.SaveChanges();
                }
            }
            catch (Exception ex) { }
        }

        public static void AddAuthor(Author author)
        {
            try
            {
                using (var db = new Se407BookstoreContext())
                {
                    db.Authors.Add(author);
                    db.SaveChanges();
                }
            }
            catch (Exception ex) { }
        }

        public static void DeleteBook(int id)
        {
            try
            {
                using (var db = new Se407BookstoreContext())
                {
                    var bookToDelete = db.Books.Find(id);
                    db.Books.Remove(bookToDelete);
                    db.SaveChanges();
                }
            }
            catch (Exception ex) { }
        }

        public static void DeleteGenre(int id)
        {
            try
            {
                using (var db = new Se407BookstoreContext())
                {
                    var genreToDelete = db.Genres.Find(id);
                    db.Genres.Remove(genreToDelete);
                    db.SaveChanges();
                }
            }
            catch (Exception ex) { }
        }

        public static void DeleteAuthor(int id)
        {
            try
            {
                using (var db = new Se407BookstoreContext())
                {
                    var authorToDelete = db.Authors.Find(id);
                    db.Authors.Remove(authorToDelete);
                    db.SaveChanges();
                }
            }
            catch (Exception ex) { }
        }

        public static void EditBook(Book book)
        {
            try
            {
                using (var db = new Se407BookstoreContext())
                {
                    db.Books.Update(book);
                    db.SaveChanges();
                }
            }
            catch (Exception ex) { }
        }

        public static void EditGenre(Genre genre)
        {
            try
            {
                using (var db = new Se407BookstoreContext())
                {
                    var existingGenre = db.Genres.Find(genre.GenreId);

                    if (existingGenre != null)
                    {
                        db.Entry(existingGenre).CurrentValues.SetValues(genre);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex) { }
        }

        public static void EditAuthor(Author author)
        {
            try
            {
                using (var db = new Se407BookstoreContext())
                {
                    var existingAuthor = db.Authors.Find(author.AuthorId);

                    if (existingAuthor != null)
                    {
                        db.Entry(existingAuthor).CurrentValues.SetValues(author);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex) { }
        }
    }
}
