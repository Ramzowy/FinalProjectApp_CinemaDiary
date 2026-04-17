


using Microsoft.AspNetCore.Mvc;
using FinalProjectApp_CinemaDiary.Models;

namespace FinalProjectApp_CinemaDiary.Controllers
{
    public class MovieController : Controller
    {
        // Shared in-memory list used across all actions
        private static List<Movie> GetMovies() => new List<Movie>
        {
            new Movie { Id = 1, Title = "Dune: Part Two",    Year = 2024, Genre = "Sci-Fi",  Rating = 5, Description = "Denis Villeneuve's stunning continuation of Paul Atreides' journey across Arrakis.", ImageUrl = "" },
            new Movie { Id = 2, Title = "Past Lives",         Year = 2023, Genre = "Drama",   Rating = 5, Description = "A quietly devastating meditation on love, choices, and the lives we leave behind.", ImageUrl = "" },
            new Movie { Id = 3, Title = "Oppenheimer",        Year = 2023, Genre = "History", Rating = 5, Description = "Nolan at his most ambitious. A thunderous portrait of brilliance and consequence.", ImageUrl = "" },
            new Movie { Id = 4, Title = "The Substance",      Year = 2024, Genre = "Horror",  Rating = 4, Description = "Bold, grotesque, and audaciously original body-horror about obsession with youth.", ImageUrl = "" },
            new Movie { Id = 5, Title = "Poor Things",        Year = 2023, Genre = "Fantasy", Rating = 5, Description = "A visually intoxicating and wildly inventive reimagining of the Frankenstein myth.", ImageUrl = "" },
            new Movie { Id = 6, Title = "The Zone of Interest", Year = 2023, Genre = "Drama", Rating = 5, Description = "A chilling, unforgettable portrait of banality and evil existing side by side.", ImageUrl = "" },
        };

        public IActionResult Index()
        {
            return View(GetMovies());
        }

        public IActionResult TopPicks()
        {
            var topPicks = GetMovies().Where(m => m.Rating == 5).ToList();
            return View(topPicks);
        }

        public IActionResult Watchlist()
        {
            // Films not yet watched — for now seeded separately
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