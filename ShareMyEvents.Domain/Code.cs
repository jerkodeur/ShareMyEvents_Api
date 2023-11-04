namespace ShareMyEvents.Domain;
public record Code
{
    public Guid Value { get; init; }

    public Code (Guid value)
    {
        Value = value;
    }
}
