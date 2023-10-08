using Microsoft.AspNetCore.Mvc;
using ShareMyEvents.Domain.Dtos.Resquests.UserRequests;

namespace ShareMyEvent.Api.Controllers;
[Route("users")]
[ApiController]
public class UserController: ControllerBase
{
    [HttpPost]
    [Route("sign-up")]
    public IActionResult SignUp ([FromBody] UserSignUpRequest request)
    {
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPost]
    [Route("login")]
    public IActionResult LogIn ([FromBody] UserLogInRequest request)
    {
        return StatusCode(StatusCodes.Status200OK);
    }

    [HttpPatch]
    [Route("lost-password")]
    public IActionResult LostPassword ([FromBody] UserLostPasswordRequest request)
    {
        return StatusCode(StatusCodes.Status202Accepted);
    }


    [HttpPatch]
    [Route("reset-password")]
    public IActionResult ResetPassword (UserResetPasswordRequest request)
    {
        return StatusCode(StatusCodes.Status200OK);
    }
}
