using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieShop.Models;
using MovieShop.ViewModels;

namespace MovieShop.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
             _context.Dispose();
        }

        // GET: Movies
        public ActionResult Index()
        {
//            var movies = GetMovies();
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            return View(movies);
        }

        public ActionResult Detail(int id)
        {
//            var movie = GetMovies().SingleOrDefault(m => m.Id == id);
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            return View(movie);
        }



        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie {Id = 1, Name = "Avenger 4"},
                new Movie {Id = 2, Name = "Mission Impossible"}
            };
        }

        public ActionResult MovieForm()
        {
            MovieFormViewModel movieForm = new MovieFormViewModel
            {
                Genres = _context.Genres.ToList(),
            };
            return View(movieForm);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            var movieForm = new MovieFormViewModel(movie)
            {
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", movieForm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                Movie updateMovie = _context.Movies.Single(m => m.Id == movie.Id);
                updateMovie.Name = movie.Name;
                updateMovie.ReleaseDate = movie.ReleaseDate;
                updateMovie.Genre = movie.Genre;
                updateMovie.NumberInStock = movie.NumberInStock;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }
    }
}