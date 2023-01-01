using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace Astro4.Controllers
{
    public class RuhesiController : Controller
    {
        private readonly IStringLocalizer<HomeController> _localizer;
        public RuhesiController(IStringLocalizer<HomeController> localizer)
        {
            _localizer = localizer;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
