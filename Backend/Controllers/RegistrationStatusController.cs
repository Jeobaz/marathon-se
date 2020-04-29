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
    public class RegistrationStatusController : ControllerBase
    {
        private readonly marathonseContext _context;

        public RegistrationStatusController(marathonseContext context)
        {
            _context = context;
        }

        // GET: api/RegistrationStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegistrationStatus>>> GetRegistrationStatus()
        {
            return await _context.RegistrationStatus.ToListAsync();
        }

        // GET: api/RegistrationStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RegistrationStatus>> GetRegistrationStatus(byte id)
        {
            var registrationStatus = await _context.RegistrationStatus.FindAsync(id);

            if (registrationStatus == null)
            {
                return NotFound();
            }

            return registrationStatus;
        }

        // PUT: api/RegistrationStatus/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegistrationStatus(byte id, RegistrationStatus registrationStatus)
        {
            if (id != registrationStatus.RegistrationStatusId)
            {
                return BadRequest();
            }

            _context.Entry(registrationStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegistrationStatusExists(id))
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

        // POST: api/RegistrationStatus
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<RegistrationStatus>> PostRegistrationStatus(RegistrationStatus registrationStatus)
        {
            _context.RegistrationStatus.Add(registrationStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegistrationStatus", new { id = registrationStatus.RegistrationStatusId }, registrationStatus);
        }

        // DELETE: api/RegistrationStatus/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RegistrationStatus>> DeleteRegistrationStatus(byte id)
        {
            var registrationStatus = await _context.RegistrationStatus.FindAsync(id);
            if (registrationStatus == null)
            {
                return NotFound();
            }

            _context.RegistrationStatus.Remove(registrationStatus);
            await _context.SaveChangesAsync();

            return registrationStatus;
        }

        private bool RegistrationStatusExists(byte id)
        {
            return _context.RegistrationStatus.Any(e => e.RegistrationStatusId == id);
        }
    }
}
