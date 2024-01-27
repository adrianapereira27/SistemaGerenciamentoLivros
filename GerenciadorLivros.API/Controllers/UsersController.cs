using GerenciadorLivros.API.Models;
using GerenciadorLivros.Application.InputModels;
using GerenciadorLivros.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorLivros.API.Controllers
{
    [Route("api/users")]
    public class UsersController : ControllerBase
    {        
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public IActionResult Post([FromBody] NewUserInputModel userModel)
        {
            if (userModel.Name.Length > 50)
            {
                return BadRequest();
            }

            var id = _userService.Create(userModel);

            return CreatedAtAction(nameof(GetById), new { id = id }, userModel);
        }

        // api/users/2
        [HttpPut("{id}/login")]
        public IActionResult Login(int id, [FromBody] LoginModel loginModel)
        {
            // TODO: Para módulo de autenticação e autorização
                        
            return NoContent();
        }
                                
    }
}
