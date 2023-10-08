using System.ComponentModel.DataAnnotations;

namespace ShareMyEvents.Domain.Dtos.Resquests.UserRequests;
public class UserResetPasswordRequest
{
    [Required(ErrorMessage = "Ce champ ne peut être null")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Ce champ ne peut être null")]
    public string OldPassWord { get; set; } = string.Empty;

    [Required(ErrorMessage = "Ce champ ne peut être null")]
    public string NewPassWord { get; set; } = string.Empty;
}
