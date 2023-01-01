using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Astro4.Controllers
{
    public class RetroController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
