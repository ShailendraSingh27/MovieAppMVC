using AutoMapper;
using RentYourMovie.DTOs;
using RentYourMovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace RentYourMovie.Controllers.Api
{
    public class MoviesController:ApiController
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }


        //GET /api/movies
        //to get all the movies
        public IHttpActionResult GetMovies()
        {
            return Ok(_context.Movies.ToList().Select(Mapper.Map<Movie,MovieDto>));
        }
    }
}