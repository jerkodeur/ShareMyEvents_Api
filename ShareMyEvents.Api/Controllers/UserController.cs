using Microsoft.AspNetCore.Mvc;
using ShareMyEvent.Domain.Dtos.User;

namespace ShareMyEvent.Api.Controllers;
[Route("users")]
[ApiController]
public class UserController: ControllerBase
{
    [HttpPost]
    [Route("sign-up")]
    public IActionResult SignUp ([FromBody] UserSignUpDto request)
    {
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPost]
    [Route("login")]
    public IActionResult LogIn ([FromBody] UserLogInDto request)
    {
        return StatusCode(StatusCodes.Status200OK);
    }

    [HttpPatch]
    [Route("lost-password")]
    public IActionResult LostPassword ([FromBody] UserLostPasswordDto request)
    {
        return StatusCode(StatusCodes.Status202Accepted);
    }


    [HttpPatch]
    [Route("reset-password")]
    public IActionResult ResetPassword (UserResetPasswordDto request)
    {
        return StatusCode(StatusCodes.Status200OK);
    }
}
