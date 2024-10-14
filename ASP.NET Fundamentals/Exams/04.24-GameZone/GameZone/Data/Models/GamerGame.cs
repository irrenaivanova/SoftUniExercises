using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameZone.Data.Models
{
    public class GamerGame
    {
        [Required]
        [ForeignKey(nameof(Game))]
        public int GameId { get; set; }
        public Game Game { get; set; }

        [Required]
        [ForeignKey(nameof(Gamer))]
        public string GamerId { get; set; }
        public IdentityUser Gamer { get; set; }
    }
}
