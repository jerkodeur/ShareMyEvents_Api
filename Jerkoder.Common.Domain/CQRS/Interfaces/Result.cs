using Jerkoder.Common.Domain.Exceptions;

namespace Jerkoder.Common.Domain.CQRS.Interfaces;

public abstract class BaseResult
{
    public Error Error { get; protected set;  } = Error.None;
    public Exception? Exception { get; protected set; }

    public bool IsSucceeded { get; protected set;  }
    public bool IsFailed => !IsSucceeded;

    protected BaseResult ()
    {
    }

    protected BaseResult (bool isSuceeded, Error error)
    {
        if(isSuceeded && error != Error.None || !isSuceeded && error == Error.None)
        {
            throw new ArgumentException("Invalid error", nameof(error));
        }

        IsSucceeded = isSuceeded;
        Error = error;
    }

    protected BaseResult (bool isSuceeded, Exception exception)
    {
        if(isSuceeded && exception != null || !isSuceeded && exception == null)
        {
            throw new ArgumentException("Invalid error", nameof(exception));
        }

        IsSucceeded = isSuceeded;
        Exception = exception;
    }
}

public abstract class BaseResult<TResponse>: BaseResult
    where TResponse : class
{
    public TResponse? Response { get; protected set; }

    protected BaseResult (bool isSuceeded, Error error) : base(isSuceeded, error)
    {
    }

    protected BaseResult (bool isSuceeded, Exception exception) : base(isSuceeded, exception)
    {
    }

    protected BaseResult (bool isSuceeded, TResponse response)
    {
        if(isSuceeded && response == null || !isSuceeded)
        {
            throw new ArgumentException("Invalid error", nameof(response));
        }

        IsSucceeded = isSuceeded;
        Response = response;
    }
}

public class Result : BaseResult
{
    protected Result (bool isSuceeded, Error error) : base(isSuceeded, error)
    {
    }

    protected Result (bool isSuceeded, Exception exception) : base(isSuceeded, exception)
    {
    }

    public static Result Success => new(true, Error.None);
    public static Result Failure (Error error) => new(false, error);
    public static Result Failure (Exception exception) => new(false, exception);
}

public class Result<TResponse> : BaseResult<TResponse>
    where TResponse : class
{
    protected Result (bool isSuceeded, Error error) : base(isSuceeded, error)
    {
    }

    protected Result (bool isSuceeded, Exception exception) : base(isSuceeded, exception)
    {
    }

    protected Result (bool isSuceeded, TResponse response) : base(isSuceeded, response)
    {
    }

    public static implicit operator Result<TResponse>(TResponse response) => new(true, response);

    public static Result<TResponse> Success(TResponse response) => new(true, response);
    public static Result Failure (Error error) => Result.Failure(error);
    public static Result Failure (Exception exception) => Result.Failure(exception);
}

