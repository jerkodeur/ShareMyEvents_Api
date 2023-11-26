using System.ComponentModel.DataAnnotations;

namespace ShareMyEvents.Domain.Dtos.Resquests.ParticipationRequests;
public class ParticipationAccessDto
{
    [Required(ErrorMessage = "Ce champ ne peut être null")]
    public required string EventCode { get; set; }

    [Required(ErrorMessage = "Ce champ ne peut être null")]
    public required string Email { get; set; }
}
