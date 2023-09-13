
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using ReadingIsGood.Core.Persistance.Repositories.Paging;
using System.Linq.Expressions;

namespace ReadingIsGood.Core.Persistance.Repositories.Base
{
    public class EfRepositoryBase<TEntity, TContext> : IAsyncRepository<TEntity>
    where TEntity : EntityBase
    where TContext : DbContext
    {
        protected TContext Context { get; }

        public EfRepositoryBase(TContext context)
        {
            Context = context;
        }

        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public async Task<IPaginate<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null,
                                                           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy =
                                                               null,
                                                           Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>?
                                                               include = null,
                                                           int index = 0, int size = 10000, bool enableTracking = true,
                                                           CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> queryable = Query();
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include != null) queryable = include(queryable);
            if (predicate != null) queryable = queryable.Where(predicate);
            if (orderBy != null)
                return await orderBy(queryable).ToPaginateAsync(index, size, 0, cancellationToken);
            return await queryable.ToPaginateAsync(index, size, 0, cancellationToken);
        }

      

        public IQueryable<TEntity> Query()
        {
            return Context.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Added;
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<IList<TEntity>> AddRangeAsync(IList<TEntity> entities)
        {
            await Context.AddRangeAsync(entities);
            await Context.SaveChangesAsync();
            return entities;
        }
        public async Task<IList<TEntity>> DeleteRangeAsync(IList<TEntity> entities)
        {
            Context.RemoveRange(entities);
            Context.SaveChanges();
            return entities;
        }
        public async Task<IList<TEntity>> UpdateRangeAsync(IList<TEntity> entities)
        {
            Context.UpdateRange(entities);
            await Context.SaveChangesAsync();
            return entities;
        }
    }
}
