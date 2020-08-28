namespace Library.Client.Models
{
    public class BookToReturn : EntityBase
    {
        public string AuthorName { get; set; }
        public string Name { get; set; }
        public string ISBN { get; set; }
    }
}