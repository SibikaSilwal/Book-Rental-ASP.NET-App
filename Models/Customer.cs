using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Book_Rental.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required] //overriding name column in customer table to be not null
        [StringLength(255)] //and to have max char counts of 255
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; } // membership table foreign key, entity framework recognizes the name 'MembershipTypeId' as a foreign key

        [Display (Name="Date of Birth")]
        public DateTime? BirthDate { get; set; }
    }
}