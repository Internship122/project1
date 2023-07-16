using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class ErrorController : ControllerBase
    {
        public IActionResult Index()
        {
            return Problem();
        }
    }
}
