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
    public class CharitiesController : ControllerBase
    {
        private readonly marathonseContext _context;

        public CharitiesController(marathonseContext context)
        {
            _context = context;
        }

        // GET: api/Charities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Charity>>> GetCharity()
        {
            return await _context.Charity.ToListAsync();
        }

        // GET: api/Charities/sponsors?sortBy=Name
        [HttpGet("sponsors")]
        public async Task<ActionResult<IEnumerable<Charity>>> GetCharityWithSponsors(string sortBy)
        {
            var result = await _context.RegistrationEvent.Include(x => x.Event)
                                                        .ThenInclude(x => x.Marathon)
                                                .Include(x => x.Registration)
                                                        .ThenInclude(x => x.Charity)
                                                .Where(x => x.Event.Marathon.YearHeld == 2015)
                                                .ToListAsync();

            var groupedRes = result.GroupBy(x => x.Registration.Charity)
                                    .Select(x => new CharityAmount
                                    {
                                        CharityId = x.Key.CharityId,
                                        CharityDescription = x.Key.CharityDescription,
                                        CharityLogo = x.Key.CharityLogo,
                                        CharityName = x.Key.CharityName,
                                        Amount = (int)x.Sum(y => y.Registration.SponsorshipTarget)
                                    })
                                    .OrderBy(x => x.CharityName)
                                    .ToList();

            //switch (sortBy)
            //{
            //    case "Name":
            //        groupedRes = groupedRes.OrderBy(x => x.CharityName).ToList();
            //        break;
            //    case "Amount":
            //        groupedRes = groupedRes.OrderBy(x => x.Amount).ToList();
            //        break;
            //}
            
            return groupedRes;
        }

        // GET: api/Charities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Charity>> GetCharity(int id)
        {
            var charity = await _context.Charity.FindAsync(id);

            if (charity == null)
            {
                return NotFound();
            }

            return charity;
        }

        // PUT: api/Charities/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharity(int id, Charity charity)
        {
            if (id != charity.CharityId)
            {
                return BadRequest();
            }

            _context.Entry(charity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharityExists(id))
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

        // POST: api/Charities
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Charity>> PostCharity(Charity charity)
        {
            _context.Charity.Add(charity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCharity", new { id = charity.CharityId }, charity);
        }

        // DELETE: api/Charities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Charity>> DeleteCharity(int id)
        {
            var charity = await _context.Charity.FindAsync(id);
            if (charity == null)
            {
                return NotFound();
            }

            _context.Charity.Remove(charity);
            await _context.SaveChangesAsync();

            return charity;
        }

        private bool CharityExists(int id)
        {
            return _context.Charity.Any(e => e.CharityId == id);
        }
    }
}
