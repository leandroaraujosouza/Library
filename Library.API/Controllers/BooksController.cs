using Library.API.Entities;
using Library.API.Services;
using Library.Client.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService booksService;

        public BooksController(IBooksService booksService)
        {
            this.booksService = booksService;
        }

        [HttpPost]
        public Book Add(BookToCreate bookToCreate)
        {
            return booksService.Add(bookToCreate);
        }

        [HttpPut]
        [Route("{id}")]
        public BookToReturn Edit([FromRoute] string id, BookToEdit bookToEdit)
        {
            return booksService.Edit(id, bookToEdit);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get([FromRoute] string id)
        {
            var book = booksService.GetById(id);

            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(booksService.GetAll());
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] string id)
        {
            return Ok(booksService.Delete(id));
        }
    }
}