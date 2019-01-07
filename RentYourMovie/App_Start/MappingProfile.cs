using AutoMapper;
using RentYourMovie.DTOs;
using RentYourMovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentYourMovie.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Customer Mapping
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(c=>c.Id, opt=>opt.Ignore());

            //Movie Mapping
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MovieDto, Movie>()
                .ForMember(c=>c.Id, opt=>opt.Ignore());

           //MembershipType Mapping
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<MembershipTypeDto, MembershipType>();
        }
    }
}