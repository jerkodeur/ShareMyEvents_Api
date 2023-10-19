using System.Web.Http.Description;
using Microsoft.AspNetCore.Mvc;
using ShareMyEvents.Domain.Dtos.Responses.Organizer;
using ShareMyEvents.Domain.Models;

namespace ShareMyEvents.Api.Controllers;

[Route("organizer")]
[ApiController]
public class OrganizerController: Controller
{
    [HttpGet()]
    [Route("next-event")]
    [ResponseType(typeof(OrganizerNextEventSummaryResponse))]
    public IActionResult GetNextEvent ()
    {
        return StatusCode(StatusCodes.Status200OK);
    }
}
