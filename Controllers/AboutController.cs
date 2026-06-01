using Microsoft.AspNetCore.Mvc;

namespace GezGin.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
