using ShareMyEvents.Domain.Entities;

namespace ShareMyEvents.Domain.Models;

public class Actor: AbstractEntity
{
    public Actor (string nickname, string email, string password)
    {
        Nickname = nickname;
        Email = email;
    }

    public string Nickname { get; set; }
    public string Email { get; set; }

    public long? userId { get; set; }
    public User? User { get; set; }
}
