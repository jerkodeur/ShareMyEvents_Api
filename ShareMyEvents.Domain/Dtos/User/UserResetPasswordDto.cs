namespace ShareMyEvent.Domain.Dtos.User;
public class UserResetPasswordDto
{
    public string Email { get; set; } = string.Empty;
    public string OldPassWord { get; set; } = string.Empty;
    public string NewPassWord { get; set; } = string.Empty;
}
