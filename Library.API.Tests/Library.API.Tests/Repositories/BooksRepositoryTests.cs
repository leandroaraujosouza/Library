using FluentAssertions;
using Library.API.Context;
using Library.API.Entities;
using Library.API.Persistence;
using Library.API.Persistence.Repositories;
using Library.API.Services;
using Library.API.Tests.Extensions;
using Library.Client.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;

namespace Library.API.Tests.Repositories
{
    [TestClass]
    public class BooksRepositoryTests
    {
        private Mock<DbSet<Book>> _mockBooks;
        private BooksRepository _repository;

        public BooksRepositoryTests()
        {

        }

        [TestInitialize]
        public void TestInitialize()
        {
            _mockBooks = new Mock<DbSet<Book>>();
            var mockContext = new Mock<ILibraryContext>();
            mockContext.SetupGet(c => c.Books).Returns(_mockBooks.Object);
            _repository = new BooksRepository(mockContext.Object);
        }

        [TestMethod]
        public void GetAllBooks_Add2BooksToTheRepository_ShouldReturn2Books()
        {
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
                    var books = new BookToCreate[] { new BookToCreate { Name = "Livro 1", ISBN = "ABC123" }, new BookToCreate { Name = "Livro 2", ISBN = "DEF123" } };

                    service.Object.AddRange(books);
                    context.SaveChanges();
                }

                // Use a separate instance of the context to verify correct data was saved to database
                using (var context = new LibraryContext(options))
                {
                    context.Books.Should().HaveCount(2, "2 books was added to the repository");
                }
            }
            finally
            {
                connection.Close();
            }
        }

        [TestMethod]
        public void GetBookById_AddABookToRepository_ShouldReturnTheBookAdded()
        {
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
                    service.Object.Add(new BookToCreate() { Name = "Livro do ID", ISBN = "ABC123456" });
                    context.SaveChanges();
                }

                // Use a separate instance of the context to verify correct data was saved to database
                using (var context = new LibraryContext(options))
                {
                    
                    //Assert
                    context.Books.Count().Should().Be(1);
                }
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
