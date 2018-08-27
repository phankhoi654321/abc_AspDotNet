using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieShop.Models;

namespace MovieShop.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<Membershiptype> MembershipTypes { get; set; }
        //public List<Membershiptype> MembershipTypes { get; set; }

        public Customer Customer { get; set; }
        
    }
}