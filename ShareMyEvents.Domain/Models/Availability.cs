namespace ShareMyEvents.Domain.Models;

public class Availability: AbstractEntity
{
    public Availability (string label)
    {
        Label = label;
    }

    public string Label { get; set; } = string.Empty;
}
