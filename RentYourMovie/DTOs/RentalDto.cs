using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentYourMovie.DTOs
{
    public class RentalDto
    {
        public int CustomerId { get; set; }
        public List<int> MovieIds { get; set; }
    }
}