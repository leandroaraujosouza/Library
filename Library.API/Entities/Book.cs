using Library.Client.Models;
using System;

namespace Library.API.Entities
{
    public class Book : EntityBase
    {
        public string Name { get; set; }
        public string AuthorName { get; set; }
        public string ISBN { get; set; }
        public DateTimeOffset? ReleaseDate { get; set; }

        public static Book CreateFrom(BookToCreate bookToCreate)
        {
            var book = Create<Book>();
            book.ISBN = bookToCreate.ISBN;
            book.Name = bookToCreate.Name;
            book.ReleaseDate = bookToCreate.ReleaseDate;
            book.AuthorName = bookToCreate.AuthorName;

            return book;
        }

        public void UpdateFrom(BookToEdit bookToEdit)
        {
            this.ISBN = bookToEdit.ISBN;
            this.Name = bookToEdit.Name;
            this.AuthorName = bookToEdit.AuthorName;
            this.ReleaseDate = bookToEdit.ReleaseDate;
        }

        public BookToReturn ToBookToReturn()
        {
            return new BookToReturn
            {
                Id = this.Id,
                ISBN = this.ISBN,
                Name = this.Name,
                AuthorName = this.AuthorName,
                ReleaseDate = this.ReleaseDate,
                CreatedAt = this.CreatedAt,
                UpdateAt = this.UpdateAt,
            };
        }
    }
}
