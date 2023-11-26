using Jerkoder.Common.Domain.Exceptions;

namespace ShareMyEvents.Api.Exceptions;

public static class EventErrors
{
    public static Error NotFound(string? name)
    {
        return new("Event.NotFound", $"Event {name} doesn't exist !");
    }
}
