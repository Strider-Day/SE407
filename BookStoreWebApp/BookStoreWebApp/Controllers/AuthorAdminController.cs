using BookStore;
using BookStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace BookStoreWebApp.Controllers
{
    public class AuthorAdminController : Controller
    {
        // GET: AuthorAdminController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AuthorAdminController/Details/5
        public ActionResult Details(int id)
        {
            var author = BookStoreBasicFunctions.GetAuthorById(id);
            return View(author);
        }

        // GET: AuthorAdminController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuthorAdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Author authorToCreate)
        {
            try
            {
                BookStoreAdminFunctions.AddAuthor(authorToCreate);
                return RedirectToAction("Authors", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthorAdminController/Edit/5
        public ActionResult Edit(int id)
        {
            var author = BookStoreBasicFunctions.GetAuthorById(id);
            return View(author);
        }

        // POST: AuthorAdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Author authorToEdit)
        {
            try
            {
                BookStoreAdminFunctions.EditAuthor(authorToEdit);
                return RedirectToAction("Authors", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthorAdminController/Delete/5
        public ActionResult Delete(int id)
        {
            var author = BookStoreBasicFunctions.GetAuthorById(id);
            return View(author);
        }

        // POST: AuthorAdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Author author)
        {
            try
            {
                BookStoreAdminFunctions.DeleteAuthor(author.AuthorId);
                return RedirectToAction("Authors", "Home");
            }
            catch
            {
                return View();
            }
        }
    }
}
