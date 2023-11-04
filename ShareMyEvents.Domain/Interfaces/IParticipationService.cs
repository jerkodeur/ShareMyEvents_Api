using ShareMyEvents.Domain.Entities;

namespace ShareMyEvents.Domain.Interfaces;
public interface IParticipationService
{
    public Task<List<int>> GetParticipationsByEventIdAsync (int id, CancellationToken token);
    public Task<Participation> GetByIdAsync (int id, CancellationToken token);
    public Task<bool> CreateAsync (CancellationToken token);
    public Task<bool> DeleteAsync (int id, CancellationToken token);
}
