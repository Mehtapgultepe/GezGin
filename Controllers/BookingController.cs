using Microsoft.AspNetCore.Mvc;
using GezGin.Models;

namespace GezGin.Controllers
{
    public class BookingController : Controller
    {
        private static List<Booking> _bookings = new List<Booking>();
        private static int _nextId = 1;

        // GET: Booking/Create
        [HttpGet]
        public IActionResult Create(int? tourId)
        {
            ViewBag.Tours = TourController.GetAllTours().Where(t => t.IsAvailable).ToList();
            var booking = new Booking();
            if (tourId.HasValue)
                booking.SelectedTourId = tourId.Value;
            return View(booking);
        }

        // POST: Booking/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Booking booking)
        {
            if (ModelState.IsValid)
            {
                var tour = TourController.GetTourById(booking.SelectedTourId);
                if (tour == null)
                {
                    ModelState.AddModelError("SelectedTourId", "Seçilen tur bulunamadı.");
                    ViewBag.Tours = TourController.GetAllTours().Where(t => t.IsAvailable).ToList();
                    return View(booking);
                }

                booking.Id = _nextId++;
                _bookings.Add(booking);

                return RedirectToAction("Confirmation", new { id = booking.Id });
            }

            ViewBag.Tours = TourController.GetAllTours().Where(t => t.IsAvailable).ToList();
            return View(booking);
        }

        // GET: Booking/Confirmation/5
        public IActionResult Confirmation(int id)
        {
            var booking = _bookings.FirstOrDefault(b => b.Id == id);
            if (booking == null)
                return NotFound();

            var tour = TourController.GetTourById(booking.SelectedTourId);
            ViewBag.Tour = tour;
            ViewBag.TotalPrice = tour != null ? tour.Price * booking.PersonCount : 0;

            return View(booking);
        }
    }
}
