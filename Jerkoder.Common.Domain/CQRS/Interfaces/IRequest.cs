namespace Jerkoder.Common.Domain.CQRS.Interfaces;

public interface IRequest
{
}

public interface IRequest<out TResponse>
    where TResponse : class
{
}
