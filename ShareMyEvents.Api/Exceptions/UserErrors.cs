using Jerkoder.Common.Domain.Exceptions;

namespace ShareMyEvents.Api.Exceptions;

public class UserErrors
{
    public static Error NotFound (string? name)
    {
        return new("User.NotFound", $"User {name} doesn't exist !");
    }
}
