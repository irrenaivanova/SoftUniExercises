using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Horizons.Data.Models
{
    public class UserDestination
    {
        [Required]
        public int DestinationId { get; set; }

        public Destination Destination { get; set; } = null!;

        [Required]
        public string UserId { get; set; } = string.Empty;

        public IdentityUser User { get; set; } = null!;
    }
}
