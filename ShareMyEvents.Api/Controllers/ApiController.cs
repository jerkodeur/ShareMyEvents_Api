using Jerkoder.Common.Domain.CQRS.Interfaces;
using Jerkoder.Common.Domain.Exceptions;
using Jerkoder.Common.Domain.Validation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShareMyEvents.Api.Exceptions;

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
        if(result is null)
        {
            throw new NullReferenceException(nameof(BaseResult));
        }

        if(result.IsSucceeded)
        {
            throw new InvalidOperationException();
        }

        return result.Error.code switch
        {
            string x when x.Contains(BaseError.NotFoundCode) => NotFound(
                CreateProblemDetails(
                    result.Error.Description!,
                    StatusCodes.Status404NotFound,
                    result.Error)),
            ValidationResult.CODE => HandleValidationFailure(result),
            _ => BadRequest(
                CreateProblemDetails(
                    "Bad Request",
                    StatusCodes.Status400BadRequest,
                    result.Error)
                )
        };;
    }

    private IActionResult HandleValidationFailure (BaseResult result)
    {
        var problem = CreateProblemDetails(
            "Bad Request",
            StatusCodes.Status400BadRequest,
            result.Error
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
