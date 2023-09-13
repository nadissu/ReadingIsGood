using AutoMapper;
using MediatR;
using ReadingIsGood.Application.Features.CustomerFeature.Dtos;
using ReadingIsGood.Application.Services.Repositories;
using ReadingIsGood.Core.Request;

namespace ReadingIsGood.Application.Features.CustomerFeature.Queries
{
    public class GetOrdersByCustomerQuery : IRequest<GetOrdersByCustomerDto>
    {
        public int CustomerId { get; set; }
        public PageRequest PageRequest { get; set; }
        public class GetOrdersByCustomerQueryHandler : IRequestHandler<GetOrdersByCustomerQuery, GetOrdersByCustomerDto>
        {
            IBookRepository _bookRepository;
            IOrderRepository _orderRepository;
            private readonly IMapper _mapper;

            public GetOrdersByCustomerQueryHandler(IMapper mapper, IOrderRepository orderRepository, IBookRepository bookRepository)
            {
                _mapper = mapper;
                _orderRepository = orderRepository;
                _bookRepository = bookRepository;
            }

            public async Task<GetOrdersByCustomerDto> Handle(GetOrdersByCustomerQuery request, CancellationToken cancellationToken)
            {
                var orderList = await _orderRepository.GetListAsync(o=>o.Customer.Id==request.CustomerId, index: request.PageRequest.Page, size: request.PageRequest.PageSize);
                foreach (var order in orderList.Items)
                {
                    order.Book =await _bookRepository.GetAsync(x=>x.Id==order.BookId);
                }
                var mapOrders = _mapper.Map<GetOrdersByCustomerDto>(orderList);
                
               
                return mapOrders;
            }
        }
    }
}
