using System.ComponentModel.DataAnnotations;

namespace GezGin.Models
{
    public class Booking
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ad Soyad zorunludur.")]
        [Display(Name = "Ad Soyad")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "E-posta zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta giriniz.")]
        [Display(Name = "E-posta")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefon numarası zorunludur.")]
        [Display(Name = "Telefon")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Kişi sayısı zorunludur.")]
        [Range(1, 20, ErrorMessage = "Kişi sayısı 1-20 arasında olmalıdır.")]
        [Display(Name = "Kişi Sayısı")]
        public int PersonCount { get; set; }

        [Required(ErrorMessage = "Tarih zorunludur.")]
        [Display(Name = "Gidiş Tarihi")]
        public DateTime TravelDate { get; set; }

        [Required(ErrorMessage = "Lütfen bir tur seçiniz.")]
        [Display(Name = "Tur")]
        public int SelectedTourId { get; set; }

        [Display(Name = "Notlar")]
        public string Notes { get; set; }
    }
}
