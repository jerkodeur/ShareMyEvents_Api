using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShareMyEvents.Api.Exceptions;
using ShareMyEvents.Domain.Dtos.Responses.UserResponses;
using ShareMyEvents.Domain.Dtos.Resquests.UserRequests;
using ShareMyEvents.Domain.Interfaces;

namespace ShareMyEvent.Api.Controllers;
[Route("users")]
[ApiController]
public class UserController: ControllerBase
{
    private IAuthenticationService _service { get; set; }

    public UserController(IAuthenticationService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpPost]
    [Route("sign-up")]
    public async Task<IActionResult> SignUpAsync ([FromBody] UserSignUpRequest request)
    {
        await Task.CompletedTask;
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPost]
    [Route("login")]
    public async Task<ActionResult<UserLoginResponse>> LogInAsync ([FromBody] UserLoginRequest request)
    {
        try
        {
            var response = await _service.Authenticate(request);

            return Ok(response);
        }
        catch(UnauthorizedException ex)
        {
            return Unauthorized(ex.Message);
        }
        catch(NullReferenceException ex)
        {
            return Problem(ex.Message, "LogInAsync", 500);
        }
    }

    [HttpPatch]
    [Authorize]
    [Route("lost-password")]
    public async Task<IActionResult> LostPasswordAsync ([FromBody] UserLostPasswordRequest request)
    {
        await Task.CompletedTask;
        return StatusCode(StatusCodes.Status202Accepted);
    }


    [HttpPatch]
    [Authorize]
    [Route("reset-password")]
    public async Task<IActionResult> ResetPasswordAsync (UserResetPasswordRequest request)
    {
        await Task.CompletedTask;
        return StatusCode(StatusCodes.Status200OK);
    }
}
