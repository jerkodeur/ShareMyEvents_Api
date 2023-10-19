using ShareMyEvents.Domain.Models;

namespace ShareMyEvents.Domain.Dtos.Responses.EventResponses;
public class EventPageResponse
{
    public required Event Event { get; set; }
    public required Actor Organizer { get; set; }
    public IEnumerable<int>? Participants { get; set;}
}
