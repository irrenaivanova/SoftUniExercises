using Cinema.App.Data;
using CinemaApp.Data.Models;
using CinemaApp.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using static CinemaApp.Web.Constants.EntityValidationConstants.Movie;

namespace CinemaApp.Web.Controllers
{
    public class MovieController : Controller
    {
        private readonly CinemaDbContext db;

        public MovieController(CinemaDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Movie> movies = db.Movies.ToList();
            return this.View(movies);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }


        [HttpPost]
        public IActionResult Create(InputMovie inputMovie)
        {
            bool isReleaseDateValid = DateTime
               .TryParseExact(inputMovie.ReleaseDate, ReleaseDateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None,
                   out DateTime releaseDate);

            if (!isReleaseDateValid)
            {
                this.ModelState.AddModelError(nameof(inputMovie.ReleaseDate), String.Format("The Release Date must be in the following format: {0}", ReleaseDateFormat));
            }

            if (!this.ModelState.IsValid)
            {
                // Render the same form with user entered values + model errors 
                return this.View(inputMovie);
            }

            Movie movie = new Movie()
            {
                Title = inputMovie.Title,
                Genre = inputMovie.Genre,
                ReleaseDate = releaseDate,
                Director = inputMovie.Director,
                Duration = inputMovie.Duration,
                Description = inputMovie.Description,
            };
                
            db.Movies.AddAsync(movie);
            db.SaveChanges();

            return this.RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(Guid id)
        {
            Movie? movie = db.Movies.FirstOrDefault(x => x.Id == id);

            if (movie == null)
            {
                return this.RedirectToAction(nameof(Index));
            }

            return this.View(movie);
        }
    }
}
