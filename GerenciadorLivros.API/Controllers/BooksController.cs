using GerenciadorLivros.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorLivros.API.Controllers
{
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(string query)
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        {
            // return NotFound();

            return Ok();
        }

        [HttpPost]
        public IActionResult Post([FromBody] BookViewModel bookModel)
        {
            if (bookModel.Title.Length > 50)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetById), new {id = bookModel.Id}, bookModel);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] BookInputModel bookInputModel)
        {
            if(bookInputModel.Title.Length > 50){
                return BadRequest();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            return NoContent();
        }
                
    }
}
