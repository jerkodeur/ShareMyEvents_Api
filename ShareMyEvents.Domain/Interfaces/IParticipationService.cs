using ShareMyEvents.Domain.Models;

namespace ShareMyEvents.Domain.Interfaces;
public interface IParticipationService
{
    public Task<List<int>> GetParticipationsByEventId (int id);
    public Task<Participation> GetById (int id);
    public Task<bool> Create ();
    public Task<bool> Delete (int id);
}
