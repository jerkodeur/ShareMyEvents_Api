using Jerkoder.Common.Domain.CQRS.Interfaces;
using ShareMyEvents.Domain.Dtos.Requests.EventRequests;
using ShareMyEvents.Domain.Dtos.Responses.EventResponses;

namespace ShareMyEvents.Api.Requests.EventRequests;

internal class EventCreateCommand : ICommand<EventCreatedResponse>
{
    public string Title { get; }
    public string Description { get; }
    public DateTime EventDate { get; }
    public Address? Address { get; }

    public EventCreateCommand(EventCreateDto dto)
    {
        Title = dto.Title;
        Description = dto.Description;
        EventDate = dto.Date;
        Address = dto.Address;
    }
}
