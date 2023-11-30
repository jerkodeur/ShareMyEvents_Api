using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ShareMyEvents.Domain.Entities;

namespace ShareMyEvents.Domain.Dtos.Requests.EventRequests;
public class EventCreateDto
{
    [Required(ErrorMessage = "Ce champ ne peut être null")]
    [DefaultValue("My Event")]
    public required string Title { get; set; }


    [Required(ErrorMessage = "Ce champ ne peut être null")]
    [DefaultValue("Come on !")]
    public required string Description { get; set; }


    [Required(ErrorMessage = "Ce champ ne peut être null")]
    [DefaultValue("2023-10-27T22:15:55.151Z")]
    public DateTime EventDate { get; set; }

    public Address? Address { get; set; }
}
