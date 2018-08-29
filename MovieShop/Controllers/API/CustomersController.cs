using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using MovieShop.Dtos;
using MovieShop.Models;

namespace MovieShop.Controllers.API
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/customers
        public IEnumerable<CustomerDto> GetCustomers() //Use Object is CustomerDto
        {
            return _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>); //Use Delegate to map customer to customerDto
        }

        //GET /api/customers/1
        public IHttpActionResult GetCustomer(int id)      ////Use IHttpActionResult to return the ActionResult replace for Return object is CustomerDto
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Customer, CustomerDto>(customer));     //map customer to customerDto
        }

        //POST /api/customers 
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)  //Use IHttpActionResult to return the ActionResult
        {
            if (!ModelState.IsValid)        //this check from DataAnnotion
            {
                return BadRequest();    //this method come from IHttpActionResult helper Method of class Http.Result
            }

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);  //map customerDto to customer
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;  //because Id is identity

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto );
            //Created(Uri location, T content) | Uri location : /api/customers/10 
        }

        //PUT /api/customers/1
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            // Mapper.Map(customerDto, customerInDb); //Install-Package AutoMapper
            /*
            customerDto.Name = customerInDb.Name;
            customerDto.Birthday = customerInDb.Birthday;
            customerDto.IsSubscribedToNewsLetter = customerInDb.IsSubscribedToNewsLetter;
            customerDto.MembershipTypeId = customerInDb.MembershipTypeId;
            */
            Mapper.Map<CustomerDto, Customer>(customerDto, customerInDb);

            _context.SaveChanges();
        }

        //DELETE /api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }
    }
}
