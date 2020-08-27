using FluentAssertions;
using Library.API.Context;
using Library.API.Entities;
using Library.API.Persistence.Repositories;
using Library.API.Tests.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

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
        public void GetAllBooks_RepositoryHas2Books_ShouldReturn2Books()
        {
            var books = new Book[] { new Book {Id = "1111111", ISBN = "ABC123" }, new Book { Id = "222222", ISBN = "DEF123" } };

            _mockBooks.SetSource(books);

            var result = _repository.GetAllAsQueryable();

            result.Should().HaveCount(2, "It has 2 books in the repository");
        }
    }
}
