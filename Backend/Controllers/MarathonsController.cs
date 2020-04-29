using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Models;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarathonsController : ControllerBase
    {
        private readonly marathonseContext _context;

        public MarathonsController(marathonseContext context)
        {
            _context = context;
        }

        // GET: api/Marathons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Marathon>>> GetMarathon()
        {
            return await _context.Marathon.ToListAsync();
        }

        // GET: api/Marathons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Marathon>> GetMarathon(byte id)
        {
            var marathon = await _context.Marathon.FindAsync(id);

            if (marathon == null)
            {
                return NotFound();
            }

            return marathon;
        }

        // PUT: api/Marathons/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMarathon(byte id, Marathon marathon)
        {
            if (id != marathon.MarathonId)
            {
                return BadRequest();
            }

            _context.Entry(marathon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarathonExists(id))
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

        // POST: api/Marathons
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Marathon>> PostMarathon(Marathon marathon)
        {
            _context.Marathon.Add(marathon);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMarathon", new { id = marathon.MarathonId }, marathon);
        }

        // DELETE: api/Marathons/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Marathon>> DeleteMarathon(byte id)
        {
            var marathon = await _context.Marathon.FindAsync(id);
            if (marathon == null)
            {
                return NotFound();
            }

            _context.Marathon.Remove(marathon);
            await _context.SaveChangesAsync();

            return marathon;
        }

        private bool MarathonExists(byte id)
        {
            return _context.Marathon.Any(e => e.MarathonId == id);
        }
    }
}
