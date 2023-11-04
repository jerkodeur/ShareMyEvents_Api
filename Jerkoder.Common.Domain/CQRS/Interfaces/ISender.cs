namespace Jerkoder.Common.Domain.CQRS.Interfaces;

public interface ISender
{
    Task SendAsync<TRequest> (TRequest resquest, CancellationToken cancellationToken)
        where TRequest : IRequest;

    Task<TResponse> SendAsync<TResponse> (IRequest<TResponse> request, CancellationToken cancellationToken)
        where TResponse : class;
}
