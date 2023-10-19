namespace ShareMyEvents.Domain.Dtos.Responses.EventResponses;
public class EventUpdateDateResponse
{
    public int EventId { get; set; }
    public required DateTime Date { get; set; }
}
