using Jerkoder.Common.Domain.CQRS.Interfaces;
using Jerkoder.Common.Domain.Exceptions;
using Jerkoder.Common.Domain.Validation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ShareMyEvents.Api.Controllers;

public abstract class ApiController : ControllerBase
{
    protected readonly ISender _sender;
    protected readonly CancellationToken _cancellationToken;

    public ApiController (ISender sender, CancellationTokenSource cancellationToken)
    {
        _sender = sender ?? throw new ArgumentNullException(nameof(sender));

        if(cancellationToken is null)
        {
            throw new ArgumentNullException(nameof(cancellationToken));
        }

        _cancellationToken = cancellationToken.Token;
    }

    protected IActionResult HandleFailure (BaseResult result)
    {
        return result switch
        {
            null => throw new NullReferenceException(nameof(BaseResult)),
            { IsSucceeded: true } => throw new InvalidOperationException(),
            IValidationResult validationResult => HandleValidationFailure(result, validationResult),
            _ => BadRequest(
                CreateProblemDetails(
                    "Bad Request",
                    StatusCodes.Status400BadRequest,
                    result.Error)
                )
        };
    }

    private IActionResult HandleValidationFailure (BaseResult result, IValidationResult validationResult)
    {
        var problem = CreateProblemDetails(
            "Bad Request",
            StatusCodes.Status400BadRequest,
            result.Error,
            validationResult.Errors
        );

        return BadRequest( problem );
    }

    private static ProblemDetails CreateProblemDetails (
        string title,
        int status,
        Error error,
        Error[]? errors = null) =>
        new()
        {
            Title = title,
            Status = status,
            Detail = error.Description,
            Extensions = { { nameof(errors), errors } }
        };
}
