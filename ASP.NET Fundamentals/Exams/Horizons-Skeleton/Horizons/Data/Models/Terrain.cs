using System.ComponentModel.DataAnnotations;
using static Horizons.Common.DataConstants;

namespace Horizons.Data.Models
{
    public class Terrain
    {
        public Terrain()
        {
              Destinations = new HashSet<Destination>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxLengthTerrainName)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Destination> Destinations { get; set; }
    }
}
