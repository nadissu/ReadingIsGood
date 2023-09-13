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
    public class RegisterCommand : IRequest<ResponseData<RegisterDto>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }

        public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ResponseData<RegisterDto>>
        {
            ICustomerRepository _customerRepository;
            private readonly ITokenHelper _tokenService;

            public RegisterCommandHandler(ICustomerRepository customerRepository, ITokenHelper tokenService)
            {
                _customerRepository = customerRepository;
                _tokenService = tokenService;
            }

            public async Task<ResponseData<RegisterDto>> Handle(RegisterCommand request, CancellationToken cancellationToken)
            {
                var customer = await _customerRepository.GetAsync(x => x.Email == request.Email);
                if (customer != null)
                {
                    return new ResponseData<RegisterDto>(false, "Böyle Bir kullanıcı Zaten var");
                }
                byte[] passwordHash,
                passwordSalt;
                HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);
                Customer newCustomer =
                   new()
                   {
                       Email = request.Email,
                       Name = request.Name,
                       PasswordHash = passwordHash,
                       PasswordSalt = passwordSalt,
                       IsActive = true
                   };
                
                var user = await _customerRepository.AddAsync(newCustomer);

                var accesToken = _tokenService.CreateToken(user);
                return new ResponseData<RegisterDto>(
                    new RegisterDto()
                    {
                        Token = accesToken.Token
                    }, true, "Kayıt işlemi başarılı");
            }
        }
    }
}
