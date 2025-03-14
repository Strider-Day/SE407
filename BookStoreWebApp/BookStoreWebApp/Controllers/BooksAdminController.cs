using BookStore;
using BookStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStoreWebApp.Controllers
{
    public class BooksAdminController : Controller
    {
        // GET: BooksAdminController
        public ActionResult Index()
        {
            return View();
        }

        // GET: BooksAdminController/Details/5
        public ActionResult Details(int id)
        {
            var book = BookStoreBasicFunctions.GetBookById(id);
            return View(book);
        }

        // GET: BooksAdminController/Create
        public ActionResult Create()
        {
            var genres = new SelectList(BookStoreBasicFunctions.GetAllGenres()
                .OrderBy(g => g.GenreType)
                .ToDictionary(g => g.GenreId, g => g.GenreType), "Key", "Value");
            ViewBag.GenreId = genres;

            var authors = new SelectList(BookStoreBasicFunctions.GetAllAuthors()
                .OrderBy(a => a.AuthorLast)
                .ToDictionary(a => a.AuthorId, a => a.AuthorLast+", " + a.AuthorFirst), "Key", "Value");
            ViewBag.AuthorId = authors;

            return View();
        }

        // POST: BooksAdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book bookToCreate)
        {
            try
            {
                BookStoreAdminFunctions.AddBook(bookToCreate);
                return RedirectToAction("Books", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: BooksAdminController/Edit/5
        public ActionResult Edit(int id)
        {
            var book = BookStoreBasicFunctions.GetBookById(id);
            var genres = new SelectList(BookStoreBasicFunctions.GetAllGenres()
                .OrderBy(g => g.GenreType)
                .ToDictionary(g => g.GenreId, g => g.GenreType), "Key", "Value");
            ViewBag.GenreId = genres;

            var authors = new SelectList(BookStoreBasicFunctions.GetAllAuthors()
                .OrderBy(a => a.AuthorLast)
                .ToDictionary(a => a.AuthorId, a => a.AuthorLast + ", " + a.AuthorFirst), "Key", "Value");
            ViewBag.AuthorId = authors;

            return View(book);
        }

        // POST: BooksAdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book bookToEdit)
        {
            try
            {
                BookStoreAdminFunctions.EditBook(bookToEdit);
                return RedirectToAction("Books", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: BooksAdminController/Delete/5
        public ActionResult Delete(int id)
        {
            var book = BookStoreBasicFunctions.GetBookById(id);
            return View(book);
        }

        // POST: BooksAdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Book book)
        {
            try
            {
                BookStoreAdminFunctions.DeleteBook(book.BookId);
                return RedirectToAction("Books", "Home");
            }
            catch
            {
                return View();
            }
        }
    }
}
