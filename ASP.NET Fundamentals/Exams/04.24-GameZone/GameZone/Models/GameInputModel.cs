using GameZone.Data.Models;
using System.ComponentModel.DataAnnotations;
using static GameZone.Data.Models.DataConstants.Game;

namespace GameZone.Models
{
    public class GameInputModel
    {
        public int? GameId { get; set; }

        [Required]
        [MinLength(MinTitleLength)]
        [MaxLength(MaxTitleLength)]
        public string Title { get; set; } = string.Empty;
       
        public string? ImageUrl { get; set; } = string.Empty;

        [Required]
        [MinLength(MinDescriptionLength)]
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; } = string.Empty;
        
        [Required]
        public string ReleasedOn { get; set; }

        public int GenreId { get; set; } 

        [Required]
        public IEnumerable<Genre> Genres { get; set; } = new List<Genre>();
    }


}
