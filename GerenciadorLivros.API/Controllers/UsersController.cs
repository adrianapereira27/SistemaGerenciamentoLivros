using GerenciadorLivros.Application.Commands.InsertUser;
using GerenciadorLivros.Application.Commands.LoginUser;
using GerenciadorLivros.Application.Queries.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorLivros.API.Controllers
{
    [Route("api/users")]
    [Authorize]    // annotation que indica que os métodos precisam de um usuário autorizado para acessar
    public class UsersController : ControllerBase
    {
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
        [AllowAnonymous]      // permite acesso anônimo (sobrescreve a annotation Authorize)
        public async Task<IActionResult> Post([FromBody] InsertUserCommand command)
        {
            if (command.Name.Length > 50)
            {
                return BadRequest();
            }

            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        // api/users/login
        [HttpPut("login")]
        [AllowAnonymous]      // permite acesso anônimo (sobrescreve a annotation Authorize)
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            var loginUserViewModel = await _mediator.Send(command);

            if (loginUserViewModel == null)
            {
                return BadRequest();
            }

            return Ok(loginUserViewModel);
        }

    }
}
