using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShareMyEvents.Api.Requests.UserRequests;
using ShareMyEvents.Domain.Dtos.Resquests.UserRequests;

namespace ShareMyEvents.Api.Controllers;
[Route("users")]
[ApiController]
public class UserController: ApiController
{
    public UserController (IMediator mediator, CancellationTokenSource cancellationToken) : base(mediator, cancellationToken)
    {
    }

    [HttpPost]
    [Route("sign-up")]
    public async Task<IActionResult> SignUpAsync ([FromBody] UserSignUpDto request)
    {
        await Task.CompletedTask;
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> LogInAsync ([FromBody] UserLoginDto request)
    {

        var result = await _sender.Send(new UserLogInQuery(request), _cancellationToken);
       
        if (result.IsFailed)
        {
            return HandleFailure(result);
        }

         return Ok(result.Response);
    }

    [HttpPatch]
    [Authorize]
    [Route("lost-Password")]
    public async Task<IActionResult> LostPasswordAsync ([FromBody] Domain.Dtos.Resquests.UserRequests.UserLostPasswordDto request)
    {
        await Task.CompletedTask;
        return StatusCode(StatusCodes.Status202Accepted);
    }


    [HttpPatch]
    [Authorize]
    [Route("reset-Password")]
    public async Task<IActionResult> ResetPasswordAsync (UserResetPasswordDto request)
    {
        await Task.CompletedTask;
        return StatusCode(StatusCodes.Status200OK);
    }
}
