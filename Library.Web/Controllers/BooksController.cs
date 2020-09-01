using System.Threading.Tasks;
using Library.Client.Models;
using Library.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library.Web.Controllers
{
    public class BooksController : ControllerBase
    {
        private readonly BooksService booksService;

        public BooksController(BooksService booksService)
        {
            this.booksService = booksService;

        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] BookToCreate bookToAdd)
        {
            return Ok(await booksService.Add(bookToAdd));
        }

        [HttpPut]
        public async Task<IActionResult> Edit(string id, [FromBody] BookToEdit bookToEdit)
        {
            return Ok(await booksService.Edit(id, bookToEdit));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await booksService.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await booksService.Get(id));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            return Ok(await booksService.Delete(id));
        }
    }
}