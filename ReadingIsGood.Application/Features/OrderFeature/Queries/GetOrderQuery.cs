using AutoMapper;
using MediatR;
using ReadingIsGood.Application.Features.CustomerFeature.Dtos;
using ReadingIsGood.Application.Features.OrderFeature.Dtos;
using ReadingIsGood.Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingIsGood.Application.Features.OrderFeature.Queries
{
    public class GetOrderQuery : IRequest<OrderDto>
    {
        public int OrderId { get; set; }
        public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, OrderDto>
        {
            IBookRepository _bookRepository;
            IOrderRepository _orderRepository;
            ICustomerRepository _customerRepository;
            private readonly IMapper _mapper;

            public GetOrderQueryHandler(IMapper mapper, IOrderRepository orderRepository, IBookRepository bookRepository, ICustomerRepository customerRepository)
            {
                _mapper = mapper;
                _orderRepository = orderRepository;
                _bookRepository = bookRepository;
                _customerRepository = customerRepository;
            }

            public async Task<OrderDto> Handle(GetOrderQuery request, CancellationToken cancellationToken)
            {
                var order = await _orderRepository.GetAsync(x=>x.Id==request.OrderId);
                order.Book = await _bookRepository.GetAsync(x => x.Id == order.BookId);
                order.Customer = await _customerRepository.GetAsync(x => x.Id == order.CustomerId);
               
                var mapOrders = _mapper.Map<OrderDto>(order);


                return mapOrders;
            }
        }
    }
}
