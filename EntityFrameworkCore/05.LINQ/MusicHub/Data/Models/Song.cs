﻿using MusicHub.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace MusicHub.Data.Models;

public class Song
{
    public Song()
    {
        this.SongPerformers = new List<SongPerformer>();    
    }

    public int Id { get; set; }
    
    [MaxLength(Validation.MaxLengthSongName)]
    public string Name { get; set; }

    public TimeSpan Duration { get; set; }

    public DateTime CreatedOn { get; set; }
    public Genre Genre { get; set; }

    public int? AlbumId { get; set; }

    public virtual Album? Album { get; set; }
    public int WriterId { get; set; }

    public virtual Writer Writer { get; set; }
    public decimal Price { get; set; }
    public virtual ICollection<SongPerformer> SongPerformers { get; set; }

}

