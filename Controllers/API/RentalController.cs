using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Book_Rental.Models;
using Book_Rental.DTOs;
using AutoMapper;

namespace Book_Rental.Controllers.API
{
    public class RentalController : ApiController
    {
        private ApplicationDbContext _context;

        public RentalController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRental(RentalDTO newRental)
        {
            if (newRental.BookIds.Count == 0)
                return BadRequest("No book ids provided.");

            var customer = _context.Customers.SingleOrDefault( c => c.Id == newRental.CustomerId );

            if (customer == null)
                return BadRequest("Customer id is not valid.");

            var books = _context.Books.Where(b => newRental.BookIds.Contains(b.Id)).ToList();

            if (books.Count != newRental.BookIds.Count)
                return BadRequest("One or more Book Ids are invalid.");

            foreach(var book in books)
            {
                if (book.NumberAvailable == 0)
                    return BadRequest("Book is not available");

                book.NumberAvailable-- ;

                var rental = new Rental()
                {
                    customer = customer,
                    book = book,
                    DateRented = DateTime.Now                  
                };

                _context.Rentals.Add(rental);              
            }
            _context.SaveChanges();

            return Ok();
        }
    }
}