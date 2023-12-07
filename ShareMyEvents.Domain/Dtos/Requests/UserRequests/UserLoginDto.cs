using System.ComponentModel;

namespace ShareMyEvents.Domain.Dtos.Resquests.UserRequests;
public class UserLoginDto
{
    [DefaultValue("mon-Email.mon-domain.fr")]
    public string Email { get; set; } = string.Empty;


    [DefaultValue("monMotDePasse")]
    public string Password { get; set; } = string.Empty;
}
