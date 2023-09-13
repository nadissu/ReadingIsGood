using ReadingIsGood.Application.Services.Repositories;
using ReadingIsGood.Core.Persistance.Repositories.Base;
using ReadingIsGood.Domain.Entities;
using ReadingIsGood.Persistance.Context;

namespace ReadingIsGood.Persistance.Repositories
{
    public class OrderRepository : EfRepositoryBase<Order, PostgreContext>, IOrderRepository
    {
        public OrderRepository(PostgreContext context) : base(context)
        {

        }

    }
}
