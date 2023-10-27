using System.ComponentModel.DataAnnotations;
using ShareMyEvents.Domain.Models;

namespace ShareMyEvents.Domain.Dtos.Resquests.EventRequests;
public class EventCreateDto
{
    [Required(ErrorMessage = "Ce champ ne peut être null")]
    public required string Title { get; set; }


    [Required(ErrorMessage = "Ce champ ne peut être null")]
    public required string Description { get; set; }


    [Required(ErrorMessage = "Ce champ ne peut être null")]
    public DateTime EventDate { get; set; }

    public Address? Address { get; set; }
}
