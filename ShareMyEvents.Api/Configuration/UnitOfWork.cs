using ShareMyEvents.Api.Database;
using ShareMyEvents.Api.Database.Repositories;
using ShareMyEvents.Domain.Interfaces.Repositories;

namespace ShareMyEvents.Domain.Interfaces;
public interface IUnitOfWork : IDisposable
{
    IEventRepository EventRepository { get; }
    IUserRepository UserRepository { get; }
    IActorRepository ActorRepository { get; }
    IAvailabilityRepository AvailabilityRepository { get; }
    IAddressRepository AddressRepository { get; }
    Task SaveChangesAsync (CancellationToken cancellationToken);
}

internal sealed class UnitOfWork: IUnitOfWork
{
    private readonly ShareMyEventsApiContext _context;

    public UnitOfWork(ShareMyEventsApiContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));

        EventRepository = new EventRepository(_context);
        UserRepository = new UserRepository(_context);
        ActorRepository = new ActorRepository(_context);
        AvailabilityRepository = new AvailabilityRepository(_context);
        AddressRepository = new AddressRepository(_context);
    }

    public IEventRepository EventRepository { get; private set; }
    public IUserRepository UserRepository { get; private set; }
    public IActorRepository ActorRepository { get; private set; }
    public IAvailabilityRepository AvailabilityRepository { get; private set; }
    public IAddressRepository AddressRepository { get; private set; }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
