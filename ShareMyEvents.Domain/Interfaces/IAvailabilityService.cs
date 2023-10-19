namespace ShareMyEvents.Domain.Interfaces;
public interface IAvailabilityService
{
    public Task<bool> Update (int id);
}