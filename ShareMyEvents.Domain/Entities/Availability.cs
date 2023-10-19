using System.ComponentModel.DataAnnotations;

namespace ShareMyEvents.Domain.Models;

public class Availability: AbstractEntity
{
    public Availability (string label)
    {
        Label = label;
    }

    [Required]
    public string Label { get; set; }
}
