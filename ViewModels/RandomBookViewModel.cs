using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Book_Rental.Models;

namespace Book_Rental.ViewModels
{
    public class RandomBookViewModel
    {
        public Book Book { get; set; }
        public List<Book> Books { get; set; }
        public List<Customer> Customers { get; set; }
    }
}