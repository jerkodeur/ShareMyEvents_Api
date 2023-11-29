using Jerkoder.Common.Domain.CQRS.Interfaces;
using ShareMyEvents.Domain.Dtos.Responses.EventResponses;
using ShareMyEvents.Domain.Dtos.Resquests.EventRequests.Commands;

namespace ShareMyEvents.Api.Requests.EventRequests;

internal class EventCreateCommandRequest : ICommand<Result<EventCreatedResponse>>
{
    public EventCreateCommand Command { get; }

    public EventCreateCommandRequest(EventCreateCommand command)
    {
        Command = command;
    }
}
