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
    public class RegistrationEventsController : ControllerBase
    {
        private readonly marathonseContext _context;

        public RegistrationEventsController(marathonseContext context)
        {
            _context = context;
        }

        //// GET: api/RegistrationEvents
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<RegistrationEvent>>> GetRegistrationEvent()
        //{
        //    return await _context.RegistrationEvent.ToListAsync();
        //}

        // GET: api/RegistrationEvents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RegistrationEvent>> GetRegistrationEvent(int id)
        {
            var registrationEvent = await _context.RegistrationEvent.FindAsync(id);

            if (registrationEvent == null)
            {
                return NotFound();
            }

            return registrationEvent;
        }

        public (int From, int To) GetBorders(string ageCatgory)
        {
            if (ageCatgory == "U18")
                return (0, 18);
            else if (ageCatgory == "18to29")
                return (18, 30);
            else if (ageCatgory == "30to39")
                return (30, 40);
            else if (ageCatgory == "40to55")
                return (40, 56);
            else if (ageCatgory == "56to70")
                return (56, 71);
            else
                return (71, int.MaxValue);
        }

        // PUT: api/RegistrationEvents/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutRegistrationEvent(int id, RegistrationEvent registrationEvent)
        //{
        //    if (id != registrationEvent.RegistrationEventId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(registrationEvent).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!RegistrationEventExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/RegistrationEvents
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<RegistrationEvent>> PostRegistrationEvent(RegistrationEvent registrationEvent)
        {
            _context.RegistrationEvent.Add(registrationEvent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegistrationEvent", new { id = registrationEvent.RegistrationEventId }, registrationEvent);
        }
        // POST: api/RegistrationEvents/lastbibnumber
        [HttpPost("lastbibnumber")]
        public async Task<ActionResult<short>> PostGetBibNumber([FromBody] string eventId)
        {
            var hh = await _context.RegistrationEvent.Where(x => x.EventId == eventId)
                                                     .OrderBy(x => x.BibNumber)
                                                     .ToListAsync();
            var lastRegistrationEvent = await _context.RegistrationEvent.Where(x => x.EventId == eventId)
                                                                        .OrderBy(x => x.BibNumber)
                                                                        .LastOrDefaultAsync();
            if(lastRegistrationEvent != null)
            {
                return lastRegistrationEvent.BibNumber;
            }

            return 0;
        }

        // DELETE: api/RegistrationEvents/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<RegistrationEvent>> DeleteRegistrationEvent(int id)
        //{
        //    var registrationEvent = await _context.RegistrationEvent.FindAsync(id);
        //    if (registrationEvent == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.RegistrationEvent.Remove(registrationEvent);
        //    await _context.SaveChangesAsync();

        //    return registrationEvent;
        //}

        private bool RegistrationEventExists(int id)
        {
            return _context.RegistrationEvent.Any(e => e.RegistrationEventId == id);
        }
    }
}
