using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Book_Rental.DTOs
{
    public class RentalDTO
    {
        public int CustomerId { get; set; }
        public List<int> BookIds { get; set; }
    }
}