using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieShop.Models;

namespace MovieShop.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.ToList();
            return View(customers);
        }

        public ActionResult Detail(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
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
    }
}