using System.ComponentModel.DataAnnotations;
using static Homies.Data.Models.DataConstants;
using Type = Homies.Data.Models.Type;

namespace Homies.Models
{
    public class CreateEventInput
    {
        public int? Id { get; set; } 

        [Required]
        [MinLength(NameEventMinLength)]
        [MaxLength(NameEventMaxLength)]
        public string Name { get; set; }

        [Required]
        [MinLength(DescriptionMinLength)]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public string Start {  get; set; }


        [Required]
        public string End { get; set; }

        [Required]
        public int TypeId { get; set; }

        public List<Type> Types { get; set; } = new List<Type>();
    }
}
