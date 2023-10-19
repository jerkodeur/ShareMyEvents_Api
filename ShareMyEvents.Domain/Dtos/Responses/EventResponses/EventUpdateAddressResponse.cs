using ShareMyEvents.Domain.Models;

namespace ShareMyEvents.Domain.Dtos.Responses.EventResponses;
public class EventUpdateAddressResponse
{
    public int EventId { get; set; }
    public Address? Address{ get; set; }
}
