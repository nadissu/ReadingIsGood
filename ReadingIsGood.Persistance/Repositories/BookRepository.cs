using ReadingIsGood.Application.Services.Repositories;
using ReadingIsGood.Core.Persistance.Repositories.Base;
using ReadingIsGood.Domain.Entities;
using ReadingIsGood.Persistance.Context;

namespace ReadingIsGood.Persistance.Repositories
{
    public class BookRepository : EfRepositoryBase<Book, PostgreContext>, IBookRepository
    {
        public BookRepository(PostgreContext context) : base(context)
        {

        }

    }
}
