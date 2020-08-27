using System.Threading.Tasks;
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
        public async Task<IActionResult> Add([FromBody] object bookToAdd)
        {

            return Ok(await booksService.Add(bookToAdd));
        }
    }
}