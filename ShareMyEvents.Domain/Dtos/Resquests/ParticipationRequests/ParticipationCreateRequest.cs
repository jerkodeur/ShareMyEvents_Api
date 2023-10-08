using System.ComponentModel.DataAnnotations;

namespace ShareMyEvents.Domain.Dtos.Resquests.ParticipationRequests;
public class ParticipationCreateRequest
{
    [Required(ErrorMessage = "Ce champ ne peut être null")]
    public required string Name { get; set; }

    [Required(ErrorMessage = "Ce champ ne peut être null")]
    public required  string Email { get; set; }

    [Required(ErrorMessage = "Ce champ ne peut être null")]
    public int EventId { get; set; }
}
