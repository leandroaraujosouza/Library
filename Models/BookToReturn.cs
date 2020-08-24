using Library.API.Entities;

namespace Library.API.Models
{
    public class BookToReturn : EntityBase
    {
        public string Name { get; set; }
        public string ISBN { get; set; }
    }
}
