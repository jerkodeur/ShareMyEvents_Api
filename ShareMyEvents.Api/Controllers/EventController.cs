using Microsoft.AspNetCore.Mvc;
using ShareMyEvents.Api.Exceptions;
using ShareMyEvents.Api.Services;
using ShareMyEvents.Domain.Dtos.Responses.EventResponses;
using ShareMyEvents.Domain.Dtos.Responses.ParticipantResponses;
using ShareMyEvents.Domain.Dtos.Resquests.EventRequests;
using ShareMyEvents.Domain.Dtos.Resquests.ParticipantRequests;

namespace ShareMyEvent.Api.Controllers;
[Route("events")]
[ApiController]
public class EventController: ControllerBase
{

    private readonly EventService _service;

    public EventController (EventService service) => _service = service;

    [HttpGet("{id}")]
    public async Task<ActionResult<EventPageResponse>> GetEvent (int id)
    {
        EventPageResponse eventPageResponse;

        try
        {
            eventPageResponse = await _service.GetByIdAsync(id);
        }
        catch(NotFoundException ex)
        {
            return NotFound();
        }
        catch(NullReferenceException ex)
        {
            return Problem(ex.Message);
        }

        return Ok(eventPageResponse);
    }

    [HttpPost]
    [Route("new")]
    public async Task<ActionResult<EventCreatedResponse>> New ([FromBody] EventCreateRequest request)
    {
        EventCreatedResponse eventCreatedResponse;

        try
        {
            eventCreatedResponse = await _service.CreateAsync(request);
        }
        catch(NotFoundException ex)
        {
            return NotFound();
        }
        catch(NullReferenceException ex)
        {
            return Problem(ex.Message);
        }
        return CreatedAtAction("NewEvent", eventCreatedResponse);
    }

    [HttpPost]
    [Route("access")]
    public ActionResult<ParticipantAccessResponse> New ([FromBody] ParticipationAccessRequest request)
    {
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPut]
    [Route("update/{id}/title")]
    public async Task<ActionResult<EventUpdateTitleResponse>> UpdateTitle (int id, [FromBody] EventUpdateTitleRequest request)
    {
        EventUpdateTitleResponse eventUpdateTitleResponse;

        try
        {
            eventUpdateTitleResponse = await _service.UpdateTitleResponseAsync(id, request);
        }
        catch(NotFoundException ex)
        {
            return NotFound();
        }
        catch(NullReferenceException ex)
        {
            return Problem(ex.Message);
        }

        return Ok(eventUpdateTitleResponse);
    }

    [HttpPut]
    [Route("update/{id}/description")]
    public async Task<ActionResult<EventUpdateDescriptionResponse>> UpdateDescription (int id, [FromBody] EventUpdateDescriptionRequest request)
    {
        EventUpdateDescriptionResponse eventUpdateDescriptionResponse;

        try
        {
            eventUpdateDescriptionResponse = await _service.UpdateDescriptionResponseAsync(id, request);
        }
        catch(NotFoundException ex)
        {
            return NotFound();
        }
        catch(NullReferenceException ex)
        {
            return Problem(ex.Message);
        }

        return Ok(eventUpdateDescriptionResponse);
    }

    [HttpPut]
    [Route("update/{id}/date")]
    public async Task<ActionResult<EventUpdateDateResponse>> UpdateDate (int id, [FromBody] EventUpdateDateRequest request)
    {
        EventUpdateDateResponse eventUpdateDateResponse;

        try
        {
            eventUpdateDateResponse = await _service.UpdateDateResponseAsync(id, request);
        }
        catch(NotFoundException ex)
        {
            return NotFound();
        }
        catch(NullReferenceException ex)
        {
            return Problem(ex.Message);
        }

        return Ok(eventUpdateDateResponse);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete (int id)
    {
        try
        {
            await _service.DeleteAsync(id);
        }
        catch(NotFoundException ex)
        {
            return NotFound();
        }
        catch(NullReferenceException ex)
        {
            return Problem(ex.Message);
        }

        return Ok();
    }
}
