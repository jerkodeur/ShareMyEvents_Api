using Microsoft.AspNetCore.Mvc;
using ShareMyEvents.Domain.Dtos.Resquests.ParticipationRequests;
using ShareMyEvents.Domain.Models;

namespace ShareMyEvent.Api.Controllers;
[Route("participations")]
[ApiController]
public class ParticipantController: ControllerBase
{
    [HttpGet("{eventId}")]
    public ActionResult<IEnumerable<Actor>> GetAll (int eventId)
    {
        return StatusCode(StatusCodes.Status200OK);
    }

    [HttpPost]
    [Route("new")]
    public IActionResult New ([FromBody] ParticipationCreateRequest request)
    {
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPatch]
    [Route("availability/{participationId}")]
    public IActionResult UpdateAvailability (int participationId, [FromBody] ParticipationUpdateAvailabilityRequest request)
    {
        return StatusCode(StatusCodes.Status200OK);
    }

    [HttpDelete("{participationId}")]
    public IActionResult Delete (int participationId, [FromBody] ParticipationDeleteRequest request)
    {
        return StatusCode(StatusCodes.Status200OK);
    }
}
