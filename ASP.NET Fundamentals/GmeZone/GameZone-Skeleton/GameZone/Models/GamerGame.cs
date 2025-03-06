using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GameZone.Models
{
    public class GamerGame
    {
        [Key]
        public int GameId { get; set; }

        [ForeignKey(nameof(GameId))]
        public virtual Game Game { get; set; } = null!;

        [Key]
        public string GamerId { get; set; } = string.Empty;

        [ForeignKey(nameof(GamerId))]
        public virtual IdentityUser Gamer { get; set; } = null!;
    }
}
