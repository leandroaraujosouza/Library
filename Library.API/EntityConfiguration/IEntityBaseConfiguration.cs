using Library.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.API.EntityConfiguration
{
    public interface IEntityBaseConfiguration<T> : IEntityTypeConfiguration<T> where T : EntityBase
    {
    }
}