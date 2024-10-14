using System.ComponentModel.DataAnnotations;
using static Homies.Data.Models.DataConstants;

namespace Homies.Data.Models
{
    public class Type
    {
        public Type()
        {
            Events = new List<Event>();
        }

        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(NameTypeMaxLength)]
        public string Name { get; set; } = string.Empty;

        public virtual IEnumerable<Event> Events { get; set; }
    }
}
