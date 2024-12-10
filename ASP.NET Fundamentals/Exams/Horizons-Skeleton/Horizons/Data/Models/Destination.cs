using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

using static Horizons.Common.DataConstants;

namespace Horizons.Data.Models
{
    public class Destination
    {
        public Destination()
        {
            UsersDestinations = new HashSet<UserDestination>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxLengthDestinationName)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(MaxLengthDescriptionName)]
        public string Description { get; set; } = null!;

        public string? ImageUrl { get; set; }

        [Required]
        public string PublisherId { get; set; } = string.Empty;

        public virtual IdentityUser Publisher { get; set; } = null!;

        public DateTime PublishedOn { get; set; }

        [Required]
        public int TerrainId { get; set; } 

        public Terrain Terrain { get; set; } = null!;

        public bool IsDeleted { get; set; } 
        
        public virtual ICollection<UserDestination> UsersDestinations { get; set; }

    }
}
