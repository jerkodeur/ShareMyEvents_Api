using Jerkoder.Common.Domain.CQRS.Interfaces.Mediator;
using Microsoft.Extensions.DependencyInjection;

namespace Jerkoder.Common.Core.CQRS;

internal class Mediator: IMediator
{
    private readonly RequestHandlerRegistry _handlerRegistry;
    private readonly IServiceProvider _serviceProvider;

    public Mediator(RequestHandlerRegistry handlerRegistry, IServiceProvider serviceProvider)
    {
        _handlerRegistry = handlerRegistry;
        _serviceProvider = serviceProvider;
    }

    public async Task SendAsync<TRequest> (TRequest request, CancellationToken cancellationToken = default) where TRequest : IRequest
    {
        var handlerType = (Type) _handlerRegistry.GetHandlerType<TRequest>()! ?? throw new Exception();
        var handler = (IRequestHandler<TRequest>) _serviceProvider.GetRequiredService(handlerType);

        await handler.HandleAsync(request, cancellationToken);
    }

    async Task<TResponse> ISender.SendAsync<TResponse> (IRequest<TResponse> request, CancellationToken cancellationToken)
    {
        var handlerType = (Type) _handlerRegistry.GetHandlerType(request.GetType())! ?? throw new Exception();
        var handler = _serviceProvider.GetRequiredService(handlerType);

        // Get Method by reflection
        var handleAsyncMethod = handler.GetType().GetMethod(nameof(IRequestHandler<IRequest>.HandleAsync) ?? throw new Exception());

        // Invoke call the method HandleAsync
        var response = await (Task<TResponse>) handleAsyncMethod!.Invoke(handler, new object[] { request, cancellationToken})!;

        return response;
    }
}
