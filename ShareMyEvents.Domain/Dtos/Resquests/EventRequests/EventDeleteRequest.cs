using System.ComponentModel.DataAnnotations;

namespace ShareMyEvents.Domain.Dtos.Resquests.EventRequests;
public class EventDeleteRequest
{
    [Required(ErrorMessage = "Impossible de supprimer l'évènement, une erreur est survenue [Code071]")]
    public int OrganizerId { get; set; }
}
