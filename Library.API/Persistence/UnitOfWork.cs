using Library.API.Context;
using Library.API.Entities;
using Library.API.Persistence.Repositories;

namespace Library.API.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryContext libraryContext;
        private BaseRepository<Book> books;

        public UnitOfWork(LibraryContext libraryContext)
        {
            this.libraryContext = libraryContext;
        }

        public IRepository<Book> BooksRepository => books ??= new BaseRepository<Book>(libraryContext);

        public void Complete()
        {
            libraryContext.SaveChanges();
        }
    }
}
