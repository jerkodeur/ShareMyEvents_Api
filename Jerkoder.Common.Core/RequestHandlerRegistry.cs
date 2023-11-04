namespace Jerkoder.Common.Core;
internal class RequestHandlerRegistry
{
    private readonly IDictionary<Type, object> _handlers = new Dictionary<Type, object>();

    public void AddHandler(Type request, object handler)
    {
        _handlers.TryGetValue(request, out var value);

        if(value is not null) return;

        _handlers.Add(request, handler);
    }

    public object? GetHandlerType(Type requestType)
    {
        return _handlers.TryGetValue(requestType, out var value) ? value : null;
    }

    public object? GetHandlerType<TRequest>() => GetHandlerType(typeof(TRequest));
}
