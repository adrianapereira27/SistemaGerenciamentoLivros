using GerenciadorLivros.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorLivros.API.Controllers
{
    [Route("api/users")]
    public class UsersController : ControllerBase
    {        
        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // return NotFound();

            return Ok();
        }

        [HttpPost]
        public IActionResult Post([FromBody] UserViewModel userModel)
        {
            if (userModel.Name.Length > 50)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetById), new { id = 1 }, userModel);
        }

        // api/users/2
        [HttpPut("{id}/login")]
        public IActionResult Login(int id, [FromBody] LoginModel loginModel)
        {
            
            // atualizo o objeto
            return NoContent();
        }

        // api/users/3 
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // buscar, se não existirm retorna NotFound

            return NoContent();
        }
                
    }
}
