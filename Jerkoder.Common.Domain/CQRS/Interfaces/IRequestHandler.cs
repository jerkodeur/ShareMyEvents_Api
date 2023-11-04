namespace Jerkoder.Common.Domain.CQRS.Interfaces;

public interface IRequestHandler<in TRequest>
    where TRequest : IRequest
{
    Task HandleAsync (TRequest request, CancellationToken cancellationToken);

}

public interface IRequestHandler<in TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : class
{
    Task<TResponse> HandleAsync (TRequest request, CancellationToken cancellationToken);
}

