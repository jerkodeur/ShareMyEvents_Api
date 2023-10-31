using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ShareMyEvents.Domain.Models;

namespace ShareMyEvents.Domain.Dtos.Resquests.EventRequests;
public class EventCreateDto
{
    [Required(ErrorMessage = "Ce champ ne peut être null")]
    [DefaultValue("My Event")]
    public required string Title { get; set; }


    [Required(ErrorMessage = "Ce champ ne peut être null")]
    [DefaultValue("Come on !")]
    public required string Description { get; set; }


    [Required(ErrorMessage = "Ce champ ne peut être null")]
    [DefaultValue("2023/10/29 20:16:00")]
    public DateTime EventDate { get; set; }

    public Address? Address { get; set; }
}
