using Microsoft.AspNetCore.Mvc;

namespace GerenciadorLivros.API.Controllers
{
    public class BooksController : ControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
