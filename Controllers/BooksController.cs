using Library.API.Models;
using Library.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BooksService booksService;

        public BooksController(BooksService booksService)
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
            return Ok(booksService.GetById(id));
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
