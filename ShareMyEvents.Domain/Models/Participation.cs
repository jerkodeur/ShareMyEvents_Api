namespace ShareMyEvents.Domain.Models;

public class Participation: AbstractEntity
{
    public Participation (Actor actor, Event @event)
    {
        Participant = actor;
        Event = @event;
    }

    public int ParticipantId { get; set; }
    public int EventId { get; set; }
    public int AvailabilityId { get; set; }

    public Actor Participant { get; set; }
    public Event Event { get; set; }
    public Availability? Availability { get; set; }
}
