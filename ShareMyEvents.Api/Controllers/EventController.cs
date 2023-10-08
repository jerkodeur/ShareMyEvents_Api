using Microsoft.AspNetCore.Mvc;
using ShareMyEvents.Domain.Dtos.Responses.EventResponses;
using ShareMyEvents.Domain.Dtos.Resquests.EventRequests;
using ShareMyEvents.Domain.Models;

namespace ShareMyEvent.Api.Controllers;
[Route("events")]
[ApiController]
public class EventController: ControllerBase
{
    [HttpGet("{id}")]
    public ActionResult<EventPageResponse> GetEvent (int id)
    {
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPost]
    [Route("new")]
    public ActionResult<Event> New ([FromBody] EventCreateRequest request)
    {
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPatch]
    [Route("update/{id}/title")]
    public IActionResult UpdateTitle (int id, [FromBody] EventUpdateTitleRequest request)
    {
        return StatusCode(StatusCodes.Status200OK);
    }

    [HttpPatch]
    [Route("update/{id}/description")]
    public IActionResult UpdateDescription (int id, [FromBody] EventUpdateDescriptionRequest request)
    {
        return StatusCode(StatusCodes.Status200OK);
    }

    [HttpPatch]
    [Route("update/{id}/date")]
    public IActionResult UpdateDate (int id, [FromBody] EventUpdateDateRequest request)
    {
        return StatusCode(StatusCodes.Status200OK);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete (int id, [FromBody] EventDeleteRequest request)
    {
        return StatusCode(StatusCodes.Status200OK);
    }
}
