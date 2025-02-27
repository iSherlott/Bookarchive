using Microsoft.AspNetCore.Mvc;

using API.Controllers.Contract;

using Application.Handlers;
using Application.Dictionary;

namespace API.Controllers
{
    [Route("api/[action]")]
    [ApiController]
    public class BooksController : BaseController
    {
        public BooksController(DefaultDictionary defaultDictionary) : base(defaultDictionary) { }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromServices] BooksHandler handler)
        {
            var handle = await handler.Handle();

            return Ok(handle);
        }

        [HttpPost]
        public async Task<IActionResult> PostBook([FromBody] string nameBook, [FromServices] BooksHandler handler)
        {
            var handle = await handler.Handle(nameBook);

            return Ok(handle);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveBook([FromBody] string nameBook, [FromServices] BooksHandler handler)
        {
            var handle = await handler.HandleRemove(nameBook);

            return Ok(handle);
        }
    }
}