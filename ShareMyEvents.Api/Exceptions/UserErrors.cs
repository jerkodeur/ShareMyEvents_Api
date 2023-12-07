using Jerkoder.Common.Domain.Exceptions;

namespace ShareMyEvents.Api.Exceptions;

public class UserErrors
{
    public static readonly string NotFoundCode = $"{nameof(User)}.{BaseError.NotFoundCode}";

    public static Error NotFound (string? name)
    {
        return new(NotFoundCode, $"User {name} doesn't exist !");
    }
}
