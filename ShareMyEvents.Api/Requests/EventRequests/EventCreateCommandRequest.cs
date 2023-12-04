using Jerkoder.Common.Domain.CQRS.Interfaces;
using ShareMyEvents.Domain.Dtos.Requests.EventRequests;
using ShareMyEvents.Domain.Dtos.Responses.EventResponses;

namespace ShareMyEvents.Api.Requests.EventRequests;

internal class EventCreateCommandRequest : ICommand<EventCreatedResponse>
{
    public EventCreateDto Dto { get; }

    public EventCreateCommandRequest(EventCreateDto dto)
    {
        Dto = dto;
    }
}
