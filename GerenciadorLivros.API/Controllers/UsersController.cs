using GerenciadorLivros.API.Models;
using GerenciadorLivros.Application.Commands.InsertUser;
using GerenciadorLivros.Application.InputModels;
using GerenciadorLivros.Application.Queries.GetUserById;
using GerenciadorLivros.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorLivros.API.Controllers
{
    [Route("api/users")]
    public class UsersController : ControllerBase
    {        
        /*private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }*/

        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetUserByIdQuery(id);

            var user = await _mediator.Send(query);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InsertUserCommand command)
        {
            if (command.Name.Length > 50)
            {
                return BadRequest();
            }

            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
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
