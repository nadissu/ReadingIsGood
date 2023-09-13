
using Microsoft.EntityFrameworkCore.Query;
using ReadingIsGood.Core.Persistance.Repositories.Paging;
using System.Linq.Expressions;


namespace ReadingIsGood.Core.Persistance.Repositories.Base
{
    public interface IAsyncRepository<T> : IQuery<T> where T : EntityBase
    {
        Task<T?> GetAsync(Expression<Func<T, bool>> predicate);

        Task<IPaginate<T>> GetListAsync(Expression<Func<T, bool>>? predicate = null,
                                        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                                        int index = 0, int size = 10000, bool enableTracking = true,
                                        CancellationToken cancellationToken = default);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
        Task<IList<T>> AddRangeAsync(IList<T> entity);
        Task<IList<T>> UpdateRangeAsync(IList<T> entity);
        Task<IList<T>> DeleteRangeAsync(IList<T> entity);
    }
}
