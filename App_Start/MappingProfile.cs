using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Book_Rental.Models;
using Book_Rental.DTOs;

namespace Book_Rental.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDTOcs>();
            Mapper.CreateMap<CustomerDTOcs, Customer>();

            Mapper.CreateMap<Book, BookDTO>();//.ForMember(b => b.Id, opt => opt.Ignore());
            Mapper.CreateMap<BookDTO, Book>();

            Mapper.CreateMap<MembershipType, MembershipTypeDTO>();
            Mapper.CreateMap<Genre, GenreDTO>();
        }
    }
}