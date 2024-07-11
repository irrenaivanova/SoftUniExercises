using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MusicHub.Data.Models
{
    public class Album
    {
        public Album()
        {
            this.Songs = new HashSet<Song>();
        }

        public int Id { get; set; }

        [MaxLength(Validation.MaxLengthAlbumName)]
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }

        public int? ProducerId { get; set; }

        public virtual Producer? Producer { get; set; }

        public virtual ICollection<Song> Songs { get; set; }

        public decimal Price => Songs.Sum(x => x.Price);

    }
}
