using System;

namespace Library.API.Entities
{
    public class EntityBase : IEntityBase
    {
        public string Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdateAt { get; set; }

        public static T Create<T>() where T : EntityBase
        {
            var entity = Activator.CreateInstance<T>();
            entity.Id = Guid.NewGuid().ToString();
            entity.CreatedAt = DateTimeOffset.Now;
            
            return entity;
        }
    }
}
