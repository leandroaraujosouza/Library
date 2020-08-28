using FluentAssertions;
using Library.API.Controllers;
using Library.API.Services;
using Library.Client.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Library.API.Tests.Controllers
{
    [TestClass]
    public class BooksControllerTests
    {
        private readonly Mock<IBooksService> _mockBookService;
        private readonly BooksController _controller;

        public BooksControllerTests()
        {
            _mockBookService = new Mock<IBooksService>();
            _controller = new BooksController(_mockBookService.Object);
        }

        [TestMethod]
        public void Create_NewBook_ShouldReturnOkObjectResult()
        {
            var book = new Mock<BookToCreate>();

            var result = _controller.Add(book.Object);

            result.Should().NotBeNull();
        }

        [TestMethod]
        public void Edit_ExistingBook_ShouldReturnOkObjectResult()
        {
            var book = new BookToEdit() { ISBN = "ABC123", Name = "Clean Code" };

            var result = _controller.Edit("1", book);

            result.ISBN.Should().Be(book.ISBN);
        }

        [TestMethod]
        public void DeleteABook_ShouldReturnOkObjectResult()
        {
            var bookId = "1";

            var result = _controller.Delete(bookId);

            result.Should().BeOfType<OkObjectResult>();
        }

        [TestMethod]
        public void GetAllBooks_ShouldReturnOkObjectResult()
        {
            var result = _controller.Get();

            result.Should().BeOfType<OkObjectResult>();
        }
    }
}
