using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Homies.Data.Models.DataConstants;

namespace Homies.Data.Models
{
    public class Event
    {
        public Event()
        {
            EventsParticipants = new List<EventParticipant>();
        }

        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(NameEventMaxLength)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description  {get; set; } = string.Empty;
        
        [Required]
        public string OrganiserId { get; set; } = string.Empty;

        [ForeignKey(nameof(OrganiserId))]
        public virtual IdentityUser Organiser { get; set; } = null!;
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public DateTime Start { get; set; }
        [Required]
        public DateTime End { get; set; }

        [Required]
        public int TypeId { get; set; } 

        [ForeignKey(nameof(TypeId))]
        public virtual Type Type { get; set; }

        public virtual IEnumerable<EventParticipant> EventsParticipants { get; set; }
    }
}
