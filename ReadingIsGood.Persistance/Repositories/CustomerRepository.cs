using ReadingIsGood.Application.Services.Repositories;
using ReadingIsGood.Core.Persistance.Repositories.Base;
using ReadingIsGood.Domain.Entities;
using ReadingIsGood.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingIsGood.Persistance.Repositories
{
    public class CustomerRepository : EfRepositoryBase<Customer, PostgreContext>, ICustomerRepository
    {
        public CustomerRepository(PostgreContext context) : base(context)
        {

        }

    }
}
