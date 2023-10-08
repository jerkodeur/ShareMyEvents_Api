namespace ShareMyEvent.Api.Domain.Models;

public class Event: AbstractEntity
{
    public Event(string code, string title, string description, DateTime eventDate, Address address, Actor organizer)
    {
        Code = code;
        Title = title;
        Description = description;
        EventDate = eventDate;
        Address = address;
        Organizer = organizer;
    }

    public string Code { get; init; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime EventDate { get; set; }

    public int OrganizerId { get; set; }
    public int AdressId { get; set; }

    public Address Address { get; set; }
    public Actor Organizer { get; set; }
}
