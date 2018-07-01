using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomeTeam.web.Controllers
{
    public class ReactController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return File("index.html", "text/html");
        }
    }
}
