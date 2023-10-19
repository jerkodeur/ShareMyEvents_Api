using System.ComponentModel.DataAnnotations;

namespace ShareMyEvents.Domain.Dtos.Resquests.EventRequests;
public class EventUpdateDateRequest
{
    [Required(ErrorMessage = "Ce champ ne peut être null")]
    public DateTime EventDate { get; set; }
}
