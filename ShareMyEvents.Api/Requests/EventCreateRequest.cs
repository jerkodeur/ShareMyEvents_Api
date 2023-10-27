using Jerkoder.Common.Domain.CQRS.Interfaces;
using ShareMyEvents.Domain.Dtos.Resquests.EventRequests;
using ShareMyEvents.Domain.Models;

namespace Jerkoder.Common.Domain.CQRS;

internal class EventCreateRequest : IRequest<Event>
{
    public EventCreateDto Dto { get; }

    public EventCreateRequest(EventCreateDto eventCreateDto)
    {
        Dto = eventCreateDto;
    }
}
