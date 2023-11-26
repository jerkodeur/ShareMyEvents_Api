using Jerkoder.Common.Domain.CQRS.Interfaces;

namespace Jerkoder.Common.Domain.Exceptions;
public sealed record Error(string code, string? Description = null)
{
    public static readonly Error None = new(string.Empty);

    public static implicit operator Result(Error error) => Result.Failure(error);
}
