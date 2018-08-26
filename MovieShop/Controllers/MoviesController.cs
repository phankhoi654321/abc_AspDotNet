using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieShop.Models;

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
    }
}