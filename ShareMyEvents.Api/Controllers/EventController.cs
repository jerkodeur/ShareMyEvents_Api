using Microsoft.AspNetCore.Mvc;
using ShareMyEvents.Domain.Dtos.Responses.EventResponses;
using ShareMyEvents.Domain.Dtos.Responses.ParticipantResponses;
using ShareMyEvents.Domain.Dtos.Resquests.EventRequests;
using ShareMyEvents.Domain.Dtos.Resquests.ParticipantRequests;

namespace ShareMyEvent.Api.Controllers;
[Route("events")]
[ApiController]
public class EventController: ControllerBase
{
    [HttpGet("{eventId}")]
    public ActionResult<EventPageResponse> GetEvent (int eventId)
    {
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPost]
    [Route("new")]
    public IActionResult New ([FromBody] EventCreateRequest request)
    {
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPatch]
    [Route("update/{eventId}/title")]
    public IActionResult UpdateTitle (int eventId, [FromBody] EventUpdateTitleRequest request)
    {
        return StatusCode(StatusCodes.Status200OK);
    }

    [HttpPatch]
    [Route("update/{eventId}/description")]
    public IActionResult UpdateDescription (int eventId, [FromBody] EventUpdateDescriptionRequest request)
    {
        return StatusCode(StatusCodes.Status200OK);
    }

    [HttpPatch]
    [Route("update/{eventId}/date")]
    public IActionResult UpdateDate (int eventId, [FromBody] EventUpdateDateRequest request)
    {
        return StatusCode(StatusCodes.Status200OK);
    }

    [HttpPost]
    [Route("access")]
    public ActionResult<ParticipantAccessResponse> New ([FromBody] ParticipationAccessRequest request)
    {
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpDelete("{eventId}")]
    public IActionResult Delete (int eventId, [FromBody] EventDeleteRequest request)
    {
        return StatusCode(StatusCodes.Status200OK);
    }
}
