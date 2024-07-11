
using System.ComponentModel.DataAnnotations;

namespace MusicHub.Data.Models;

public class Producer
{
    public Producer()
    {
        this.Albums = new List<Album>();    
    }

    public int Id { get; set; }


    [MaxLength(Validation.MaxProducerLengthName)]
    public string Name { get; set; }

    public string? Pseudonym { get; set; }
    public string? PhoneNumber { get; set; }

    public virtual ICollection<Album> Albums {  get; set; }
}
