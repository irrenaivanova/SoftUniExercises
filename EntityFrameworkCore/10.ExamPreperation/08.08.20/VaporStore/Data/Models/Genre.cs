using System;
using System.Collections.Generic;
using System.Text;

namespace VaporStore.Data.Models
{
    public class Genre
    {
        public Genre()
        {
            
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}
