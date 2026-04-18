using FinalProjectApp_CinemaDiary.Models;
using FinalProjectApp_CinemaDiary.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FinalProjectApp_CinemaDiary.Controllers
{
    public class HomeController : Controller
    {


        private readonly ApplicationDbContext context;

        public HomeController(ApplicationDbContext context)
        {
            this.context = context;
        }


        public IActionResult Index()
        {
            var recentMovies = context.Movies                          // Randomize the 4 items
                                .OrderBy(m => Guid.NewGuid())
                                .Take(4)     
                                .ToList();

            ViewBag.RecentMovies = recentMovies;
            ViewBag.TotalMovies = context.Movies.Count();
            ViewBag.TotalGenres = context.Movies.Select(m => m.Genre).Distinct().Count();

            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult MovieThoughts()
        {
            return View();
        }

        public IActionResult RealFacts()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}