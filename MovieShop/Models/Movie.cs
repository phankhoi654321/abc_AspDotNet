using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MovieShop.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [ForeignKey("Genre")]
        public byte GenreId { get; set; }
        public virtual Genre Genre { get; set; }
        
        [Display (Name = "Realease Date")]
        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        
        [Display(Name = "Number In Stock")]
        [Required]
        [Range(1, 20)]
        public byte NumberInStock { get; set; }
    }
}