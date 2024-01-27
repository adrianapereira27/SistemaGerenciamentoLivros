using GerenciadorLivros.Application.InputModels;
using GerenciadorLivros.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorLivros.API.Controllers
{
    [Route("api/loans")]
    public class LoansController : Controller
    {
        private readonly ILoanService _loanService;
        public LoansController(ILoanService loanService)
        {
            _loanService = loanService;
        }

        // api/loans?query=net core
        [HttpGet]
        public IActionResult Get(string query)
        {
            var loan = _loanService.GetAll(query);

            return Ok(loan);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var loan = _loanService.GetById(id);
            if (loan == null)
            {
                return NotFound();
            }

            return Ok(loan);
        }

        [HttpPost]
        public IActionResult Post([FromBody] NewLoanInputModel loanModel)
        {
            _loanService.Create(loanModel);

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateLoanInputModel loanModel)
        {
            _loanService.Update(loanModel);

            return NoContent();
        }
    }
}
