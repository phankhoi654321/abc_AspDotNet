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
        public string Name { get; set; }
        [ForeignKey("Genre")]
        public byte GenreId { get; set; }
        public virtual Genre Genre { get; set; }
        
        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }
        public byte NumberInStock { get; set; }
    }
}