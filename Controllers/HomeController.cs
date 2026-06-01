using Microsoft.AspNetCore.Mvc;
using GezGin.Models;

namespace GezGin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var featuredTours = TourController.GetAllTours()
                .Where(t => t.IsAvailable)
                .OrderByDescending(t => t.Rating)
                .Take(3)
                .ToList();

            return View(featuredTours);
        }
    }
}
