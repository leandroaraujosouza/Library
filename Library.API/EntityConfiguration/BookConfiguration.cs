using Library.API.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.API.EntityConfiguration
{
    public class BookConfiguration : EntityBaseConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
        }
    }
}
