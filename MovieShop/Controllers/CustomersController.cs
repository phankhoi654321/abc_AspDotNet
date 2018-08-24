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
        // GET: Customers
        public ActionResult Index()
        {
            var customers = GetCustomers();
            return View(customers);
        }

        public ActionResult Detail(int id)
        {
            var customer = GetCustomers().SingleOrDefault(c => c.Id == id);
            return View(customer);
        }

        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer {Id = 1, Name = "Mai Van Khanh"},
                new Customer {Id = 2, Name = "Tran Van Tuan"}
            };
        }
    }
}