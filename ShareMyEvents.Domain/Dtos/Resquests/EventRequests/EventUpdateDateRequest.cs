using System.ComponentModel.DataAnnotations;

namespace ShareMyEvents.Domain.Dtos.Resquests.EventRequests;
public class EventUpdateDateRequest
{
    [Required(ErrorMessage = "Ce champ ne peut être null")]
    public DateTime EventDate { get; set; }

    [Required(ErrorMessage = "Impossible de créer l'évènement, une erreur est survenue [Code071]")]
    public int OrganizerId { get; set; }
}
