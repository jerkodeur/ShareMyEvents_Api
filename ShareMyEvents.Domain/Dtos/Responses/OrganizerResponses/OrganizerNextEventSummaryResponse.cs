﻿namespace ShareMyEvents.Domain.Dtos.Responses.OrganizerResponses;
public class OrganizerNextEventSummaryResponse
{
    public int Id { get; init; }
    public string Title { get; init; } = string.Empty;
    public DateTime EventDate { get; init; }
    public int NbParticipants { get; init; }
}
