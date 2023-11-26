using Jerkoder.Common.Domain.Exceptions;

namespace Jerkoder.Common.Domain.CQRS.Interfaces;

public abstract class BaseResult
{
    public bool IsSucceeded { get; protected set;  }
    public bool IsFailed => !IsSucceeded;
    public Error Error { get; protected set;  } = Error.None;
}

public class Result : BaseResult
{

    protected Result (bool isSuceeded, Error error)
    {
        if(isSuceeded && error != Error.None || !isSuceeded && error == Error.None)
        {
            throw new ArgumentException("Invalid error", nameof(error));
        }

        IsSucceeded = isSuceeded;
        Error = error;
    }

    public static Result Success => new(true, Error.None);

    public static Result Failure (Error error) => new(false, error);
}

public class Result<TResponse> : BaseResult
{
    public TResponse Response { get; }

    protected Result (bool isSuceeded, TResponse response)
    {
        Response = response;
        IsSucceeded = isSuceeded;
    }

    public static Result<TResponse> Success(TResponse response) => new(true, response);
    public static Result Failure (Error error) => Result.Failure(error);
}

