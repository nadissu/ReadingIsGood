﻿using ReadingIsGood.Core.Persistance.Repositories.Base;
using ReadingIsGood.Domain.Entities;

namespace ReadingIsGood.Application.Services.Repositories
{
    public interface IStatisticRepository : IAsyncRepository<Statistics>
    {
    }
}
