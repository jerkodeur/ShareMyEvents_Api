using MediatR;

namespace Jerkoder.Common.Domain.CQRS.Interfaces;

public interface IQuery : IRequest
{
}

public interface IQuery<TResponse> : IRequest<TResponse>
{
}
