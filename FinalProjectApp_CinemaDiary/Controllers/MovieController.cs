


using FinalProjectApp_CinemaDiary.Models;
using FinalProjectApp_CinemaDiary.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectApp_CinemaDiary.Controllers
{
    public class MovieController : Controller
    {


        private readonly ApplicationDbContext context;

        public MovieController(ApplicationDbContext context)
        {
            this.context = context;
        }


        private List<Movie> GetMovies()
        {
            return context.Movies.ToList();
        }

        public IActionResult Index()
        {
            var movies = context.Movies.ToList();
            return View(movies);
        }

        public IActionResult TopPicks()
        {
            var topPicks = context.Movies.Where(m => m.Rating == 8).ToList();
            return View(topPicks);
        }

        public IActionResult Watchlist()
        {
            
            var watchlist = new List<Movie>
            { 
                new Movie { Id = 7,  Title = "Anora",            Year = 2024, Genre = "Drama",   Rating = 0, Description = "Sean Baker's Palme d'Or winner about a young woman whose life is upended by an impulsive marriage.", ImageUrl = "" },
                new Movie { Id = 8,  Title = "Nosferatu",        Year = 2024, Genre = "Horror",  Rating = 0, Description = "Robert Eggers' long-awaited gothic reimagining of the classic vampire tale.", ImageUrl = "" },
                new Movie { Id = 9,  Title = "Conclave",         Year = 2024, Genre = "Thriller",Rating = 0, Description = "Edward Berger directs this tense thriller set inside the secretive election of a new Pope.", ImageUrl = "" },
                new Movie { Id = 10, Title = "A Real Pain",      Year = 2024, Genre = "Drama",   Rating = 0, Description = "Jesse Eisenberg's touching story of two cousins travelling Poland to honour their grandmother.", ImageUrl = "" },
            };
            return View(watchlist);
        }

        public IActionResult Details(int id)
        {
            var movie = GetMovies().FirstOrDefault(m => m.Id == id);
            if (movie == null) return NotFound();
            return View(movie);
        }
    }
}