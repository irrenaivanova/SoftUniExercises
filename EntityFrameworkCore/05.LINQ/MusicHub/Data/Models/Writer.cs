

using System.ComponentModel.DataAnnotations;

namespace MusicHub.Data.Models;

public class Writer
{
    public int Id { get; set; }

    [MaxLength(Validation.MaxLengthName)]
    public string Name { get; set; }
    public string? Pseudonym { get; set; }

    public virtual ICollection<Song> Songs { get; set; }

}
