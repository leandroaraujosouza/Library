using Library.API.Models;
using Library.API.Services;
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
        public IActionResult Add(BookToCreate bookToCreate)
        {
            return Ok(booksService.Add(bookToCreate));
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Edit(string id, BookToEdit bookToEdit)
        {
            return Ok(booksService.Edit(id, bookToEdit));
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(string id)
        {
            var book = booksService.GetById(id);

            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(booksService.Get());
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(string id)
        {
            return Ok(booksService.Delete(id));
        }
    }
}
