using Jerkoder.Common.Domain.CQRS;
using Jerkoder.Common.Domain.CQRS.Interfaces;
using Microsoft.EntityFrameworkCore;
using ShareMyEvents.Api.Data;
using ShareMyEvents.Domain.Models;

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
        var newEvent = new Event()
        {
            Id = new Random().Next(0, 100),
            Title = request.Dto.Title,
            Description = request.Dto.Description,
            EventDate = request.Dto.EventDate,
            Address = request.Dto.Address,
            Code = Guid.NewGuid().ToString(), /* To change */
            //Organizer = // To implement,
        };

        //_context.Events.Add(newEvent);

        //await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        await Task.CompletedTask.ConfigureAwait (false);

        return newEvent;
    }
}
