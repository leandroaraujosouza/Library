using Library.API.Context;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly LibraryContext libraryContext;

        public BooksController(LibraryContext libraryContext)
        {
            this.libraryContext = libraryContext;
        }

        public IActionResult Get()
        {
            return Ok();
        }
    }
}
