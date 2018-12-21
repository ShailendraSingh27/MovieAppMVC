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
    public class CustomersController : Controller
    {
        
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //

        //Customer/Index
        public ViewResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }
        // GET: /Customers/Details
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        //Customer/NewCustomer
        public ActionResult NewCustomer()
        {
            var MembershipType = _context.MembershipTypes;
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes=MembershipType
            };
            return View(viewModel);
        }
        
        [HttpPost]
        public ActionResult Create(Customer customers)
        {
            if (!ModelState.IsValid) 
            {
                var customerViewModel = new CustomerFormViewModel
                {
                    Customers = customers,
                    MembershipTypes = _context.MembershipTypes
                };

                return View("NewCustomer", customerViewModel);
            }

            if (customers.Id == 0)
                _context.Customers.Add(customers);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customers.Id);

                customerInDb.Name = customers.Name;
                customerInDb.BirthDate = customers.BirthDate;
                customerInDb.IsSubscribeToNewsLetter = customers.IsSubscribeToNewsLetter;
                customerInDb.MembershipType = customers.MembershipType;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            var viewModel = new CustomerFormViewModel
            {
                Customers = customer,
                MembershipTypes = _context.MembershipTypes
            };
            return View("NewCustomer", viewModel);
        }

	}
}