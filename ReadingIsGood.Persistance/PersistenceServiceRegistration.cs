using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReadingIsGood.Application.Services.Repositories;
using ReadingIsGood.Persistance.Context;
using ReadingIsGood.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingIsGood.Persistance
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
                                                                IConfiguration configuration)
        {

            services.AddDbContext<PostgreContext>(options =>
                                                     options.UseNpgsql(
                                                         configuration.GetConnectionString("PostgreDbContext")));


            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IStatisticRepository, StatisticRepository>();

            return services;
        }
    }
}
