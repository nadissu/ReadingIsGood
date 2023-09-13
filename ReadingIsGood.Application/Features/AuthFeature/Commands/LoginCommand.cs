using MediatR;
using ReadingIsGood.Application.Features.AuthFeature.Dtos;
using ReadingIsGood.Application.Responsed;
using ReadingIsGood.Application.Services.Repositories;
using ReadingIsGood.Core.Security;
using ReadingIsGood.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingIsGood.Application.Features.AuthFeature.Commands
{
    public class LoginCommand: IRequest<ResponseData<CustomerLoginDto>>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public class LoginCommandHandler : IRequestHandler<LoginCommand, ResponseData<CustomerLoginDto>>
        {
            ICustomerRepository _customerRepository;
            private readonly ITokenHelper _tokenService;
            public LoginCommandHandler(ICustomerRepository customerRepository, ITokenHelper tokenService)
            {
                _customerRepository = customerRepository;
                _tokenService = tokenService;
            }

            public async Task<ResponseData<CustomerLoginDto>> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
               var customer =await  _customerRepository.GetAsync(x=>x.Email==request.Email);
                if (customer == null)
                {
                    return new ResponseData<CustomerLoginDto>(false,"Customer Bulunamadı");
                }

                if (!HashingHelper.VerifyPasswordHash(request.Password, customer.PasswordHash, customer.PasswordSalt))
                    return new ResponseData<CustomerLoginDto>(false, "Password Doğrulanamadı");

                var accesToken = _tokenService.CreateToken(customer);
                return new ResponseData<CustomerLoginDto>(
                    new CustomerLoginDto() { Expiration = accesToken.Expiration,
                        Token= accesToken.Token
                    },true,"Login işlemi başarılı");

            }
        }

       
    }

}
