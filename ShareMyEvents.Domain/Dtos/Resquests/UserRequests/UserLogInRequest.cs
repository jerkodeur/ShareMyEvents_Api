using System.ComponentModel.DataAnnotations;

namespace ShareMyEvents.Domain.Dtos.Resquests.UserRequests;
public class UserLogInRequest
{
    [Required(ErrorMessage = "Ce champ ne peut être null")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Ce champ ne peut être null")]
    public string password { get; set; } = string.Empty;
}
