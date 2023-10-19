namespace ShareMyEvents.Domain.Dtos.Responses.EventResponses;
public class EventUpdateTitleResponse
{
    public int EventId { get; set; }
    public required string Title{ get; set; }
}
