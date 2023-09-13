using AutoMapper;
using MediatR;
using ReadingIsGood.Application.Features.CustomerFeature.Dtos;
using ReadingIsGood.Application.Services.Repositories;
using ReadingIsGood.Core.Request;

namespace ReadingIsGood.Application.Features.CustomerFeature.Queries
{
    public class GetCustomerQuery:IRequest<GetCustomersDto>
    {
        public PageRequest PageRequest { get; set; }
        public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, GetCustomersDto>
        {
            ICustomerRepository _customerRepository;
            private readonly IMapper _mapper;

            public GetCustomerQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
            {
                _customerRepository = customerRepository;
                _mapper = mapper;
            }

            public async Task<GetCustomersDto> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
            {
                var customerList = await _customerRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);
                var mapCustomer = _mapper.Map<GetCustomersDto>(customerList);
                return mapCustomer;
            }
        }
    }
}
