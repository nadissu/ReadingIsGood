using AutoMapper;
using MediatR;
using ReadingIsGood.Application.Features.OrderFeature.Dtos;
using ReadingIsGood.Application.Services.Repositories;
using ReadingIsGood.Core.Request;

namespace ReadingIsGood.Application.Features.OrderFeature.Queries
{
    public class GetOrdersQuery : IRequest<GetOrdersDto>
    {
        public PageRequest PageRequest { get; set; }
        public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, GetOrdersDto>
        {
            IBookRepository _bookRepository;
            IOrderRepository _orderRepository;
            ICustomerRepository _customerRepository;
            private readonly IMapper _mapper;

            public GetOrdersQueryHandler(IMapper mapper, IOrderRepository orderRepository, IBookRepository bookRepository, ICustomerRepository customerRepository)
            {
                _mapper = mapper;
                _orderRepository = orderRepository;
                _bookRepository = bookRepository;
                _customerRepository = customerRepository;
            }

            public async Task<GetOrdersDto> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
            {
                var orders = await _orderRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);
                foreach (var order in orders.Items)
                {
                    order.Book = await _bookRepository.GetAsync(x => x.Id == order.BookId);
                    order.Customer = await _customerRepository.GetAsync(x => x.Id == order.CustomerId);
                }
                

                var mapOrders = _mapper.Map<GetOrdersDto>(orders);


                return mapOrders;
            }
        }
    }
}
