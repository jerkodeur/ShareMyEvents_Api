using System.ComponentModel.DataAnnotations;

namespace ShareMyEvents.Domain.Dtos.Resquests.EventRequests;
public class EventUpdateTitleRequest
{
    [Required(ErrorMessage = "Ce champ ne peut être null")]
    public required string Title { get; set; }
}
