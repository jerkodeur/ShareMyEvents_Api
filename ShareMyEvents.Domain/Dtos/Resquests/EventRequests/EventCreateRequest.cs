using System.ComponentModel.DataAnnotations;
using ShareMyEvents.Domain.Models;

namespace ShareMyEvents.Domain.Dtos.Resquests.EventRequests;
public class EventCreateRequest
{
    [Required(ErrorMessage = "Ce champ ne peut être null")]
    public string Title { get; set; } = string.Empty;


    [Required(ErrorMessage = "Ce champ ne peut être null")]
    public string Description { get; set; } = string.Empty;


    [Required(ErrorMessage = "Ce champ ne peut être null")]
    public DateTime EventDate { get; set; }

    public Address? Address { get; set; }


    [Required(ErrorMessage = "Impossible de créer l'évènement, une erreur est survenue [Code071]")]
    public int OrganizerId { get; set; }
}
