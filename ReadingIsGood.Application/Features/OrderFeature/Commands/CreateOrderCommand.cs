using AutoMapper;
using MediatR;
using ReadingIsGood.Application.Features.BookFeature.Dtos;
using ReadingIsGood.Application.Features.OrderFeature.Dtos;
using ReadingIsGood.Application.Services.Repositories;
using ReadingIsGood.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingIsGood.Application.Features.OrderFeature.Commands
{
    public class CreateOrderCommand : IRequest<CreateOrderDto>
    {
        public List<CreateOrderBookDto> createOrderBookDto { get; set; }
        public int CustomerId { get; set; }
        public decimal TotalPrice { get; set; }
        public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreateOrderDto>
        {
            private readonly IOrderRepository _orderRepository;
            private readonly ICustomerRepository _customerRepository;
            IBookRepository _bookRepository;
            private readonly IMapper _mapper;

            public CreateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper, IBookRepository bookRepository, ICustomerRepository customerRepository)
            {
                _orderRepository = orderRepository;
                _mapper = mapper;
                _bookRepository = bookRepository;
                _customerRepository = customerRepository;
            }

            public async Task<CreateOrderDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
            {
                CreateOrderDto createdOrderDto = new() { 
                Customer = new(),
                Books=new()
                };
                var customer = await _customerRepository.GetAsync(x => x.Id == request.CustomerId);
                decimal TotalPrice = 0;
                foreach (var bookRequestDto in request.createOrderBookDto)
                {
                    var book = await _bookRepository.GetAsync(x => x.Id == bookRequestDto.id);
                    if (book == null)
                    {
                        throw new ArgumentException("Kitap Bulunamadı");
                    }
                    createdOrderDto.Books.Add(book);

                    createdOrderDto.Customer=customer;
                    TotalPrice = (book.Price * bookRequestDto.Stock) + TotalPrice;
                    var order = await _orderRepository.AddAsync(new()
                    {
                        TotalPrice = book.Price * bookRequestDto.Stock,
                        Book = book,
                        Count = bookRequestDto.Stock,
                        Customer = createdOrderDto.Customer,
                        CreateAt = DateTime.UtcNow,
                        OrderStatus = OrderStatus.Wait,
                        IsActive=false
                    });

                }
                createdOrderDto.TotalPrice = TotalPrice;
                
                

                return createdOrderDto;
            }

        }

    }
}
