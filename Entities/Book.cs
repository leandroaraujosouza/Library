using Library.API.Models;

namespace Library.API.Entities
{
    public class Book : EntityBase
    {
        public string Name { get; private set; }
        public string ISBN { get; private set; }

        public static Book CreateFrom(BookToCreate bookToCreate)
        {
            return new Book
            {
                ISBN = bookToCreate.ISBN,
                Name = bookToCreate.Name
            };
        }

        public void UpdateFrom(BookToEdit bookToEdit)
        {
            this.ISBN = bookToEdit.ISBN;
            this.Name = bookToEdit.Name;
        }

        public BookToReturn ToBookToReturn()
        {
            return new BookToReturn
            {
                Id = this.Id,
                ISBN = this.ISBN,
                Name = this.Name,
                CreatedAt = this.CreatedAt,
                UpdateAt = this.UpdateAt,
            };
        }
    }
}
