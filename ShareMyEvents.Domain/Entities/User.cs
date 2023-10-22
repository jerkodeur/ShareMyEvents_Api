using ShareMyEvents.Domain.Models;

namespace ShareMyEvents.Domain.Entities;
public class User : AbstractEntity
{
    public required string Email { get; set; }
    public required string Password { get; set; }
}
