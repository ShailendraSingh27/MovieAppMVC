using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RentYourMovie.Models;

namespace RentYourMovie.ViewModel
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public Movie Movies { get; set; }
    }
}