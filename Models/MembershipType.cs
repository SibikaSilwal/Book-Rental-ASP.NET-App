using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Book_Rental.Models
{
    public class MembershipType
    {
        public byte Id { get; set; } // byte for id because there are only a few membership types

        [StringLength(255)]
        public string Name { get; set; }
        public short SignUpFree { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }
    }
}