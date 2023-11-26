using Jerkoder.Common.Domain.CQRS.Interfaces.Mediator;

namespace Jerkoder.Common.Domain.CQRS.Interfaces;
public interface IQuery<TResponse> : IRequest<Result<TResponse>> 
    where TResponse : class
{
}

public interface IQueryHandler<TQuery, TResponse>
    : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
    where TResponse : class
{
    new Task<Result<TResponse>> HandleAsync(TQuery query, CancellationToken cancellationToken);
}