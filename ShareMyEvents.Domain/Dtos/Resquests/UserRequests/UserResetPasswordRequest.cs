using System.ComponentModel.DataAnnotations;

namespace ShareMyEvents.Domain.Dtos.Resquests.UserRequests;
public class UserResetPasswordRequest
{
    [Required(ErrorMessage = "Ce champ ne peut être null")]
    public required string Email { get; set; }

    [Required(ErrorMessage = "Ce champ ne peut être null")]
    public required string OldPassWord { get; set; }

    [Required(ErrorMessage = "Ce champ ne peut être null")]
    public required string NewPassWord { get; set; }
}
