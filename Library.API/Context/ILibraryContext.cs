using Library.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.API.Context
{
    public interface ILibraryContext
    {
        DbSet<Book> Books { get; set; }
    }
}