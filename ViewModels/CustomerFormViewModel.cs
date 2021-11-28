using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Book_Rental.Models;

namespace Book_Rental.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}