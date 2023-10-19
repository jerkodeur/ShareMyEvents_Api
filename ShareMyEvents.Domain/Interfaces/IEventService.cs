using ShareMyEvents.Domain.Dtos.Responses.EventResponses;
using ShareMyEvents.Domain.Dtos.Resquests.EventRequests;

namespace ShareMyEvents.Domain.Interfaces;
public interface IEventService
{
    public Task<EventCreatedResponse> CreateAsync (EventCreateRequest request);
    public Task<EventPageResponse> GetByIdAsync (int id);
    public Task<EventUpdateTitleResponse> UpdateTitleResponseAsync (int id, EventUpdateTitleRequest request);
    public Task<EventUpdateDescriptionResponse> UpdateDescriptionResponseAsync (int id, EventUpdateDescriptionRequest request);
    public Task<EventUpdateDateResponse> UpdateDateResponseAsync (int id, EventUpdateDateRequest request);
    public Task DeleteAsync (int id);
}
