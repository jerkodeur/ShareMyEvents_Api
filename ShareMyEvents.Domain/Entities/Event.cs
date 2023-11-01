using System.ComponentModel.DataAnnotations;

namespace ShareMyEvents.Domain.Models;

public class Event: AbstractEntity
{
    [Required]
    public required string Code { get; init; }

    [Required]
    public required string Title { get; set; }

    [Required]
    public required string Description { get; set; }

    [Required]
    public required DateTime EventDate { get; set; }

    public int OrganizerId { get; set; }
    public int? AdressId { get; set; }

    public Address? Address { get; set; }
    public Actor Organizer { get; set; }
}
