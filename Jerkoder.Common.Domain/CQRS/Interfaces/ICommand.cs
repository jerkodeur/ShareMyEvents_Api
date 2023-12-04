using MediatR;

namespace Jerkoder.Common.Domain.CQRS.Interfaces;

public interface ICommand : IRequest<Result>
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
    where TResponse : class
{
}
