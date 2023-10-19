using System.ComponentModel.DataAnnotations;

namespace ShareMyEvents.Domain.Models;

public class Event: AbstractEntity
{
    [Required]
    public string Code { get; init; }

    [Required]
    public string Title { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public DateTime EventDate { get; set; }

    public int OrganizerId { get; set; }
    public int? AdressId { get; set; }

    public Address? Address { get; set; }
    public Actor Organizer { get; set; }
}
