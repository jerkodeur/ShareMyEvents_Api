using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShareMyEvents.Api.Data;
using ShareMyEvents.Api.Exceptions;
using ShareMyEvents.Api.Services;
using ShareMyEvents.Domain.Dtos.Responses.EventResponses;
using ShareMyEvents.Domain.Models;

namespace ShareMyEvents.Api.Controllers
{
    [Route("events")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly ShareMyEventsApiContext _context;
        private readonly EventService _service;

        public EventsController (ShareMyEventsApiContext context, EventService service)
        {
            _context = context;
            _service = service;
        }

        // GET: api/Events
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetEvent()
        {
          if (_context.Events == null)
          {
              return NotFound();
          }
            return await _context.Events.ToListAsync();
        }

        // GET: api/Events/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> Get(int id)
        {
            EventPageResponse @event;

            try
            {
                @event = await _service.GetById(id);
            }
            catch(NotFoundException ex)
            {
                return NotFound();
            }
            catch(NullReferenceException ex)
            {
                return Problem(ex.Message);
            }

            return Ok(@event);
        }

        // PUT: api/Events/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent(int id, Event @event)
        {
            if (id != @event.Id)
            {
                return BadRequest();
            }

            _context.Entry(@event).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Events
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Event>> New(Event @event)
        {
          if (_context.Events == null)
          {
              return Problem("Entity set 'ShareMyEventsApiContext.Events'  is null.");
          }
            _context.Events.Add(@event);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOneById", new { id = @event.Id }, @event);
        }

        // DELETE: events/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.DeleteAsync(id);
            }
            catch (NotFoundException ex)
            {
                return NotFound();
            }
            catch(NullReferenceException ex)
            {
                return Problem(ex.Message);
            }

            return NoContent();
        }
    }
}
