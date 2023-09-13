using AutoMapper;
using MediatR;
using ReadingIsGood.Application.Features.StatisticsFeature.Dtos;
using ReadingIsGood.Application.Services.Repositories;
using ReadingIsGood.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingIsGood.Application.Features.StatisticsFeature.Commands
{
    public class StatisticsCommand : IRequest<StatisticsDto>
    {
        public class StatisticsCommandHandler : IRequestHandler<StatisticsCommand, StatisticsDto>
        {
            IStatisticRepository _statisticRepository;
            IOrderRepository _orderRepository;
            private readonly IMapper _mapper;

            public StatisticsCommandHandler(IMapper mapper, IOrderRepository orderRepository, IBookRepository bookRepository, ICustomerRepository customerRepository, IStatisticRepository statisticRepository)
            {
                _mapper = mapper;
                _orderRepository = orderRepository;
                _statisticRepository = statisticRepository;
            }

            public async Task<StatisticsDto> Handle(StatisticsCommand request, CancellationToken cancellationToken)
            {
                var orders = await _orderRepository.GetListAsync();
                StatisticsDto statisticsListDto = new StatisticsDto();
                foreach (var order in orders.Items)
                {
                    statisticsListDto.TotalBookCount = statisticsListDto.TotalBookCount + order.Count;
                    statisticsListDto.TotalOrderCount = orders.Items.Count;
                    statisticsListDto.TotalPurchasedAmount = statisticsListDto.TotalPurchasedAmount + order.TotalPrice;
                }
                var statistic = _mapper.Map<Statistics>(statisticsListDto);
                statistic.Month = DateTime.UtcNow.Month.ToString();
                statistic.CreateAt= DateTime.UtcNow;
                await _statisticRepository.AddAsync(statistic);
                return statisticsListDto;
            }
        }
    }
}
