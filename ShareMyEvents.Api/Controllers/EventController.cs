using Microsoft.AspNetCore.Mvc;
using ShareMyEvents.Api.Exceptions;
using ShareMyEvents.Api.Services;
using ShareMyEvents.Domain.Dtos.Responses.EventResponses;
using ShareMyEvents.Domain.Dtos.Resquests.EventRequests;

namespace ShareMyEvent.Api.Controllers;
[Route("events")]
[ApiController]
public class EventController: ControllerBase
{

    private readonly EventService _service;
    private CancellationToken _token;

    public EventController (EventService service, CancellationTokenSource cancellationToken)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
        _token = cancellationToken.Token;
    }

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
        catch(NullReferenceException ex)
        {
            return Problem(ex.Message);
        }

        return Ok(eventPageResponse);
    }

    [HttpPost]
    [Route("new")]
    public async Task<ActionResult<EventCreatedResponse>> NewEventAsync ([FromBody] EventCreateRequest request)
    {
        EventCreatedResponse eventCreatedResponse;

        try
        {
            eventCreatedResponse = await _service.CreateAsync(request, _token);
        }
        catch(NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch(NullReferenceException ex)
        {
            return Problem(ex.Message);
        }
        return CreatedAtAction("NewEvent", eventCreatedResponse);
    }

    //[HttpPost]
    //[Route("access")]
    //public ActionResult<ParticipantAccessResponse> New ([FromBody] ParticipationAccessRequest request)
    //{
    //    return StatusCode(StatusCodes.Status201Created);
    //}

    [HttpPut]
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
        catch(NullReferenceException ex)
        {
            return Problem(ex.Message);
        }

        return Ok(eventUpdateTitleResponse);
    }

    [HttpPut]
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
        catch(NullReferenceException ex)
        {
            return Problem(ex.Message);
        }

        return Ok(eventUpdateDescriptionResponse);
    }

    [HttpPut]
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
        catch(NullReferenceException ex)
        {
            return Problem(ex.Message);
        }

        return Ok(eventUpdateDateResponse);
    }

    [HttpDelete("{id}")]
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
        catch(NullReferenceException ex)
        {
            return Problem(ex.Message);
        }

        return Ok();
    }
}
