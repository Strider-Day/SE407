using BookStore;
using BookStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreWebApp.Controllers
{
    public class GenreAdminController : Controller
    {
        // GET: GenreAdminController
        public ActionResult Index()
        {
            return View();
        }

        // GET: GenreAdminController/Details/5
        public ActionResult Details(int id)
        {
            var genre = BookStoreBasicFunctions.GetGenreById(id);
            return View(genre);
        }

        // GET: GenreAdminController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GenreAdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Genre genretoCreate)
        {
            try
            {
                BookStoreAdminFunctions.AddGenre(genretoCreate);
                return RedirectToAction("Genres", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: GenreAdminController/Edit/5
        public ActionResult Edit(int id)
        {
            var genre = BookStoreBasicFunctions.GetGenreById(id);
            return View(genre);
        }

        // POST: GenreAdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Genre genreToEdit)
        {
            try
            {
                BookStoreAdminFunctions.EditGenre(genreToEdit);
                return RedirectToAction("Genres", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: GenreAdminController/Delete/5
        public ActionResult Delete(int id)
        {
            var genre = BookStoreBasicFunctions.GetGenreById(id);
            return View(genre);
        }

        // POST: GenreAdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Genre genre)
        {
            try
            {
                BookStoreAdminFunctions.DeleteGenre(genre.GenreId);
                return RedirectToAction("Genres", "Home");
            }
            catch
            {
                return View();
            }
        }
    }
}
