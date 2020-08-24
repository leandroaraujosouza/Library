using Library.API.Context;
using Library.API.Entities;
using Library.API.Models;
using System.Collections.Generic;
using System.Linq;

namespace Library.API.Services
{
    public class BooksService
    {
        private readonly LibraryContext libraryContext;

        public BooksService(LibraryContext libraryContext)
        {
            this.libraryContext = libraryContext;
        }

        public Book Add(BookToCreate bookToCreate)
        {
            var book = Book.CreateFrom(bookToCreate);

            libraryContext.Books.Add(book);

            libraryContext.SaveChanges();

            return book;
        }
        public BookToReturn Edit(string id, BookToEdit bookToEdit)
        {
            var book = libraryContext.Books.FirstOrDefault(x => x.Id == id);

            if (book == null)
                return null;

            book.UpdateFrom(bookToEdit);

            libraryContext.SaveChanges();

            return book.ToBookToReturn();
        }
        public Book GetById(string id)
        {
            return libraryContext.Books.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<BookToReturn> Get()
        {
            var booksToReturn = libraryContext
                .Books
                .ToList();

            return booksToReturn
                .Select(x =>
                {
                    return x.ToBookToReturn();
                });
        }

        public Book Delete(string id)
        {
            var bookToDelete = libraryContext.Books.FirstOrDefault(x => x.Id == id);

            libraryContext.Remove(bookToDelete);

            libraryContext.SaveChanges();

            return null;
        }
    }
}
