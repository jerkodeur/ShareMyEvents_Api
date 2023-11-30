using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ShareMyEvents.Domain.Dtos.Resquests.UserRequests;
public class UserLoginDto
{
    [DefaultValue("mon-Email.mon-domain.fr")]
    [Required(ErrorMessage = "Ce champ ne peut être null")]
    public required string Email { get; set; }


    [DefaultValue("monMotDePasse")]
    [Required(ErrorMessage = "Ce champ ne peut être null")]
    public required string Password { get; set; }
}
