using GerenciadorLivros.Application.Commands.DeleteBook;
using GerenciadorLivros.Application.Commands.InsertBook;
using GerenciadorLivros.Application.InputModels;
using GerenciadorLivros.Application.Queries.GetAllBooks;
using GerenciadorLivros.Application.Queries.GetBookById;
using GerenciadorLivros.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorLivros.API.Controllers
{
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        /*private readonly IBookService _bookService;
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }*/

        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // api/books?query=net core
        [HttpGet]
        public async Task<IActionResult> Get(string query)
        {            
            var getAllBooksQuery = new GetAllBooksQuery(query);

            var book = await _mediator.Send(getAllBooksQuery);

            return Ok(book);
        }

        // api/books/3
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetBookByIdQuery(id);
            
            var book = await _mediator.Send(query);

            if (book == null)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InsertBookCommand command)
        {
            if (command.Title.Length > 50)
            {
                return BadRequest();
            }            
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        // api/books/2   DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteBookCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

    }
}
