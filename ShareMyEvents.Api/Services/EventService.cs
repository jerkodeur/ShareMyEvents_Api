using ShareMyEvents.Api.Data;
using ShareMyEvents.Api.Exceptions;
using ShareMyEvents.Domain.Dtos.Responses.EventResponses;
using ShareMyEvents.Domain.Dtos.Resquests.EventRequests;
using ShareMyEvents.Domain.Interfaces;
using ShareMyEvents.Domain.Models;

namespace ShareMyEvents.Api.Services;

public class EventService: IEventService
{
    private readonly ShareMyEventsApiContext _context;
    private readonly ParticipationService _participationService;

    public EventService (ShareMyEventsApiContext context, ParticipationService participationService)
    {
        _context = context ?? throw new NullReferenceException($"Internal error: null reference exception: {typeof(ShareMyEventsApiContext)}");
        _participationService = participationService ?? throw new NullReferenceException($"Internal error: null reference exception: {typeof(ParticipationService)}");

        if(context.Events == null)
        {
            throw new NullReferenceException("Internal error: null reference exception");
        }
    }

    public async Task<EventPageResponse> GetByIdAsync (int id)
    {
        var @event = await GetOneById(id);

        var participants = await _participationService.GetParticipationsByEventId(@event.Id);

        var response = new EventPageResponse()
        {
            Event = @event,
            Organizer = @event.Organizer,
            Participants = participants
        };

        return response;
    }

    public async Task<EventCreatedResponse> CreateAsync (EventCreateRequest request)
    {
        var newEvent = new Event()
        {
            Title = request.Title,
            Description = request.Description,
            EventDate = request.EventDate,
            Address = request.Address,
            Code = Guid.NewGuid().ToString(), /* To change */
            //Organizer = // To implement,
        };

        _context.Events.Add(newEvent);

        await _context.SaveChangesAsync();

        var response = new EventCreatedResponse()
        {
            EventId = newEvent.Id
        };

        return response;

    }

    public async Task<EventUpdateDateResponse> UpdateDateResponseAsync (int id, EventUpdateDateRequest request)
    {
        var @event = await GetOneById(id);

        @event.EventDate = request.EventDate;

        await _context.SaveChangesAsync();

        var response = new EventUpdateDateResponse()
        {
            EventId = @event.Id,
            Date = @event.EventDate
        };

        return response;
    }
    
    public async Task<EventUpdateDescriptionResponse> UpdateDescriptionResponseAsync (int id, EventUpdateDescriptionRequest request)
    {
        var @event = await GetOneById(id);

        @event.Description = request.Description;

        await _context.SaveChangesAsync();

        var response = new EventUpdateDescriptionResponse()
        {
            EventId = @event.Id,
            Description = @event.Title
        };

        return response;
    }

    public async Task<EventUpdateTitleResponse> UpdateTitleResponseAsync (int id, EventUpdateTitleRequest request)
    {
        var @event = await GetOneById(id);

        @event.Title = request.Title;

        await _context.SaveChangesAsync();

        var response = new EventUpdateTitleResponse()
        {
            EventId = @event.Id,
            Title = @event.Title
        };

        return response;
    }

    public async Task DeleteAsync (int id)
    {
        var @event = await GetOneById(id);

        _context.Remove(@event);
        await _context.SaveChangesAsync();
    }

    #region Private Methods
    private async Task<Event> GetOneById(int eventId)
    {
        var @event = await _context.Events.FindAsync(eventId);

        if(@event == null)
            throw new NotFoundException();

        return @event;
    }
    #endregion
}
