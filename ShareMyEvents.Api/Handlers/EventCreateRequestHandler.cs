using Jerkoder.Common.Domain.CQRS.Interfaces;
using ShareMyEvents.Api.Data;
using ShareMyEvents.Api.Requests;

namespace ShareMyEvents.Api.Handlers;

internal class EventCreateRequestHandler: IRequestHandler<EventCreateRequest, Event>
{
    private readonly ShareMyEventsApiContext _context;

    public EventCreateRequestHandler(ShareMyEventsApiContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));

        if(context.Events == null)
        {
            throw new NullReferenceException($"Internal error: null reference exception: {typeof(DbSet<Event>)}");
        }
    }

    public async Task<Event> HandleAsync (EventCreateRequest request, CancellationToken cancellationToken)
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
            Title = request.Dto.Title,
            Description = request.Dto.Description,
            EventDate = request.Dto.EventDate,
            Address = request.Dto.Address,
            OrganizerId = organizer.Id,
            Organizer = organizer,
            Code = new Code(Guid.NewGuid()), /* To change */
        };

        //_context.Events.Add(newEvent);

        //await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        await Task.CompletedTask.ConfigureAwait (false);

        return newEvent;
    }
}
