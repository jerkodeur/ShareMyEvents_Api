using System.ComponentModel.DataAnnotations;

namespace ShareMyEvents.Domain.Dtos.Resquests.EventRequests;
public class EventUpdateDescriptionRequest
{
    [Required(ErrorMessage = "Ce champ ne peut être null")]
    public required string Description { get; set; }
}
