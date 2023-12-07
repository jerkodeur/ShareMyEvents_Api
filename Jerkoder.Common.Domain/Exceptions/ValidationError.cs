namespace Jerkoder.Common.Domain.Exceptions;

public static class ValidationError
{
    public static readonly Error Get = new(
        code: BaseError.ValidationErrorCode,
        Description: "A validation problem occured.");
}
