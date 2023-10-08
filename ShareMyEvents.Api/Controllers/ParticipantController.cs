using Microsoft.AspNetCore.Mvc;
using ShareMyEvents.Domain.Dtos.Responses.ParticipantResponses;
using ShareMyEvents.Domain.Dtos.Resquests.ParticipantRequests;
using ShareMyEvents.Domain.Models;

namespace ShareMyEvent.Api.Controllers;
[Route("participants")]
[ApiController]
public class ParticipantController: ControllerBase
{
    [HttpGet("{id}")]
    public ActionResult<Actor> Get (int id)
    {
        return StatusCode(StatusCodes.Status200OK);
    }

    [HttpGet]
    public ActionResult<IEnumerable<Actor>> GetAll ()
    {
        return StatusCode(StatusCodes.Status200OK);
    }

    [HttpPost]
    [Route("access")]
    public ActionResult<ParticipantAccessResponse> New ([FromBody] ParticipantAccessRequest request)
    {
        return StatusCode(StatusCodes.Status201Created);
    }
}
