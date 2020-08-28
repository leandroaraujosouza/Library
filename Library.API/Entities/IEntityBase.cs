using System;

namespace Library.API.Entities
{
    public interface IEntityBase
    {
        string Id { get; set; }
        DateTimeOffset CreatedAt { get; set; }
        DateTimeOffset? UpdateAt { get; set; }
    }
}