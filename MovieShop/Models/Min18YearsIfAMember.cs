using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieShop.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer) validationContext.ObjectInstance; 
            //it give we the way to access Customer object (Customer class have properties use this validation)

//            if (customer.MembershipTypeId == 0 || customer.MembershipTypeId == 1)
            if (customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PasAsYouGo)
            {
                return ValidationResult.Success;
            }

            if (customer.Birthday == null)
            {
                return new ValidationResult("Birthday is required");
            }

            var age = DateTime.Now.Year - customer.Birthday.Value.Year;
            if (age <= 18)
            {
                return new ValidationResult("Customer should be at least 18 year old");
            }

            return ValidationResult.Success;

        }
    }
}