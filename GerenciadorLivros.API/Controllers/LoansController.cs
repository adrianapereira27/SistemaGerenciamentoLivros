using GerenciadorLivros.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorLivros.API.Controllers
{
    [Route("api/loans")]
    public class LoansController : Controller
    {
        [HttpGet]
        public IActionResult Get(string query)
        {
            return Ok();
        }

        [HttpPost("{id}")]
        public IActionResult Post(int id, [FromBody] LoanInputModel loanModel)
        {

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] LoanInputModel loanModel)
        {
            
            return NoContent();
        }
    }
}
