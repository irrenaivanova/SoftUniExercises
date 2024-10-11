
using System.ComponentModel.DataAnnotations;
using static CinemaApp.Web.Constants.EntityValidationConstants.Movie;


namespace CinemaApp.Web.ViewModels
{
    public class InputMovie
    {
      
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

   
        [MinLength(GenreMinLength)]
        [MaxLength(GenreMaxLength)]
        public string Genre { get; set; } = null!;


        public string ReleaseDate { get; set; }

   
        [Range(DurationMinValue, DurationMaxValue)]
        public int Duration { get; set; }


        [MinLength(DirectorNameMinLength)]
        [MaxLength(DirectorNameMaxLength)]
        public string Director { get; set; } = null!;

        [Required]
        [MinLength(DescriptionMinLength)]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;
    }
}
