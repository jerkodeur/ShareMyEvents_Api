using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShareMyEvents.Api.Requests.UserRequests;
using ShareMyEvents.Domain.Dtos.Resquests.UserRequests;
using ShareMyEvents.Domain.Interfaces;

namespace ShareMyEvents.Api.Controllers;
[Route("users")]
[ApiController]
public class UserController: ControllerBase
{
    private readonly IMediator _mediator;
    private readonly CancellationToken _token;

    private IAuthenticationService _service { get; set; }

    public UserController (IAuthenticationService service, IMediator mediator, CancellationTokenSource cancellationToken)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        if (cancellationToken is null)
        {
            throw new ArgumentNullException(nameof(cancellationToken));
        }

        _token = cancellationToken.Token;
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

        var result = await _mediator.Send(new UserLogInQueryRequest(request), _token);
       
        if (result.IsSucceeded)
        {
            return Ok(result.Response);
        }

        return result.Error.code switch
        {
            "User.NotFound" => NotFound(result.Error),
            _ => BadRequest(result.Error)
        };
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
