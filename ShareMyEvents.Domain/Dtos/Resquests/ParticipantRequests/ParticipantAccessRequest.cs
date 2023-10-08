using System.ComponentModel.DataAnnotations;

namespace ShareMyEvents.Domain.Dtos.Resquests.ParticipantRequests;
public class ParticipantAccessRequest
{
    [Required(ErrorMessage = "Ce champ ne peut être null")]
    public string EventCode { get; set; } = string.Empty;

    [Required(ErrorMessage = "Ce champ ne peut être null")]
    public string Email { get; set; } = string.Empty;
}
