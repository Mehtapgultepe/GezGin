# ✈️ GezGin — Seyahat Acentesi Web Sitesi

> LBLM362 Web Programlama dersi kapsamında ASP.NET Core MVC ile geliştirilmiş seyahat acentesi web uygulaması.

---

## 📋 Proje Hakkında

**GezGin**, gerçek bir seyahat acentesinin dijital ihtiyaçlarını karşılamak üzere tasarlanmış, 5 sayfalı tam işlevsel bir web uygulamasıdır. Kullanıcılar turları listeleyebilir, detaylarını inceleyebilir ve online rezervasyon yapabilir.

| Bilgi | Detay |
|---|---|
| Ders | LBLM362 Web Programlama |
| Hoca | Doç. Dr. Pınar Karadayı Ataş |
| Dönem | 2025-2026 Bahar |
| Öğrenci | Mehtap Gültepe |

---

## 🔗 Proje Linkleri

- 🎥 **Demo Video:** [Google Drive](https://drive.google.com/file/d/1PdYeOoMgi2OBoZMLZ3pBMkZQDOSOZ_WR/view?usp=share_link)
- 📊 **Sunum:** [Google Slides](https://docs.google.com/presentation/d/1TytSqey7dTe4qAPN2ikcOcps8TYGLniT/edit?usp=sharing)
- 💻 **GitHub:** [github.com/Mehtapgultepe/GezGin](https://github.com/Mehtapgultepe/GezGin)

---

## 🛠️ Kullanılan Teknolojiler

- **ASP.NET Core MVC** (.NET 10)
- **HTML5 & CSS3**
- **JavaScript ES6+**
- **Bootstrap 5.3**
- **Font Awesome 6.4**
- **Google Fonts** (Playfair Display & Poppins)

---

## 📁 Proje Yapısı

```
GezGin/
├── Controllers/
│   ├── HomeController.cs
│   ├── TourController.cs
│   ├── BookingController.cs
│   └── AboutController.cs
├── Models/
│   ├── Tour.cs
│   └── Booking.cs
├── Views/
│   ├── Home/
│   │   └── Index.cshtml
│   ├── Tour/
│   │   ├── Index.cshtml
│   │   └── Details.cshtml
│   ├── Booking/
│   │   ├── Create.cshtml
│   │   └── Confirmation.cshtml
│   ├── About/
│   │   └── Index.cshtml
│   └── Shared/
│       └── _Layout.cshtml
├── wwwroot/
│   ├── css/site.css
│   └── js/site.js
├── Program.cs
└── GezGin.csproj
```

---

## 📄 Sayfalar

| # | Sayfa | URL | Açıklama |
|---|---|---|---|
| 1 | Ana Sayfa | `/` | Hero banner, öne çıkan turlar, istatistikler |
| 2 | Tur Listesi | `/Tour/Index` | Tüm turlar, kategori ve müsaitlik filtresi |
| 3 | Tur Detayı | `/Tour/Details/{id}` | Tur bilgileri, fiyat, dahil olanlar |
| 4 | Rezervasyon | `/Booking/Create` | Form doğrulama, dinamik fiyat hesaplama |
| 5 | Onay | `/Booking/Confirmation/{id}` | Rezervasyon onay sayfası |
| + | Hakkımızda | `/About/Index` | Şirket, ekip ve iletişim |
| + | Müsait Turlar | `/Tour/Available` | Sadece müsait turlar |

---

## 🚀 Kurulum ve Çalıştırma

### Gereksinimler
- .NET 10 SDK → [İndir](https://dotnet.microsoft.com/download/dotnet/10.0)

### Adımlar

```bash
# Repoyu klonla
git clone https://github.com/Mehtapgultepe/GezGin.git

# Klasöre gir
cd GezGin

# Çalıştır
dotnet run
```

Tarayıcıda aç: **http://localhost:5000**

---

## 🗄️ Veri Modelleri

### Tour Modeli
```csharp
public class Tour
{
    public int Id { get; set; }
    public string TourName { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int DurationDays { get; set; }
    public bool IsAvailable { get; set; }
    public string Category { get; set; }
    public int MaxPersons { get; set; }
    public double Rating { get; set; }
}
```

### Booking Modeli
```csharp
public class Booking
{
    public int Id { get; set; }
    [Required] public string FullName { get; set; }
    [Required][EmailAddress] public string Email { get; set; }
    [Required] public string Phone { get; set; }
    [Range(1, 20)] public int PersonCount { get; set; }
    [Required] public DateTime TravelDate { get; set; }
    [Required] public int SelectedTourId { get; set; }
    public string Notes { get; set; }
}
```

---

## ✈️ Başlangıç Tur Verileri

| Tur Adı | Ülke | Kategori | Fiyat | Durum |
|---|---|---|---|---|
| Santorini Rüyası | Yunanistan | Romantik | 1.200 € | Müsait |
| Roma'nın İzinde | İtalya | Kültür | 950 € | Müsait |
| Bali Huzuru | Endonezya | Doğa | 1.500 € | Müsait |
| Paris Romantizmi | Fransa | Romantik | 1.100 € | Müsait |
| Tokyo Serüveni | Japonya | Macera | 1.800 € | Dolu |
| Kapadokya Masalı | Türkiye | Macera | 650 € | Müsait |

---

## ⭐ Özellikler

- MVC mimarisi ile katmanlı kod organizasyonu
- Veritabanısız `static List<T>` ile veri yönetimi
- `Data Annotations` ile sunucu taraflı form doğrulama
- Bootstrap 5 ile tam responsive tasarım
- JavaScript ile anlık fiyat hesaplama
- Kategori ve müsaitlik bazlı tur filtreleme
- `AntiForgeryToken` ile form güvenliği
- `ViewBag` ile Controller-View arası veri aktarımı

---

*LBLM362 Web Programlama — Arel Üniversitesi — 2025-2026 Bahar*
