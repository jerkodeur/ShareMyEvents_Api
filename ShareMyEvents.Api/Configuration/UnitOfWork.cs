using ShareMyEvents.Api.Database;
using ShareMyEvents.Api.Database.Repositories;
using ShareMyEvents.Domain.Interfaces.Repositories;

namespace ShareMyEvents.Domain.Interfaces;
public interface IUnitOfWork : IDisposable
{
    IEventRepository EventRepo { get; }
    IUserRepository UserRepo { get; }
    IActorRepository ActorRepo { get; }
    IAvailabilityRepository AvailabilityRepo { get; }
    IAddressRepository AddressRepo { get; }
    Task SaveChangesAsync (CancellationToken cancellationToken);
}

internal sealed class UnitOfWork: IUnitOfWork
{
    private readonly ShareMyEventsApiContext _context;

    public UnitOfWork(ShareMyEventsApiContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));

        EventRepo = new EventRepository(_context);
        UserRepo = new UserRepository(_context);
        ActorRepo = new ActorRepository(_context);
        AvailabilityRepo = new AvailabilityRepository(_context);
        AddressRepo = new AddressRepository(_context);
    }

    public IEventRepository EventRepo { get; private set; }
    public IUserRepository UserRepo { get; private set; }
    public IActorRepository ActorRepo { get; private set; }
    public IAvailabilityRepository AvailabilityRepo { get; private set; }
    public IAddressRepository AddressRepo { get; private set; }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
