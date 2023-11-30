using System.ComponentModel.DataAnnotations;

namespace ShareMyEvents.Domain.Dtos.Resquests.UserRequests;

public class UserSignUpDto
{
    [Required(ErrorMessage = "Ce champ ne peut être null")]
    public required string Email { get; set; }

    [Required(ErrorMessage = "Ce champ ne peut être null")]
    public required string Password { get; set; }

    [Required(ErrorMessage = "Ce champ ne peut être null")]
    public required string Nickname { get; set; }
}
