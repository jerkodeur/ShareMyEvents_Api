using MediatR;

namespace Jerkoder.Common.Domain.CQRS.Interfaces;

public interface ICommand : IRequest
{
}

public interface ICommand<TResponse> : IRequest<TResponse>
{
}
