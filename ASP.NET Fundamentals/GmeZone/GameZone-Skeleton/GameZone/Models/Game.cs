using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameZone.Models
{
    public class Game
    {
        public Game()
        {
            this.GamerGames = new HashSet<GamerGame>();
        }

        [Key]
        public int Id { get; set; }

        public bool IsDeleted { get; set; }

        [Required]
        [MaxLength(EntityConstants.TitleMaxLength)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(EntityConstants.DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        public string? ImageUrl { get; set; }

        [Required]
        public string PublisherId { get; set; } = null!;

        [ForeignKey(nameof(PublisherId))]
        public virtual IdentityUser Publisher { get; set; } = null!;

        [Required]
        public DateTime ReleasedOn { get; set; }


        [Required]
        public int GenreId { get; set; }

        [ForeignKey(nameof(GenreId))]
        public virtual Genre Genre { get; set; } = null!;

        public virtual IEnumerable<GamerGame> GamerGames { get; set; }


    }
}
