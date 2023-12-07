using FluentValidation;
using Jerkoder.Common.Domain.CQRS.Interfaces;
using Jerkoder.Common.Domain.Exceptions;
using Jerkoder.Common.Domain.Validation;
using MediatR;

namespace ShareMyEvents.Api.Behaviors;

public class ValidationPipelineBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : class
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationPipelineBehavior (IEnumerable<IValidator<TRequest>> validators) => 
        _validators = validators;

    /// <summary>
    /// Validate Request, if any errors, return validation result, otherwise, return next()
    /// </summary>
    public async Task<TResponse> Handle (
        TRequest request, 
        RequestHandlerDelegate<TResponse> next, 
        CancellationToken cancellationToken)
    {
        // If no validators, just execute request handler
        if (!_validators.Any ())
        {
            return await next();
        }

        Error[] errors = _validators
            // Execute validation
            .Select(validator => validator.Validate(request))
            // Select validation errors
            .SelectMany (validatorResult => validatorResult.Errors)
            .Where(validatorFailure => validatorFailure is not null)
            // Project validation errors
            .Select(failure => new Error(
                code: failure.PropertyName,
                Description: failure.ErrorMessage))
            .Distinct()
            .ToArray ();

        // Return appropriate validation Result
        if (errors.Any())
        {
            return CreateValidationResult<TResponse> (errors);
        }

        // Otherwise, just execute request handler
        return await next();
    }

    private static TResult CreateValidationResult<TResult> (Error[] errors)
        where TResult : class
    {
        if(typeof(TResult) == typeof(Result))
        {
            return (ValidationResult.WithErrors(errors) as TResult)!;
        }

        object validationResult = typeof(ValidationResult<>)
            .GetGenericTypeDefinition()
            .MakeGenericType(typeof(TResult).GenericTypeArguments[0])
            .GetMethod(nameof (ValidationResult.WithErrors))!
            .Invoke(null, new object?[] { errors })!;

        return (TResult) validationResult;
    }
}
