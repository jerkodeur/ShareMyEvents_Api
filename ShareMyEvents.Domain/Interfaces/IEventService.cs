using ShareMyEvents.Domain.Dtos.Requests.EventRequests;
using ShareMyEvents.Domain.Dtos.Responses.EventResponses;

namespace ShareMyEvents.Domain.Interfaces;
public interface IEventService
{
    public Task<EventCreatedResponse> CreateAsync (EventCreateDto eventCreateDto, CancellationToken token);
    public Task<EventPageResponse> GetByIdAsync (int id, CancellationToken token);
    public Task<EventUpdateTitleResponse> UpdateTitleResponseAsync (int id, EventUpdateTitleDto eventUpdateTitleDto, CancellationToken token);
    public Task<EventUpdateDescriptionResponse> UpdateDescriptionResponseAsync (int id, EventUpdateDescriptionDto eventUpdateDescriptionDto, CancellationToken token);
    public Task<EventUpdateDateResponse> UpdateDateResponseAsync (int id, EventUpdateDateDto eventUpdateDateDto, CancellationToken token);
    public Task DeleteAsync (int id, CancellationToken token);
}
