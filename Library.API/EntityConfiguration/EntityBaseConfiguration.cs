using Library.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.API.EntityConfiguration
{
    public class EntityBaseConfiguration<T> : IEntityTypeConfiguration<T> where T : EntityBase
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(x => x.Id).HasColumnType("varchar(60)");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.UpdateAt)
                .IsRequired(false);
        }
    }
}
