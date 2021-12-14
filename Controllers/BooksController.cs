using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Book_Rental.Models;
using Book_Rental.ViewModels;

namespace Book_Rental.Controllers
{
    public class BooksController : Controller
    {
        private ApplicationDbContext _context; // to write data to database

        /* Constructor */
        public BooksController()
        {
            _context = new ApplicationDbContext();
        }

        // _context is a disposable object therefore, we need to dispose it
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Books/Random
        public ActionResult Random()
        {
            var book = new Book() {Name = "Fault In Our Starts." };
            var customers = new List<Customer>
            {
                new Customer{Name = "Customer1"},
                new Customer{Name = "Customer2"}
            };
            var viewModel = new RandomBookViewModel()
            {
                Book = book,
                Customers = customers
            };

            return View(viewModel); //here we are passing the model book to Books View
           
        }

        // Attribute route
        [Route("books/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByPublishedDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        // GET: books, int? means nullable integer
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (User.IsInRole(RoleName.CanManageBooks))
                return View("Index");

            return View("ReadOnlyList");
        }

        public ActionResult Book_Detail(int id)
        {
            var book = _context.Books.Include(b => b.Genre).SingleOrDefault(b => b.Id == id);

            if (book == null)
                return Content("Book does not exist");

            return View(book);
        }

        [Authorize(Roles = RoleName.CanManageBooks)]
        public ActionResult NewBook()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new BookFormViewModel()
            {
                Book = new Book(),
                Genres = genres
            };
            return View("BookForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Book book)
        {
            // check if form entries are valid
            if (!ModelState.IsValid)
            {
                var viewModel = new BookFormViewModel
                {
                    Book = book,
                    Genres = _context.Genres.ToList()
                };
                return View("BookForm", viewModel);
            }
            if (book.Id == 0)
                _context.Books.Add(book);
            else
            {
                //UPDATING THE EXISTING book IN THE DB
                var bookInDb = _context.Books.Single(c => c.Id == book.Id);

                bookInDb.Name = book.Name;
                bookInDb.GenreId = book.GenreId;
                bookInDb.PublishedDate = book.PublishedDate;
                bookInDb.DateAdded = book.DateAdded;
                bookInDb.NumberInStock = book.NumberInStock;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Books");
        }

        public ActionResult Edit(int id)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == id);

            if (book == null)
                return Content("Book does not exist");

            var viewModel = new BookFormViewModel
            {
                Book = book,
                Genres = _context.Genres.ToList()
            };

            return View("BookForm", viewModel);
        }

    }
}

//Action Results
/*There are different action results
 -ViewResult use method View() to return a view
 -PartialViewResult --PartialView()
 -ContentResult --Content()
 -Redirect Result --Redirect() 
 -JsonResult --Json()*/