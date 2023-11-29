using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Jerkoder.Common.Domain.CQRS.Interfaces;

namespace ShareMyEvents.Domain.Dtos.Resquests.UserRequests;
public class UserLoginQuery : IQuery<string>
{
    [DefaultValue("mon-Email.mon-domain.fr")]
    [Required(ErrorMessage = "Ce champ ne peut être null")]
    public required string Email { get; set; }


    [DefaultValue("monMotDePasse")]
    [Required(ErrorMessage = "Ce champ ne peut être null")]
    public required string Password { get; set; }
}
