using AutoMapper;
using ReadingIsGood.Application.Features.BookFeature.Dtos;
using ReadingIsGood.Application.Features.CustomerFeature.Dtos;
using ReadingIsGood.Core.Persistance.Repositories.Paging;
using ReadingIsGood.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingIsGood.Application.Features.CustomerFeature.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //Customer
            CreateMap<IPaginate<Customer>, GetCustomersDto>().ReverseMap();
            CreateMap<Customer, ListCustomerDto>().ReverseMap();

            //GetOrdersByCustomer
            CreateMap<IPaginate<Order>, GetOrdersByCustomerDto>().ReverseMap();
            CreateMap<Order, ListOrderByCustomerDto>().ReverseMap();

        }
    }
}
