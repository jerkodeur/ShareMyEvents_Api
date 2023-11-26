using Jerkoder.Common.Domain.CQRS.Interfaces;
using ShareMyEvents.Api.Requests.EventRequests;
using ShareMyEvents.Domain.Interfaces;

namespace ShareMyEvents.Api.Handlers.EventHandlers;

internal sealed class EventCreateCommandHandler : ICommandHandler<EventCreateCommandRequest, Event>
{
    private readonly IUnitOfWork _unitOfWork;

    public EventCreateCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<Result<Event>> HandleAsync(EventCreateCommandRequest request, CancellationToken cancellationToken)
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
            Title = request.Command.Title,
            Description = request.Command.Description,
            EventDate = request.Command.EventDate,
            Address = request.Command.Address,
            OrganizerId = organizer.Id,
            Organizer = organizer,
            Code = new Code(Guid.NewGuid()), /* To change */
        };

        await _unitOfWork.EventRepo.Add(newEvent);
        await _unitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        return Result<Event>.Success(newEvent);
    }
}
