using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Book_Rental.Models
{
    public class Book
    {
        //properties
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Published Date")]
        public DateTime PublishedDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Display(Name = "Number in Stock")]
        [Range(1,20)]
        public int NumberInStock { get; set; }

        public byte NumberAvailable { get; set; }

        public Genre Genre { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public int GenreId { get; set; }
    }

    // /book/random //randomly pick a book to see its details
}