﻿using AutoMapper;
using RentYourMovie.DTOs;
using RentYourMovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
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
        //public IHttpActionResult GetMovies()
        //{
        //    var movieDto = _context.Movies
        //        .Include(c => c.Genre)
        //        .ToList()
        //        .Select(Mapper.Map<Movie, MovieDto>);

        //    return Ok(movieDto);
        //}


        public IHttpActionResult GetMovies(string query = null)
        {
            var moviesQuery = _context.Movies
               .Include(m => m.Genre)
               .Where(m => m.NumberAvailable > 0);

            if (!String.IsNullOrWhiteSpace(query))
                moviesQuery = moviesQuery.Where(m => m.Name.Contains(query));

            var movieDto = moviesQuery
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);

            return Ok(movieDto);
        }

        //GET /api/movies/movieID
        //to get movie by its id
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            
            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie,MovieDto>(movie));
        }


        //POST /api/movies
        //to add a new movie
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            //Map Dto to Movie
            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            movie.NumberAvailable = movie.NumberInStock;
            _context.Movies.Add(movie);
            _context.SaveChanges();

            //set ID in DTO
            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }


        //PUT /api/movies/movieID
        //to update detail of a movie
        [Authorize(Roles = RoleName.CanManageMovies)]
        [HttpPut]
        public  IHttpActionResult UpdateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerInDb = _context.Movies.SingleOrDefault(m => m.Id == movieDto.Id);
            if (customerInDb == null)
                return NotFound();

            Mapper.Map(movieDto, customerInDb);
            _context.SaveChanges();

            return Ok();
        }

        //DELETE /api/movies/movieID
        //to Delete perticular movie
        [Authorize(Roles = RoleName.CanManageMovies)]
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
                return NotFound();

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}