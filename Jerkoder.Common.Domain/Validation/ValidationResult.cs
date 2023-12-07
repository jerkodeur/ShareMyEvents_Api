using Jerkoder.Common.Domain.CQRS.Interfaces;
using Jerkoder.Common.Domain.Exceptions;

namespace Jerkoder.Common.Domain.Validation;

public sealed class ValidationResult: Result, IValidationResult
{
    public Error[] Errors {  get; }

    private ValidationResult (Error[] errors)
        : base(false, ValidationError.Get) => Errors = errors;

    public static ValidationResult WithErrors (Error[] errors) => new(errors);
}

public sealed class ValidationResult<TValue>: Result<TValue>, IValidationResult
    where TValue : class
{
    public Error[] Errors { get; }

    private ValidationResult (Error[] errors)
        : base(false, ValidationError.Get) => Errors = errors;

    public static ValidationResult<TValue> WithErrors (Error[] errors) => new(errors);
}
