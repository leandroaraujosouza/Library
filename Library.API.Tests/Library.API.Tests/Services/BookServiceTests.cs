using FluentAssertions;
using Library.API.Context;
using Library.API.Models;
using Library.API.Persistence;
using Library.API.Services;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;

namespace Library.API.Tests.Services
{
    [TestClass]
    public class BookServiceTests
    {
        [TestMethod]
        public void AddABook_EditTheBook_ShouldReturnTheBookEdited()
        {
            var book = new BookToCreate() { ISBN = "-", Name = "Clean Code" };

            // In-memory database only exists while the connection is open
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                var options = new DbContextOptionsBuilder<LibraryContext>()
                    .UseSqlite(connection)
                    .Options;

                // Create the schema in the database
                using (var context = new LibraryContext(options))
                {
                    context.Database.EnsureCreated();
                }

                // Run the test against one instance of the context
                using (var context = new LibraryContext(options))
                {
                    var mockUoW = new Mock<UnitOfWork>(context);
                    var service = new Mock<BooksService>(mockUoW.Object);

                    service.Object.Add(book);
                    context.SaveChanges();
                }

                // Use a separate instance of the context to verify correct data was saved to database
                using (var context = new LibraryContext(options))
                {
                    var mockUoW = new Mock<UnitOfWork>(context);
                    var service = new Mock<BooksService>(mockUoW.Object);

                    var bookRecovered = context.Books.FirstOrDefault();
                    var bookToEdit = new BookToEdit { ISBN = "123", Name = "Life is Beautiful" };

                    var result = service.Object.Edit(bookRecovered.Id, bookToEdit);

                    result.ISBN.Should().Be(bookToEdit.ISBN);
                }
            }
            finally
            {
                connection.Close();
            }

        }

        [TestMethod]
        public void AddABook_GetTheBook_ShouldReturnTheBookAdded()
        {
            var book = new BookToCreate() { ISBN = "-", Name = "Clean Code" };

            // In-memory database only exists while the connection is open
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                var options = new DbContextOptionsBuilder<LibraryContext>()
                    .UseSqlite(connection)
                    .Options;

                // Create the schema in the database
                using (var context = new LibraryContext(options))
                {
                    context.Database.EnsureCreated();
                }

                // Run the test against one instance of the context
                using (var context = new LibraryContext(options))
                {
                    var mockUoW = new Mock<UnitOfWork>(context);
                    var service = new Mock<BooksService>(mockUoW.Object);

                    service.Object.Add(book);
                    context.SaveChanges();
                }

                // Use a separate instance of the context to verify correct data was saved to database
                using (var context = new LibraryContext(options))
                {
                    var mockUoW = new Mock<UnitOfWork>(context);
                    var service = new Mock<BooksService>(mockUoW.Object);

                    var bookRecovered = context.Books.FirstOrDefault();

                    var result = service.Object.GetById(bookRecovered.Id);

                    result.Id.Should().Be(bookRecovered.Id);
                }
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
