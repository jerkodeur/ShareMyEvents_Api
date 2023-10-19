using ShareMyEvents.Api.Data;
using ShareMyEvents.Domain.Interfaces;
using ShareMyEvents.Domain.Models;

namespace ShareMyEvents.Api.Services;

public class ParticipationService: IParticipationService
{
    private readonly ShareMyEventsApiContext _context;

    public ParticipationService (ShareMyEventsApiContext context)
    {
        _context = context ?? throw new NullReferenceException("Internal error: null reference exception");

        if(context.Participations == null)
        {
            throw new NullReferenceException("Internal error: null reference exception");
        }
    }

    public Task<bool> Create () => throw new NotImplementedException();
    public Task<bool> Delete (int id) => throw new NotImplementedException();
    public Task<Participation> GetById (int id) => throw new NotImplementedException();
    public Task<List<int>> GetParticipationsByEventId (int id) => throw new NotImplementedException();
}
