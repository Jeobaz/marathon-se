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
    public class SponsorshipsController : ControllerBase
    {
        private readonly marathonseContext _context;

        public SponsorshipsController(marathonseContext context)
        {
            _context = context;
        }

        // GET: api/Sponsorships
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sponsorship>>> GetSponsorship()
        {
            return await _context.Sponsorship.ToListAsync();
        }

        // GET: api/Sponsorships/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sponsorship>> GetSponsorship(int id)
        {
            var sponsorship = await _context.Sponsorship.Include(x => x.Registration)
                                                            .ThenInclude(x => x.Charity)
                                                        .Include(x => x.Registration)
                                                            .ThenInclude(x => x.Runner)
                                                                .ThenInclude(x => x.EmailNavigation)
                                                        .Include(x => x.Registration)
                                                            .ThenInclude(x => x.RegistrationEvent)
                                                        .AsNoTracking()
                                                        .SingleAsync(x => x.SponsorshipId == id);

            if (sponsorship == null)
            {
                return NotFound();
            }

            return sponsorship;
        }

        // PUT: api/Sponsorships/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSponsorship(int id, Sponsorship sponsorship)
        {
            if (id != sponsorship.SponsorshipId)
            {
                return BadRequest();
            }

            _context.Entry(sponsorship).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SponsorshipExists(id))
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

        // POST: api/Sponsorships
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Sponsorship>> PostSponsorship(Sponsorship sponsorship)
        {
            _context.Sponsorship.Add(sponsorship);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSponsorship", new { id = sponsorship.SponsorshipId }, sponsorship);
        }

        // DELETE: api/Sponsorships/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Sponsorship>> DeleteSponsorship(int id)
        {
            var sponsorship = await _context.Sponsorship.FindAsync(id);
            if (sponsorship == null)
            {
                return NotFound();
            }

            _context.Sponsorship.Remove(sponsorship);
            await _context.SaveChangesAsync();

            return sponsorship;
        }

        private bool SponsorshipExists(int id)
        {
            return _context.Sponsorship.Any(e => e.SponsorshipId == id);
        }
    }
}
