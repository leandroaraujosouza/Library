using Library.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Library.API.Context
{
    public interface ILibraryContext
    {
        DbSet<Book> Books { get; set; }

        public DbSet<T> DbSet<T>() where T : class;

        public EntityEntry<T> Entry<T>(T entity) where T : class;
    }
}