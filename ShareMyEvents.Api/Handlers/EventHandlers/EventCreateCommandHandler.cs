using Jerkoder.Common.Domain.CQRS.Interfaces;
using ShareMyEvents.Api.Requests.EventRequests;
using ShareMyEvents.Domain.Dtos.Responses.EventResponses;
using ShareMyEvents.Domain.Interfaces;

namespace ShareMyEvents.Api.Handlers.EventHandlers;

internal sealed class EventCreateCommandHandler : ICommandHandler<EventCreateCommand, EventCreatedResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public EventCreateCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<Result<EventCreatedResponse>> Handle(EventCreateCommand request, CancellationToken cancellationToken)
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

        await _unitOfWork.EventRepository.Add(newEvent);
        await _unitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        return new EventCreatedResponse() { EventId = newEvent.Id.Value };
    }
}
