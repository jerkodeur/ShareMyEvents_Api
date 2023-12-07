using System.ComponentModel;
using ShareMyEvents.Domain.Entities;

namespace ShareMyEvents.Domain.Dtos.Requests.EventRequests;
public class EventCreateDto
{
    [DefaultValue("My Event")]
    public string Title { get; set; } = string.Empty;

    [DefaultValue("Come on !")]
    public string Description { get; set; } = string.Empty;

    [DefaultValue("2023-10-27T22:15:55.151Z")]
    public DateTime Date { get; set; }

    public Address? Address { get; set; }
}
