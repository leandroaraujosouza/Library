using Library.API.Entities;
using Library.API.EntityConfiguration;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Library.API.Context
{
    public class LibraryContext : DbContext, ILibraryContext
    {
        public LibraryContext([NotNull] DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new BookConfiguration());

            var props = from e in modelBuilder.Model.GetEntityTypes()
                        from p in e.GetProperties()
                        where p.Name == "Name"
                           && p.PropertyInfo.PropertyType == typeof(string)
                        select p;

            foreach (var p in props)
            {
                p.SetColumnType("varchar");
                p.SetMaxLength(200);
            }

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<T> DbSet<T>() where T : class
        {
            return this.Set<T>();
        }

    }
}
