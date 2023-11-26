using System.ComponentModel.DataAnnotations;

namespace ShareMyEvents.Domain.Dtos.Resquests.ParticipationRequests;

public class ParticipationUpdateAvailabilityDto
{
    [Required(ErrorMessage = "Ce champ ne peut être null")]
    public int ParticipationId { get; set; }

    [Required(ErrorMessage = "Ce champ ne peut être null")]
    public int EventId { get; set; }

    [Required(ErrorMessage = "Ce champ ne peut être null")]
    public int AvailabilityId { get; set; }
}
