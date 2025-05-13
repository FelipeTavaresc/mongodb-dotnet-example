using Microsoft.AspNetCore.Mvc;
using MongoExample.Models;
using MongoExample.Services;

namespace MongoExample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly BookService _bookService;

        public BookController(BookService bookService)
        {
            _bookService = bookService;
        }
            
        [HttpGet]
        public IActionResult Get()
        {
            var books = _bookService.Get();

            return Ok(books);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Book book) 
        { 
            _bookService.Create(book);
            return CreatedAtRoute(nameof(Get), new { id = book.Id}, book);
        }

        [HttpPut]
        public IActionResult Update(string id, [FromBody] Book bookIn) 
        {
            var book = _bookService.Get(id);
            if (book is null)
                return NotFound();

            _bookService.Update(id, bookIn);
            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(string id)
        {
            var book = _bookService.Get(id);
            if(book is null)
                return NotFound();

            _bookService.Remove(id);
            return NoContent();
        }
    }
}
