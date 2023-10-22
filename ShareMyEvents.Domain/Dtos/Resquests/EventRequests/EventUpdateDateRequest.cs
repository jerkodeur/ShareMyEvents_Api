using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ShareMyEvents.Domain.Dtos.Resquests.EventRequests;
public class EventUpdateDateRequest
{
    [Required(ErrorMessage = "Ce champ ne peut être null")]
    [DefaultValue("23-10-2023 04:00:22")]
    public DateTime EventDate { get; set; }
}
