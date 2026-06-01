using Microsoft.AspNetCore.Mvc;
using GezGin.Models;

namespace GezGin.Controllers
{
    public class TourController : Controller
    {
        private static List<Tour> _tours = new List<Tour>
        {
            new Tour
            {
                Id = 1,
                TourName = "Santorini Rüyası",
                Country = "Yunanistan",
                City = "Santorini",
                ShortDescription = "Beyaz evler, mavi kubbeler ve eşsiz Ege manzarası.",
                Description = "Santorini, dünyanın en romantik adalarından biridir. Caldera manzarasına karşı yapılan yürüyüşler, antik Akrotiri kalıntıları ve ünlü Oia gün batımı sizi büyüleyecek. Turumuz 7 gece konaklama, yarım pansiyon ve rehberli gezileri kapsamaktadır.",
                Price = 1200,
                DurationDays = 8,
                IsAvailable = true,
                ImageUrl = "https://images.unsplash.com/photo-1570077188670-e3a8d69ac5ff?w=800",
                Category = "Romantik",
                MaxPersons = 15,
                Rating = 4.9
            },
            new Tour
            {
                Id = 2,
                TourName = "Roma'nın İzinde",
                Country = "İtalya",
                City = "Roma",
                ShortDescription = "Tarihin kalbinde yürüyün, Colosseum'u hissedin.",
                Description = "Ebedi şehir Roma'da tarihin derinliklerine dalın. Colosseum, Forum Romanum, Vatikan Müzesi ve Sistine Şapeli'ni kapsayan kapsamlı bir kültür turu. Otantik İtalyan mutfağını tadacak, tarihi sokaklarda gezeceksiniz.",
                Price = 950,
                DurationDays = 6,
                IsAvailable = true,
                ImageUrl = "https://images.unsplash.com/photo-1552832230-c0197dd311b5?w=800",
                Category = "Kültür",
                MaxPersons = 20,
                Rating = 4.7
            },
            new Tour
            {
                Id = 3,
                TourName = "Bali Huzuru",
                Country = "Endonezya",
                City = "Bali",
                ShortDescription = "Tropikal cennet, tapınaklar ve spa dinginliği.",
                Description = "Bali, ruhunuzu dinlendireceğiniz bir cennet adası. Ubud'daki pirinç tarlaları, Tanah Lot tapınağı, geleneksel Balinezce dans gösterileri ve lüks spa deneyimleriyle unutulmaz bir tatil sizi bekliyor.",
                Price = 1500,
                DurationDays = 10,
                IsAvailable = true,
                ImageUrl = "https://images.unsplash.com/photo-1537953773345-d172ccf13cf1?w=800",
                Category = "Doğa",
                MaxPersons = 12,
                Rating = 4.8
            },
            new Tour
            {
                Id = 4,
                TourName = "Paris Romantizmi",
                Country = "Fransa",
                City = "Paris",
                ShortDescription = "Işık şehri, Eyfel Kulesi ve haute cuisine.",
                Description = "Aşk şehri Paris'te romantik bir kaçamak. Eyfel Kulesi, Louvre Müzesi, Notre Dame Katedrali ve Montmartre gezileriyle dolu bu tur; Fransız mutfağının en güzel örneklerini tattıracak restoran deneyimlerini de kapsamaktadır.",
                Price = 1100,
                DurationDays = 7,
                IsAvailable = true,
                ImageUrl = "https://images.unsplash.com/photo-1502602898657-3e91760cbb34?w=800",
                Category = "Romantik",
                MaxPersons = 18,
                Rating = 4.8
            },
            new Tour
            {
                Id = 5,
                TourName = "Tokyo Serüveni",
                Country = "Japonya",
                City = "Tokyo",
                ShortDescription = "Modern ve geleneksel Japonya'yı keşfedin.",
                Description = "Tokyo, gelecek ve geçmişin iç içe geçtiği büyülü bir şehir. Shibuya'nın hareketli caddelerinden Asakusa'nın sakin tapınaklarına, Fuji Dağı'nın görkeminden geleneksel çay seremonisine kadar Japonya'yı tüm boyutlarıyla keşfedin.",
                Price = 1800,
                DurationDays = 12,
                IsAvailable = false,
                ImageUrl = "https://images.unsplash.com/photo-1540959733332-eab4deabeeaf?w=800",
                Category = "Macera",
                MaxPersons = 15,
                Rating = 4.9
            },
            new Tour
            {
                Id = 6,
                TourName = "Kapadokya Masalı",
                Country = "Türkiye",
                City = "Nevşehir",
                ShortDescription = "Peri bacaları, balon turu ve yeraltı şehirleri.",
                Description = "Kapadokya'nın eşsiz coğrafyasında şafakta balon turu, peri bacaları arasında yürüyüş, Derinkuyu yeraltı şehri ve Göreme Açık Hava Müzesi ile dolu etkinlikler sizi bekliyor. Taş oyma butik otellerde konaklama dahildir.",
                Price = 650,
                DurationDays = 4,
                IsAvailable = true,
                ImageUrl = "https://images.unsplash.com/photo-1641128324972-af3212f0f6bd?w=800",
                Category = "Macera",
                MaxPersons = 25,
                Rating = 4.6
            }
        };

        // GET: Tour/Index
        public IActionResult Index(string category = null, bool? available = null)
        {
            var tours = _tours.AsQueryable();

            if (!string.IsNullOrEmpty(category))
                tours = tours.Where(t => t.Category == category);

            if (available.HasValue && available.Value)
                tours = tours.Where(t => t.IsAvailable);

            ViewBag.SelectedCategory = category;
            ViewBag.OnlyAvailable = available;
            ViewBag.Categories = _tours.Select(t => t.Category).Distinct().ToList();

            return View(tours.ToList());
        }

        // GET: Tour/Details/5
        public IActionResult Details(int id)
        {
            var tour = _tours.FirstOrDefault(t => t.Id == id);
            if (tour == null)
                return NotFound();

            ViewBag.RelatedTours = _tours
                .Where(t => t.Id != id && t.Category == tour.Category)
                .Take(2)
                .ToList();

            return View(tour);
        }

        // GET: Tour/Available
        public IActionResult Available()
        {
            var availableTours = _tours.Where(t => t.IsAvailable).ToList();
            ViewBag.OnlyAvailable = true;
            ViewBag.Categories = _tours.Select(t => t.Category).Distinct().ToList();
            return View("Index", availableTours);
        }

        public static Tour GetTourById(int id)
        {
            return _tours.FirstOrDefault(t => t.Id == id);
        }

        public static List<Tour> GetAllTours()
        {
            return _tours;
        }
    }
}
