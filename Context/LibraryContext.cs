using Library.API.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Library.API.Context
{
    public class LibraryContext : DbContext, ILibraryContext
    {
        public LibraryContext([NotNull] DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
    }
}
