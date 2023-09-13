using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingIsGood.Application.Features.AuthFeature.Dtos
{
    public class CustomerLoginDto
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }

    }
}
