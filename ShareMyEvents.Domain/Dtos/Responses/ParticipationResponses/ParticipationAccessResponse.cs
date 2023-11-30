namespace ShareMyEvents.Domain.Dtos.Responses.ParticipantResponses;
public class ParticipationAccessResponse
{
    public int ParticipantId { get; init; }
    public int EventId { get; init; }
    public Enums.Availability Availability { get; init; }
}
