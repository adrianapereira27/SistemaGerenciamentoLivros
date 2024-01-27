using GerenciadorLivros.Application.InputModels;
using GerenciadorLivros.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorLivros.API.Controllers
{
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // api/books?query=net core
        [HttpGet]
        public IActionResult Get(string query)
        {
            var books = _bookService.GetAll(query);

            return Ok(books);
        }

        // api/books/3
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var book = _bookService.GetById(id);

            if (book == null)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPost]
        public IActionResult Post([FromBody] NewBookInputModel bookModel)
        {
            if (bookModel.Title.Length > 50)
            {
                return BadRequest();
            }
            var id = _bookService.Create(bookModel);

            return CreatedAtAction(nameof(GetById), new { id = id }, bookModel);
        }

        // api/books/2   DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _bookService.Delete(id);

            return NoContent();
        }

    }
}
