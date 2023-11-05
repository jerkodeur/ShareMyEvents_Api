using Jerkoder.Common.Domain.CQRS.Interfaces;
using ShareMyEvents.Api.Requests;
using ShareMyEvents.Domain.Interfaces;

namespace ShareMyEvents.Api.Handlers;

internal class EventCreateRequestHandler: IRequestHandler<EventCreateRequest, Event>
{
    private readonly IUnitOfWork _unitOfWork;

    public EventCreateRequestHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
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

        await _unitOfWork.EventRepo.Add(newEvent);
        await _unitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        return newEvent;
    }
}
