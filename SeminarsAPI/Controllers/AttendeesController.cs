using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeminarsAPI.Context;
using SeminarsAPI.Models;

namespace SeminarsAPI.Controllers
{
    [Route("api/Attendees")]
    [ApiController]
    public class AttendeesController : ControllerBase
    {
        private readonly SeminarContext _context;

        public AttendeesController(SeminarContext context)
        {
            _context = context;
        }

        // GET: api/Attendees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Attendee>>> GetAttendeeModels()
        {
            return await _context.AttendeeModels.ToListAsync();
        }

        // GET: api/Attendees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Attendee>> GetAttendee(int id)
        {
            var attendee = await _context.AttendeeModels.FindAsync(id);

            if (attendee == null)
            {
                return NotFound();
            }

            return attendee;
        }

        // PUT: api/Attendees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAttendee(int id, Attendee attendee)
        {
            if (id != attendee.ID)
            {
                return BadRequest();
            }

            _context.Entry(attendee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttendeeExists(id))
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

        // POST: api/Attendees
        [HttpPost]
        public async Task<ActionResult<Attendee>> PostAttendee(Attendee attendee)
        {
            _context.AttendeeModels.Add(attendee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAttendee", new { id = attendee.ID }, attendee);
        }

        // DELETE: api/Attendees/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Attendee>> DeleteAttendee(int id)
        {
            var attendee = await _context.AttendeeModels.FindAsync(id);
            if (attendee == null)
            {
                return NotFound();
            }

            _context.AttendeeModels.Remove(attendee);
            await _context.SaveChangesAsync();

            return attendee;
        }

        private bool AttendeeExists(int id)
        {
            return _context.AttendeeModels.Any(e => e.ID == id);
        }
    }
}
