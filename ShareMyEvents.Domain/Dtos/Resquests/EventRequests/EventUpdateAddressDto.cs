using System.ComponentModel.DataAnnotations;
using ShareMyEvents.Domain.Models;

namespace ShareMyEvents.Domain.Dtos.Resquests.EventRequests;
public class EventUpdateAddressDto
{
    public Address? Address { get; set; }

    [Required(ErrorMessage = "Impossible de créer l'évènement, une erreur est survenue [Code071]")]
    public int OrganizerId { get; set; }
}
