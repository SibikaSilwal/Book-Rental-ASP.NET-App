using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Book_Rental.Models;
using System.ComponentModel.DataAnnotations;

namespace Book_Rental.Models
{
    public class Rental
    {
        public int Id { get; set; }

        [Required]
        public Customer customer { get; set; }

        [Required]
        public Book book { get; set; }

        public DateTime DateRented { get; set; }

        public DateTime? DateReturned { get; set; }

    }
}