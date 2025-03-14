using BookStoreWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BookStore;

namespace BookStoreWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Books()
        {
            var bookList = BookStoreBasicFunctions.GetAllBooks();
            return View(bookList);
        }

        public IActionResult Genres()
        {
            var genreList = BookStoreBasicFunctions.GetAllGenres();
            return View(genreList);
        }

        public IActionResult Authors()
        {
            var authorList = BookStoreBasicFunctions.GetAllAuthors();
            return View(authorList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
