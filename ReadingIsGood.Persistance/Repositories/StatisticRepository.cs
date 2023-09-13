using ReadingIsGood.Application.Services.Repositories;
using ReadingIsGood.Core.Persistance.Repositories.Base;
using ReadingIsGood.Domain.Entities;
using ReadingIsGood.Persistance.Context;

namespace ReadingIsGood.Persistance.Repositories
{
    public class StatisticRepository : EfRepositoryBase<Statistics, PostgreContext>, IStatisticRepository
    {
        public StatisticRepository(PostgreContext context) : base(context)
        {

        }

    }
}
