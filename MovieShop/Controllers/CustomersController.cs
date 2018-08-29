using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using MovieShop.Models;
using MovieShop.ViewModels;

namespace MovieShop.Controllers
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

        public ActionResult CustomerForm()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes,
                Customer = new Customer()       //this will make default value like Id = 0;
            };
            return View(viewModel);
        }
        [HttpPost] //Only post
        [ValidateAntiForgeryToken]  //Check must be post with value token
        public ActionResult Save(Customer customer)  //model binding
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList(),
                };

                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);   //This save on memory not on database, after that mus be SaveChange()
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                /*
                TryUpdateModel(customerInDb);   //this way will open the security hall and check all properties of Model
                TryUpdateModel(customerInDb, "", new string[]{"Name", "Email"}); 
                //this way change properties Name and Email, but later if you change the properties on model class must be manual fix in here
                */

                //Mapper.Map(customer, customerInDb); //Install-Package AutoMapper
                customerInDb.Name = customer.Name;
                customerInDb.Birthday = customer.Birthday;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            }
            
            _context.SaveChanges();             //Must be use it to save on database


            return RedirectToAction("Index", "Customers");
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.Membershiptype).ToList();
            return View(customers);
        }

        public ActionResult Detail(int id)
        {
            var customer = _context.Customers.Include(c => c.Membershiptype).SingleOrDefault(c => c.Id == id);
            return View(customer);
        }

        /*
        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer {Id = 1, Name = "Mai Van Khanh"},
                new Customer {Id = 2, Name = "Tran Van Tuan"}
            };
        }
        */
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }

        public ActionResult Delete(int id)
        {
            var customerDelete = _context.Customers.SingleOrDefault(c => c.Id == id);
            _context.Customers.Remove(customerDelete);
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }
    }
}