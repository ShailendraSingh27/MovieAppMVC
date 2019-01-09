using RentYourMovie.DTOs;
using RentYourMovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RentYourMovie.Controllers.Api
{
    public class NewRentalController : ApiController
    {
        ApplicationDbContext _context;
        public NewRentalController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(RentalDto rentalDto)
        {
            var customer = _context.Customers.Single(
                c => c.Id == rentalDto.CustomerId);

            var movies = _context.Movies.Where(
                m => rentalDto.MovieIds.Contains(m.Id)).ToList();

            foreach(var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is snot available.");

                //Decreasing numberAvailable
                movie.NumberAvailable--;
                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };
                _context.Rentals.Add(rental);
            }//End of foreach

            _context.SaveChanges();

            return Ok();

        }
    }
}
