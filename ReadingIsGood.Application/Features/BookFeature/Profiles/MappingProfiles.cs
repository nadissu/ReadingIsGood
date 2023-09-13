using AutoMapper;
using ReadingIsGood.Application.Features.BookFeature.Command;
using ReadingIsGood.Application.Features.BookFeature.Dtos;
using ReadingIsGood.Application.Features.CustomerFeature.Dtos;
using ReadingIsGood.Core.Persistance.Repositories.Paging;
using ReadingIsGood.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingIsGood.Application.Features.BookFeature.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
           
             
            //Book Create
            CreateMap<Book, CreateBookDto>().ReverseMap();
            CreateMap<Book, CreateBookCommand>().ReverseMap();

            //Book Update
            CreateMap<Book, UpdateBookDto>().ReverseMap();

            //Book List
            CreateMap<IPaginate<Book>, GetBooksDto>().ReverseMap();
            CreateMap<Book, ListBookDto>().ReverseMap();
        }
    }
}
