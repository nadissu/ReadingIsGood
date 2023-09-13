using AutoMapper;
using MediatR;
using ReadingIsGood.Application.Features.OrderFeature.Dtos;
using ReadingIsGood.Application.Features.OrderFeature.Queries;
using ReadingIsGood.Application.Features.StatisticsFeature.Dtos;
using ReadingIsGood.Application.Services.Repositories;
using ReadingIsGood.Core.Request;
using ReadingIsGood.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingIsGood.Application.Features.StatisticsFeature.Queries
{
    public class StatisticsQuery:IRequest<GetStatisticsDto>
    {
        public PageRequest pageRequest { get; set; }
        public class StatisticsQueryHandler : IRequestHandler<StatisticsQuery, GetStatisticsDto>
        {
            IStatisticRepository _statisticRepository;
            private readonly IMapper _mapper;

            public StatisticsQueryHandler(IMapper mapper,  IStatisticRepository statisticRepository)
            {
                _mapper = mapper;
                _statisticRepository = statisticRepository;
            }

            public async Task<GetStatisticsDto> Handle(StatisticsQuery request, CancellationToken cancellationToken)
            {
                var statistics = await _statisticRepository.GetListAsync();
                var mapstatistics = _mapper.Map<GetStatisticsDto>(statistics);
                return mapstatistics;
            }
        }
    }
}

