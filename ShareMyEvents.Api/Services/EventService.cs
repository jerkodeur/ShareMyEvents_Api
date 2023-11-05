using ShareMyEvents.Api.Database;
using ShareMyEvents.Api.Exceptions;
using ShareMyEvents.Domain.Dtos.Responses.EventResponses;
using ShareMyEvents.Domain.Dtos.Resquests.EventRequests;
using ShareMyEvents.Domain.Interfaces;

namespace ShareMyEvents.Api.Services;

public class EventService: IEventService
{
    private readonly ShareMyEventsApiContext _context;
    private readonly IParticipationService _participationService;

    public EventService (ShareMyEventsApiContext context, IParticipationService participationService)
    {
        _context = context ?? throw new NullReferenceException($"Internal error: null reference exception: {typeof(ShareMyEventsApiContext)}");
        _participationService = participationService ?? throw new NullReferenceException($"Internal error: null reference exception: {typeof(IParticipationService)}");

        if(context.Events == null)
        {
            throw new NullReferenceException($"Internal error: null reference exception: {typeof(DbSet<Event>)}");
        }
    }

    public async Task<EventPageResponse> GetByIdAsync (int id, CancellationToken token = default)
    {
        var @event = await GetOneByIdAsync(id, token);

        var participants = await _participationService.GetParticipationsByEventIdAsync(@event.Id.Value, token);

        var response = new EventPageResponse()
        {
            Event = @event,
            Organizer = @event.Organizer,
            Participants = participants
        };

        return response;
    }

    public async Task<EventCreatedResponse> CreateAsync (EventCreateDto request, CancellationToken token = default)
    {
        var organizer = new Actor()
        {
            Email = "test",
            Nickname = "test",
            Id = new ActorId(10)
        };

        var newEvent = new Event()
        {
            Id = new EventId(new Random().Next(0, 100)),
            Title = request.Title,
            Description = request.Description,
            EventDate = request.EventDate,
            Address = request.Address,
            OrganizerId = organizer.Id,
            Organizer = organizer,
            Code = new Code(Guid.NewGuid())/* To change */
        };

        _context.Events.Add(newEvent);

        await _context.SaveChangesAsync(token);

        var response = new EventCreatedResponse()
        {
            EventId = newEvent.Id.Value
        };

        return response;

    }

    public async Task<EventUpdateDateResponse> UpdateDateResponseAsync (int id, EventUpdateDateDto request, CancellationToken token = default)
    {
        var @event = await GetOneByIdAsync(id, token);

        @event.EventDate = request.EventDate;

        await _context.SaveChangesAsync(token);

        var response = new EventUpdateDateResponse()
        {
            EventId = @event.Id.Value,
            Date = @event.EventDate
        };

        return response;
    }
    
    public async Task<EventUpdateDescriptionResponse> UpdateDescriptionResponseAsync (int id, EventUpdateDescriptionDto request, CancellationToken token = default)
    {
        var @event = await GetOneByIdAsync(id, token);

        @event.Description = request.Description;

        await _context.SaveChangesAsync(token);

        var response = new EventUpdateDescriptionResponse()
        {   
            EventId = @event.Id.Value,
            Description = @event.Title
        };

        return response;
    }

    public async Task<EventUpdateTitleResponse> UpdateTitleResponseAsync (int id, EventUpdateTitleDto request, CancellationToken token = default)
    {
        var @event = await GetOneByIdAsync(id, token);

        @event.Title = request.Title;

        await _context.SaveChangesAsync(token);

        var response = new EventUpdateTitleResponse()
        {
            EventId = @event.Id.Value,
            Title = @event.Title
        };

        return response;
    }

    public async Task DeleteAsync (int id, CancellationToken token = default)
    {
        var @event = await GetOneByIdAsync(id, token);

        _context.Remove(@event);
        await _context.SaveChangesAsync(token);
    }

    #region Private Methods
    private async Task<Event> GetOneByIdAsync(int eventId, CancellationToken token)
    {
        var @event = await _context.Events.FindAsync(eventId, token);

        if(@event == null)
            throw new NotFoundException(nameof(Event));

        return @event;
    }
    #endregion
}
