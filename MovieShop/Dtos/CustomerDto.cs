using System;
using System.ComponentModel.DataAnnotations;
using MovieShop.Models;

namespace MovieShop.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public MembershipTypeDto MembershipType { get; set; }

        public byte MembershipTypeId { get; set; }

//        [Min18YearsIfAMember]
        public DateTime? Birthday { get; set; }

    }
}