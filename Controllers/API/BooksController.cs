using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Data.Entity;
using System.Web.Http;
using Book_Rental.Models;
using Book_Rental.DTOs;
using AutoMapper;

namespace Book_Rental.Controllers.API
{
    public class BooksController : ApiController
    {

        private ApplicationDbContext _context;

        public BooksController()
        {
            _context = new ApplicationDbContext();
        }

        // GET request to /api/books
        public IHttpActionResult GetBooks(string query = null)
        {
            var booksQuery = _context.Books
                .Include(b => b.Genre)
                .Where(b => b.NumberAvailable > 0);

            if (!String.IsNullOrWhiteSpace(query))
                booksQuery = booksQuery.Where(b => b.Name.Contains(query));

            var bookDTOs = booksQuery
                .ToList()
                .Select(Mapper.Map<Book, BookDTO>);

            return Ok(bookDTOs);
        }

        // GET /api/books/1
        public IHttpActionResult GetBook(int id)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == id);

            if (book == null)
                return NotFound();

            return Ok(Mapper.Map<Book, BookDTO>(book));
        }

        // POST /api/books
        [HttpPost]
        public IHttpActionResult CreateBook(BookDTO bookdto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var book = Mapper.Map<BookDTO, Book>(bookdto);
            _context.Books.Add(book);
            _context.SaveChanges();

            bookdto.Id = book.Id;

            return Created(new Uri(Request.RequestUri + "/" + book.Id), bookdto);
        }


        // PUT /api/books/1
        [HttpPut]
        public void UpdateBook(int id, BookDTO bookdto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var bookInDb = _context.Books.SingleOrDefault(b => b.Id == id);

            if (bookInDb == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            Mapper.Map<BookDTO, Book>(bookdto, bookInDb);

            _context.SaveChanges();
        }

        // DELETE /api/books/1
        [HttpDelete]
        public void DeleteBook(int id)
        {
            var bookInDb = _context.Books.SingleOrDefault(b => b.Id == id);

            if (bookInDb == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Books.Remove(bookInDb);
            _context.SaveChanges();
        }
    }
}