using AutoMapper;
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
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/customers
        //to get all the customers
        public IHttpActionResult GetCustomers()
        {
            return Ok(_context.Customers.ToList().Select(Mapper.Map<Customer,CustomerDto>));
        }

        //GET /api/customers/customerID
        //to get single customer based on ID
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customer,CustomerDto>(customer));

        }

        //POST /api/customers
        //to add a new customer to the database
        [HttpPost]
        public  IHttpActionResult CreateCustomer(CustomerDto customerDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            //Map Dto from User to database object
            var customer = Mapper.Map<CustomerDto, Customer>(customerDTO);

            //save the object 
            _context.Customers.Add(customer);
            _context.SaveChanges();

            //Map the Auto generated ID
            customerDTO.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDTO);
        }


        //PUT /api/customers/customerID
        //To Update existing customer
        [HttpPut]
        public  IHttpActionResult UpdateCustomer(CustomerDto customerDTO, int id)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDB = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(customerDTO, customerInDB);
            
            _context.SaveChanges();
            return Ok();
        }


        //DELETE /api/customer/customerId
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDB = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customerInDB);
            _context.SaveChanges();
            return Ok();
        }







    }
}
