
using System;

namespace Library.Client.Models
{
    public class BookToCreate
    {
        public string AuthorName { get; set; }
        public string Name { get; set; }
        public string ISBN { get; set; }
        public DateTimeOffset? ReleaseDate { get; set; }
    }
}