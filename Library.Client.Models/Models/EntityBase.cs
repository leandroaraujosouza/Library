using System;

namespace Library.Client.Models
{
    public class EntityBase 
    {
        public string Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdateAt { get; set; }

    }
}
