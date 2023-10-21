using ShareMyEvents.Domain.Dtos.Responses.EventResponses;
using ShareMyEvents.Domain.Dtos.Resquests.EventRequests;

namespace ShareMyEvents.Domain.Interfaces;
public interface IEventService
{
    public Task<EventCreatedResponse> CreateAsync (EventCreateRequest request, CancellationToken token);
    public Task<EventPageResponse> GetByIdAsync (int id, CancellationToken token);
    public Task<EventUpdateTitleResponse> UpdateTitleResponseAsync (int id, EventUpdateTitleRequest request, CancellationToken token);
    public Task<EventUpdateDescriptionResponse> UpdateDescriptionResponseAsync (int id, EventUpdateDescriptionRequest request, CancellationToken token);
    public Task<EventUpdateDateResponse> UpdateDateResponseAsync (int id, EventUpdateDateRequest request, CancellationToken token);
    public Task DeleteAsync (int id, CancellationToken token);
}
