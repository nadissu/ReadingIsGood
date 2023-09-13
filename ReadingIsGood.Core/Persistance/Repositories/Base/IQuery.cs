namespace ReadingIsGood.Core.Persistance.Repositories.Base
{
    public interface IQuery<T>
    {
        IQueryable<T> Query();
    }
}
