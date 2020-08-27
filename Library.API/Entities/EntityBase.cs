using System;

namespace Library.API.Entities
{
    public class EntityBase
    {
        public string Id { get; set; }
        public string CreatedAt { get; set; }
        public string UpdateAt { get; set; }

        public static T Create<T>() where T : EntityBase
        {
            return Activator.CreateInstance<T>();
        }
    }
}
