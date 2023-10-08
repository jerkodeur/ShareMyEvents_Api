using System.ComponentModel.DataAnnotations;

namespace ShareMyEvents.Domain.Dtos.Resquests.EventRequests;
public class EventUpdateTitleRequest
{
    [Required(ErrorMessage = "Ce champ ne peut être null")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Impossible de créer l'évènement, une erreur est survenue [Code071]")]
    public int OrganizerId { get; set; }
}
