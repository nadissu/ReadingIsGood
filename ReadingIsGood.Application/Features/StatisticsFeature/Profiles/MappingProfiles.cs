using AutoMapper;
using ReadingIsGood.Application.Features.OrderFeature.Dtos;
using ReadingIsGood.Application.Features.StatisticsFeature.Dtos;
using ReadingIsGood.Core.Persistance.Repositories.Paging;
using ReadingIsGood.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingIsGood.Application.Features.StatisticsFeature.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<IPaginate<Statistics>, GetStatisticsDto>().ReverseMap();
            CreateMap<Statistics, StatisticsDto>().ReverseMap();

        }
    }
}
