
using System.ComponentModel.DataAnnotations;

namespace MusicHub.Data.Models;

public class Performer
{
    public Performer()
    {
        this.PerformerSongs =new HashSet<SongPerformer>();  
    }

    public int Id { get; set; }

    [MaxLength(Validation.MaxLengthName)]
    public string FirstName { get; set; }

    [MaxLength(Validation.MaxLengthName)]
    public string LastName { get; set; }
    public int Age { get; set; }
    public decimal NetWorth { get; set; }

    public virtual ICollection<SongPerformer> PerformerSongs { get; set; }
}
