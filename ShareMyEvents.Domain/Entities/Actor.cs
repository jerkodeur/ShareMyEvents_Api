namespace ShareMyEvents.Domain.Models;

public class Actor: AbstractEntity
{
    public Actor (string nickname, string email, string password)
    {
        Nickname = nickname;
        Email = email;
        Password = password;
    }

    public string Nickname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}
