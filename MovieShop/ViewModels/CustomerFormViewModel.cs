﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieShop.Models;

namespace MovieShop.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        //public List<MembershipType> MembershipTypes { get; set; }

        public Customer Customer { get; set; }
        
    }
}