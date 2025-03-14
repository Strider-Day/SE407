using System.Diagnostics;
using BlockBuster.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using BlockBuster;

namespace BlockBuster.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly string[] _myColors;
        private readonly string[] _favCities;
        private readonly string[] _favHobbies;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _myColors = ["red", "green", "blue"];
            _favCities = ["Orlando", "Richmond", "Boston", "Houston", "Seattle"];
            _favHobbies = ["Golf", "Tennis", "Video Games", "Playing with Dog", "Reading Manga"];
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Colors()
        {
            ViewBag.MyColors = _myColors;
            return View();
        }

        public IActionResult Cities()
        {
            ViewBag.FavCities = _favCities;
            return View();
        }

        public IActionResult Hobbies()
        {
            ViewBag.FavCities = _favHobbies;
            return View();
        }

        public IActionResult Movies()
        {
            var movieList = BasicFunctions.GetAllMoviesFull();
            return View(movieList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
