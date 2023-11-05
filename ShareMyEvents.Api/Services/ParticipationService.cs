using ShareMyEvents.Api.Database;
using ShareMyEvents.Domain.Interfaces;

namespace ShareMyEvents.Api.Services;

public class ParticipationService: IParticipationService
{
    private readonly ShareMyEventsApiContext _context;

    public ParticipationService (ShareMyEventsApiContext context)
    {
        _context = context ?? throw new NullReferenceException($"Internal error: null reference exception: {typeof(ShareMyEventsApiContext)}");

        if(context.Participations == null)
        {
            throw new NullReferenceException($"Internal error: null reference exception: {typeof(DbSet<Participation>)}");
        }
    }

    public Task<bool> CreateAsync (CancellationToken token) => throw new NotImplementedException();
    public Task<bool> DeleteAsync (int id, CancellationToken token) => throw new NotImplementedException();
    public Task<Participation> GetByIdAsync (int id, CancellationToken token) => throw new NotImplementedException();
    public Task<List<int>> GetParticipationsByEventIdAsync (int id, CancellationToken token) => throw new NotImplementedException();
}
