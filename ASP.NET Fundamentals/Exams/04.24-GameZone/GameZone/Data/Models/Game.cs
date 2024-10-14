using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static GameZone.Data.Models.DataConstants.Game;

namespace GameZone.Data.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxTitleLength)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; } = string.Empty;

        public string? ImageUrl { get; set; }

        [Required]
        [ForeignKey(nameof(Publisher))]
        public string PublisherId { get; set; } = string.Empty;
        public virtual IdentityUser Publisher { get; set; } = null!;

        [Required]
        public DateTime ReleasedOn { get; set; }

        [Required]
        [ForeignKey(nameof(Genre))]
        public int GenreId { get; set; }
        
        public virtual Genre Genre { get; set; } = null!;

        public ICollection<GamerGame> GamersGames { get; set; } = new List<GamerGame>();    
    }
}

