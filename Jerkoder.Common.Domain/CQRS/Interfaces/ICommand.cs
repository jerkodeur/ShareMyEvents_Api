using Jerkoder.Common.Domain.CQRS.Interfaces.Mediator;

namespace Jerkoder.Common.Domain.CQRS.Interfaces;

public interface ICommand : IRequest<Result>
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}
