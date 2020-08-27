using Library.API.Entities;
using Library.API.Persistence.Repositories;

namespace Library.API.Persistence
{
    public interface IUnitOfWork
    {
        IRepository<Book> BooksRepository { get; }

        void Complete();
    }
}