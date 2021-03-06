﻿using System;
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
    public class EventsController : ControllerBase
    {
        private readonly marathonseContext _context;

        public EventsController(marathonseContext context)
        {
            _context = context;
        }

        // GET: api/Events
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetEvent()
        {
            return await _context.Event.Include(x => x.EventType)
                                       .ToListAsync();
        }

        // GET: api/Events/actualevents
        [HttpGet("actualevents")]
        public async Task<ActionResult<IEnumerable<Event>>> GetActualEvents()
        {
            return await _context.Event.Include(x => x.EventType)
                                       .Where(x => x.EventId.Contains("15") && 
                                                   _context.RegistrationEvent.Where(regEvent => regEvent.EventId == x.EventId).Count() < x.MaxParticipants)
                                       .ToListAsync();
        }

        // GET: api/Events/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEvent(string id)
        {
            var @event = await _context.Event.Include(x => x.EventType)
                                             .SingleOrDefaultAsync(x => x.EventId == id);

            if (@event == null)
            {
                return NotFound();
            }

            return @event;
        }

        // PUT: api/Events/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutEvent(string id, Event @event)
        //{
        //    if (id != @event.EventId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(@event).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!EventExists(id))
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

        // POST: api/Events
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        //[HttpPost]
        //public async Task<ActionResult<Event>> PostEvent(Event @event)
        //{
        //    _context.Event.Add(@event);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (EventExists(@event.EventId))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetEvent", new { id = @event.EventId }, @event);
        //}

        // DELETE: api/Events/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Event>> DeleteEvent(string id)
        //{
        //    var @event = await _context.Event.FindAsync(id);
        //    if (@event == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Event.Remove(@event);
        //    await _context.SaveChangesAsync();

        //    return @event;
        //}

        private bool EventExists(string id)
        {
            return _context.Event.Any(e => e.EventId == id);
        }
    }
}
