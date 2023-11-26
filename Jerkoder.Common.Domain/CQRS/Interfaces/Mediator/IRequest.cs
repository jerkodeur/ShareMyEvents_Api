namespace Jerkoder.Common.Domain.CQRS.Interfaces.Mediator;

public interface IBaseRequest { }

public interface IRequest : IBaseRequest { }

public interface IRequest<out TResponse> : IBaseRequest { }
