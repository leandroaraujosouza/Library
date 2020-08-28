using Library.Client.Models;
using System;

namespace Library.API.Entities
{
    public class Book : EntityBase
    {
        public string Name { get; set; }
        public string ISBN { get; set; }

        public static Book CreateFrom(BookToCreate bookToCreate)
        {
            var book = Create<Book>();
            book.ISBN = bookToCreate.ISBN;
            book.Name = bookToCreate.Name;            

            return book;
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
