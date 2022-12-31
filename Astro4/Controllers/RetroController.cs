using Microsoft.AspNetCore.Mvc;

namespace Astro4.Controllers
{
    public class RetroController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
