using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using Book_Rental.Models;
using Book_Rental.ViewModels;

namespace Book_Rental.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context; // to write data to database

        /* Constructor */
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // _context is a disposable object therefore, we need to dispose it
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            // this gives us all the customers, ToList() is a property defined in the DbSet class, include() method to include the cutomer's information about their memberships in the
            // customer object
            /*var customers = _context.Customers.Include(c => c.MembershipType).ToList(); 
            return View(customers);*/

            // client side rendering using the api therefore, we do not need to send the list of customers to the view anymore
            return View();
        }

        public ActionResult Customer_Detail(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType ).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return Content("Customer does not exist");

            return View(customer);
        }

        /*Form*/
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel()
            {
                Customer = new Customer(), // the new customer will be initialized to its default values, eg. id will be initialzed to 0.
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            // check if form entries are valid
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }
            if(customer.Id==0)
                _context.Customers.Add(customer);
            else
            {
                //UPDATING THE EXISTING CUSTOMER IN THE DB
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return Content("Customer does not exist");

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }

        
    }
}