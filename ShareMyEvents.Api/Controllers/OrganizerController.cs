using Microsoft.AspNetCore.Mvc;
using ShareMyEvents.Domain.Dtos.Responses.Organizer;

namespace ShareMyEvents.Api.Controllers;

[Route("organizer")]
[ApiController]
public class OrganizerController: Controller
{
    [HttpGet()]
    [Route("next-event")]
    public ActionResult<OrganizerNextEventSummaryResponse> GetNextEvent ()
    {
        return StatusCode(StatusCodes.Status200OK);
    }
}
