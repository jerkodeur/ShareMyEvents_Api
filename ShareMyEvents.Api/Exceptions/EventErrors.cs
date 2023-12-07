using Jerkoder.Common.Domain.Exceptions;

namespace ShareMyEvents.Api.Exceptions;

public static class EventErrors
{
    public static readonly string NotFoundCode = $"{nameof(Event)}.{BaseError.NotFoundCode}";

    public static Error NotFound(string? name)
    {
        return new(NotFoundCode, $"Event {name} doesn't exist !");
    }
}
