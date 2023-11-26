using Microsoft.AspNetCore.Mvc;
using ShareMyEvents.Domain.Dtos.Resquests.ParticipationRequests;

namespace ShareMyEvents.Api.Controllers;

[Route("participations")]
[ApiController]
public class ParticipationController: ControllerBase
{
    [HttpGet("{eventId}")]
    public ActionResult<IEnumerable<Actor>> GetAll (int eventId)
    {
        return StatusCode(StatusCodes.Status200OK);
    }

    [HttpPost]
    [Route("new")]
    public IActionResult New ([FromBody] ParticipationCreateDto request)
    {
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPatch]
    [Route("availability/{participationId}")]
    public IActionResult UpdateAvailability (int participationId, [FromBody] ParticipationUpdateAvailabilityDto request)
    {
        return StatusCode(StatusCodes.Status200OK);
    }

    [HttpDelete("{participationId}")]
    public IActionResult Delete (int participationId, [FromBody] ParticipationDeleteDto request)
    {
        return StatusCode(StatusCodes.Status200OK);
    }
}
