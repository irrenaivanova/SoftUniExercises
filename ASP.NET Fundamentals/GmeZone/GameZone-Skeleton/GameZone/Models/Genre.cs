using System.ComponentModel.DataAnnotations;

namespace GameZone.Models
{
    public class Genre
    {
        public Genre()
        {
            this.Games = new HashSet<Game>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(EntityConstants.GenreNameMaxLength)]
        public string Name { get; set; } = string.Empty;

        public virtual IEnumerable<Game> Games { get; set; }
    }
}
