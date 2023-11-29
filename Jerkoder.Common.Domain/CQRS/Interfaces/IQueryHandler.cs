using MediatR;

namespace Jerkoder.Common.Domain.CQRS.Interfaces;

public interface IQueryHandler<TQuery, TResponse>
    : IRequestHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse>
{
}
