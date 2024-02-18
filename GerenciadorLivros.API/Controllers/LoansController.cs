using GerenciadorLivros.Application.Commands.CreateLoan;
using GerenciadorLivros.Application.Commands.UpdateLoan;
using GerenciadorLivros.Application.Queries.GetAllLoans;
using GerenciadorLivros.Application.Queries.GetLoanById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorLivros.API.Controllers
{
    [Route("api/loans")]
    [Authorize]    // annotation que indica que os métodos precisam de um usuário autorizado para acessar
    public class LoansController : Controller
    {     
        private readonly IMediator _mediator;

        public LoansController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // api/loans?query=net core
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllLoansQuery();

            var loans = await _mediator.Send(query);

            return Ok(loans);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetLoanByIdQuery(id);

            var loan = _mediator.Send(query);

            if (loan == null)
            {
                return NotFound();
            }

            return Ok(loan);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateLoanCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateLoanCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
