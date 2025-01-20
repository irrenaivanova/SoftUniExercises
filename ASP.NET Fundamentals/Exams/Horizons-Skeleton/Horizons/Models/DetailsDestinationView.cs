namespace Horizons.Models
{
    public class DetailsDestinationView
    {
        public int Id { get; set; }
        public string? ImageUrl { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Terrain { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Publisher { get; set; } = null!;

        public DateTime PublishedOn { get; set; } 

        public bool IsPublisher { get; set; }

        public bool IsFavorite { get; set; }
    }
}
