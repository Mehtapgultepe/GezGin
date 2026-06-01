namespace GezGin.Models
{
    public class Tour
    {
        public int Id { get; set; }
        public string TourName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public decimal Price { get; set; }
        public int DurationDays { get; set; }
        public bool IsAvailable { get; set; }
        public string ImageUrl { get; set; }
        public string Category { get; set; }
        public int MaxPersons { get; set; }
        public double Rating { get; set; }
    }
}
