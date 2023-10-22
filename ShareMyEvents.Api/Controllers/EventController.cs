using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShareMyEvents.Api.Exceptions;
using ShareMyEvents.Domain.Dtos.Responses.EventResponses;
using ShareMyEvents.Domain.Dtos.Resquests.EventRequests;
using ShareMyEvents.Domain.Interfaces;

namespace ShareMyEvent.Api.Controllers;
[Route("events")]
[Produces("application/json")]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
[ApiController]
public class EventController: ControllerBase
{

    private readonly IEventService _service;
    private CancellationToken _token;

    public EventController (IEventService service, CancellationTokenSource cancellationToken)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
        _token = cancellationToken.Token;
    }

    /// <summary>
    /// Get event by id
    /// </summary>
    /// <response code="200">Returns requested event</response>
    /// <response code="400">The request is not valid</response>
    /// <response code="404">If the event doesn't exist</response>
    /// <response code="500">Internal server error</response>
    [HttpGet("{id}")]
    public async Task<ActionResult<EventPageResponse>> GetEventAsync (int id)
    {
        EventPageResponse eventPageResponse;

        try
        {
            eventPageResponse = await _service.GetByIdAsync(id, _token);
        }
        catch(NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch(Exception ex)
        {
            return Problem(ex.Message, "NewEventAsync", 500);
        }

        return Ok(eventPageResponse);
    }

    /// <summary>
    /// Create new event
    /// </summary>
    /// <response code="201">Returns event freshly created</response>
    /// <response code="400">The request is not valid</response>
    /// <response code="500">Internal server error</response>
    [HttpPost]
    [Authorize]
    [Route("new")]
    public async Task<ActionResult<EventCreatedResponse>> NewEventAsync ([FromBody] EventCreateRequest request)
    {
        EventCreatedResponse eventCreatedResponse;

        try
        {
            eventCreatedResponse = await _service.CreateAsync(request, _token);
        }
        catch(Exception ex)
        {
            return Problem(ex.Message, "NewEventAsync", 500);
        }

        return CreatedAtAction("NewEvent", eventCreatedResponse);
    }

    //[HttpPost]
    //[Route("access")]
    //public ActionResult<ParticipantAccessResponse> New ([FromBody] ParticipationAccessRequest request)
    //{
    //    return StatusCode(StatusCodes.Status201Created);
    //}

    /// <summary>
    /// Update event title
    /// </summary>
    /// <response code="200">Returns updated title associated with it event id</response>
    /// <response code="400">The request is not valid</response>
    /// <response code="404">If the event doesn't exist</response>
    /// <response code="500">Internal server error</response>
    [HttpPut]
    [Authorize]
    [Route("update/{id}/title")]
    public async Task<ActionResult<EventUpdateTitleResponse>> UpdateEventTitleAsync (int id, [FromBody] EventUpdateTitleRequest request)
    {
        EventUpdateTitleResponse eventUpdateTitleResponse;

        try
        {
            eventUpdateTitleResponse = await _service.UpdateTitleResponseAsync(id, request, _token);
        }
        catch(NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch(Exception ex)
        {
            return Problem(ex.Message, "NewEventAsync", 500);
        }

        return Ok(eventUpdateTitleResponse);
    }

    /// <summary>
    /// Update event description
    /// </summary>
    /// <response code="200">Returns updated description associated with it event id</response>
    /// <response code="400">The request is not valid</response>
    /// <response code="404">If the event doesn't exist</response>
    /// <response code="500">Internal server error</response>
    [HttpPut]
    [Authorize]
    [Route("update/{id}/description")]
    public async Task<ActionResult<EventUpdateDescriptionResponse>> UpdateEventDescriptionAsync (int id, [FromBody] EventUpdateDescriptionRequest request)
    {
        EventUpdateDescriptionResponse eventUpdateDescriptionResponse;

        try
        {
            eventUpdateDescriptionResponse = await _service.UpdateDescriptionResponseAsync(id, request, _token);
        }
        catch(NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch(Exception ex)
        {
            return Problem(ex.Message, "NewEventAsync", 500);
        }

        return Ok(eventUpdateDescriptionResponse);
    }

    /// <summary>
    /// Update event date
    /// </summary>
    /// <response code="200">Returns updated date associated with it event id</response>
    /// <response code="400">The request is not valid</response>
    /// <response code="404">If the event doesn't exist</response>
    /// <response code="500">Internal server error</response>
    [HttpPut]
    [Authorize]
    [Route("update/{id}/date")]
    public async Task<ActionResult<EventUpdateDateResponse>> UpdateEventDateAsync (int id, [FromBody] EventUpdateDateRequest request)
    {
        EventUpdateDateResponse eventUpdateDateResponse;

        try
        {
            eventUpdateDateResponse = await _service.UpdateDateResponseAsync(id, request, _token);
        }
        catch(NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch(Exception ex)
        {
            return Problem(ex.Message, "UpdateEventDateAsync", 500);
        }

        return Ok(eventUpdateDateResponse);
    }

    /// <summary>
    /// Delete event by Id
    /// </summary>
    /// <response code="204">Event has been deleted well</response>
    /// <response code="400">The request is not valid</response>
    /// <response code="404">If the event doesn't exist</response>
    /// <response code="500">Internal server error</response>
    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> DeleteEventAsync (int id)
    {
        try
        {
            await _service.DeleteAsync(id, _token);
        }
        catch(NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch(Exception ex)
        {
            return Problem(ex.Message, "DeleteEventAsync", 500);
        }

        return NoContent();
    }
}
