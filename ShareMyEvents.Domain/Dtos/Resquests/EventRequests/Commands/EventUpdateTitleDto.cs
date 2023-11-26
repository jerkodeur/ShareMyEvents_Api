using System.ComponentModel.DataAnnotations;

namespace ShareMyEvents.Domain.Dtos.Resquests.EventRequests.Commands;
public class EventUpdateTitleDto
{
    [Required(ErrorMessage = "Ce champ ne peut être null")]
    public required string Title { get; set; }
}
