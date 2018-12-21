using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

using RentYourMovie.Models;
using RentYourMovie.ViewModel;

namespace RentYourMovie.Controllers
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

        // GET: /Movies/
        public ActionResult Index()
        {
            
            var movie = _context.Movies.Include(m=>m.Genre).ToList();
            return View(movie);
        }


        public ActionResult NewMovieForm()
        {
            var Genre = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel
            {
                Genres = Genre
            };
            return View(viewModel);
        }


        public ActionResult Create(Movie movies)
        {
            if(movies.Id == 0)
                _context.Movies.Add(movies);
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movies.Id);

                movieInDb.Name = movies.Name;
                movieInDb.ReleaseDate = movies.ReleaseDate;
                movieInDb.GenreId = movies.GenreId;
                movieInDb.DateAdded = movies.DateAdded;
                movieInDb.NumberInStock = movies.NumberInStock;
            }
            _context.SaveChanges();
            return RedirectToAction("Index","Movies");
        }


        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();
            var movieViewModel = new MovieFormViewModel{
                Movies = movie,
                Genres = _context.Genres
            };
            return View("NewMovieForm", movieViewModel);
        }




        public ActionResult Details(int Id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == Id);
            return View(movie);
        }


        // GET: /Movies/Random
       
	}
}