namespace ShareMyEvents.Domain.Models;

public class Event: AbstractEntity
{
    public Event (string code, string title, string description, DateTime eventDate, Address? address, Actor organizer)
    {
        Code = code;
        Title = title;
        Description = description;
        EventDate = eventDate;
        Address = address;
        Organizer = organizer;
    }

    public required string Code { get; init; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required DateTime EventDate { get; set; }

    public required int OrganizerId { get; set; }
    public int? AdressId { get; set; }

    public Address? Address { get; set; }
    public Actor Organizer { get; set; }
    public List<Actor>? Participants { get; set; }
}
