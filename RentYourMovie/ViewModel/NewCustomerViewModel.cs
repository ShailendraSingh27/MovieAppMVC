using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using RentYourMovie.Models;

namespace RentYourMovie.ViewModel
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customers { get; set; }
    }
}