using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Book_Rental.DTOs
{
    public class BookDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime PublishedDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Range(1, 20)]
        public int NumberInStock { get; set; }

        public GenreDTO Genre { get; set; }

        [Required]
        public int GenreId { get; set; }
    }
}