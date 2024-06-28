using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_FootballBetting.Data.Models
{
    public class Player
    {
        public Player()
        {
            this.PlayersStatistics = new HashSet<PlayerStatistic>();
        }

        public int PlayerId { get; set; }
        [Required]
        public string Name { get; set; }
        public int SquadNumber { get; set; }
        public bool IsInjured { get; set; }
        public int PositionId { get; set; }
        public virtual Position Position { get; set; }
        public int? TeamId { get; set; }
        public virtual Team? Teams { get; set; }
        public int TownId { get; set; }
        public virtual Town Town { get; set; }

        public virtual ICollection<PlayerStatistic> PlayersStatistics { get; set; }
    }
}
