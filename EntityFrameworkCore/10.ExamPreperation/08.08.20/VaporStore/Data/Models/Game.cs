using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
//using static Microsoft.EntityFrameworkCore.Internal.DbContextPool<TContext>;

namespace VaporStore.Data.Models
{
    public class Game
    {
        public Game()
        {
            Purchases = new List<Purchase>();
            GameTags = new List<GameTag>(); 
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        
        //[MinLength(0)]
        public decimal Price { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int DeveloperId { get; set; }

        public virtual Developer Developer { get; set; }

        public int GenreId { get; set; }

        public virtual Genre Genre { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }

        public virtual ICollection<GameTag> GameTags { get; set; }

    }
}
