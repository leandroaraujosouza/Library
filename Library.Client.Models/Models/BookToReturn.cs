namespace Library.Client.Models
{
    public class BookToReturn : EntityBase
    {
        public string Author { get; set; }
        public string Name { get; set; }
        public string ISBN { get; set; }
    }
}