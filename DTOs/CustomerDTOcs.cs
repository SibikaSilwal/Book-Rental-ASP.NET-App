using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Book_Rental.DTOs;

namespace Book_Rental.DTOs
{
    public class CustomerDTOcs
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your name.")] //overriding name column in customer table to be not null
        [StringLength(255)] //and to have max char counts of 255
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public byte MembershipTypeId { get; set; } // membership table foreign key, entity framework recognizes the name 'MembershipTypeId' as a foreign key

        public MembershipTypeDTO MembershipType { get; set; }

        //[Min18YearsIfMember]
        public DateTime? BirthDate { get; set; }
    }
}