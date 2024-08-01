using System;
using System.Collections.Generic;
using System.Text;

namespace VaporStore.DataProcessor.Dto.Export
{
    public class GenreExport
    {
        public int Id { get; set; }
        public string Genre { get; set; }
        public ICollection<GameExport> Games  { get; set; }

        public int TotalPlayers { get; set; }
    }
}
