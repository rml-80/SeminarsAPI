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
    [Route("api/Seminars")]
    [ApiController]
    public class SeminarsController : ControllerBase
    {
        private readonly SeminarContext _context;

        public SeminarsController(SeminarContext context)
        {
            _context = context;
        }

        // GET: api/Seminars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Seminar>>> GetSeminarModels()
        {
            return await _context.SeminarModels.ToListAsync();
        }

        // GET: api/Seminars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Seminar>> GetSeminar(int id)
        {
            var seminar = await _context.SeminarModels.FindAsync(id);

            if (seminar == null)
            {
                return NotFound();
            }

            return seminar;
        }

        // PUT: api/Seminars/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSeminar(int id, Seminar seminar)
        {
            if (id != seminar.ID)
            {
                return BadRequest();
            }

            _context.Entry(seminar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeminarExists(id))
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

        // POST: api/Seminars
        [HttpPost]
        public async Task<ActionResult<Seminar>> PostSeminar(Seminar seminar)
        {
            _context.SeminarModels.Add(seminar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSeminar", new { id = seminar.ID }, seminar);
        }

        // DELETE: api/Seminars/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Seminar>> DeleteSeminar(int id)
        {
            var seminar = await _context.SeminarModels.FindAsync(id);
            if (seminar == null)
            {
                return NotFound();
            }

            _context.SeminarModels.Remove(seminar);
            await _context.SaveChangesAsync();

            return seminar;
        }

        private bool SeminarExists(int id)
        {
            return _context.SeminarModels.Any(e => e.ID == id);
        }
    }
}
