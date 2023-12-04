using MediatR;

namespace Jerkoder.Common.Domain.CQRS.Interfaces;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    where TResponse : class
{
}
