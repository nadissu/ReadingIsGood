using Microsoft.Extensions.DependencyInjection;
using ReadingIsGood.Core.Security;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingIsGood.Core
{
    public static class SecurityServiceRegistration
    {
        public static IServiceCollection AddSecurityServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenHelper,JwtHelper>();

            return services;
        }
    }
}
