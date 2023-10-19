namespace ShareMyEvents.Domain.Dtos.Responses.EventResponses;
public class EventUpdateDescriptionResponse
{
    public int EventId { get; set; }
    public required string Description{ get; set; }
}
