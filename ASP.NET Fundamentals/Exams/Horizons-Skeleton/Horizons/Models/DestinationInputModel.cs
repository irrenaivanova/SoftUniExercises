namespace Horizons.Models
{
    using Horizons.Data.Models;
    using System.ComponentModel.DataAnnotations;
    using static Horizons.Common.DataConstants;
    public class DestinationInputModel
    {

        [Required]
        [MinLength(MinLengthDestinationName)]
        [MaxLength(MaxLengthDestinationName)]
        public string Name { get; set; } = null!;

        public string? ImageUrl { get; set; }

        [Required]
        [MinLength(MinLengthDescriptionName)]
        [MaxLength(MaxLengthDescriptionName)]
        public string Description { get; set; } = null!;

        [Required]
        public string PublishedOn { get; set; } = null!;

        [Required]
        public int TerrainId { get; set; }

        public IEnumerable<TerrainViewModel> Terrains { get; set; } = new List<TerrainViewModel>();
    }
}
