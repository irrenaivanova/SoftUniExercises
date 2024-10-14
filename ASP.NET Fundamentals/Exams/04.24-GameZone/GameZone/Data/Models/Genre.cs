using System.ComponentModel.DataAnnotations;
using static GameZone.Data.Models.DataConstants.Genre;

namespace GameZone.Data.Models
{
    public class Genre
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxGenreLength)]
        public string Name { get; set; } = string.Empty;

        public ICollection<Game> Games { get; set; } = new List<Game>();
    }
}
