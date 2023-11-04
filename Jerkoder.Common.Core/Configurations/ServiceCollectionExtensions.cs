using System.Reflection;
using Jerkoder.Common.Core.CQRS;
using Jerkoder.Common.Domain.CQRS.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Jerkoder.Common.Core.Configurations;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Register a mediator for the given assembly
    /// </summary>
    public static IServiceCollection AddMediator(this IServiceCollection services, Assembly assembly)
    {
        services.AddTransient<IMediator, Mediator>();

        // Use the Service which have been already instancied (IMediator)
        services.AddTransient<ISender>(serviceProvider => serviceProvider.GetRequiredService<IMediator>());

        services.RegisterHandlers(assembly);

        return services;
    }

    /// <summary>
    /// Register all Handlers of type IRequestHandler of the given assembly
    /// </summary>
    private static IServiceCollection RegisterHandlers(this IServiceCollection services, Assembly assembly)
    {
        var handlerTypes = assembly.GetTypes()
            .Where(t => _isHandlerType(t))
            .ToList();

        foreach (var handlerType in handlerTypes)
        {
            services.AddTransient(handlerType);
        }

        // Map Request types with handlers
        services.AddSingleton(provider =>
        {
            var registry = new RequestHandlerRegistry();
            var handlerServices = services.Select(s => s.ServiceType).Where(t => _isHandlerType(t)).ToList();

            foreach(var handler in handlerServices)
            {
                var requestType = handler.GetInterfaces().First().GetGenericArguments().First();

                registry.AddHandler(requestType, handler);
            }

            return registry;
        });

        return services;
    }

    private readonly static Func<Type, bool> _isHandlerType = (type) => type.GetInterfaces().Any(i => i.IsGenericType &&
            (i.GetGenericTypeDefinition() == typeof(IRequestHandler<>) || i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>)));
}
