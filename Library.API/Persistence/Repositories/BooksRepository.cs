using Library.API.Context;
using Library.API.Entities;

namespace Library.API.Persistence.Repositories
{
    public class BooksRepository : BaseRepository<Book>
    {
        public BooksRepository(ILibraryContext context) : base(context)
        {
            
        }
    }
}
