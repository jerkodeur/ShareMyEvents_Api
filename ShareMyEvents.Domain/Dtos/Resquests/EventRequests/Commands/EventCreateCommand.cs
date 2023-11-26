using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Jerkoder.Common.Domain.CQRS.Interfaces;
using ShareMyEvents.Domain.Dtos.Responses.EventResponses;
using ShareMyEvents.Domain.Entities;

namespace ShareMyEvents.Domain.Dtos.Resquests.EventRequests.Commands;
public class EventCreateCommand : ICommand<EventCreatedResponse>
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
