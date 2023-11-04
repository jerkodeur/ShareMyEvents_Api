using Jerkoder.Common.Domain.CQRS.Interfaces;
using ShareMyEvents.Domain.Dtos.Resquests.EventRequests;

namespace ShareMyEvents.Api.Requests;

internal class EventCreateRequest: IRequest<Event>
{
    public EventCreateDto Dto { get; }

    public EventCreateRequest (EventCreateDto eventCreateDto)
    {
        Dto = eventCreateDto;
    }
}
