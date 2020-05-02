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
    public class VolunteersController : ControllerBase
    {
        private readonly marathonseContext _context;

        public VolunteersController(marathonseContext context)
        {
            _context = context;
        }

        // GET: api/Volunteers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Volunteer>>> GetVolunteer()
        {
            return await _context.Volunteer.Include(x => x.CountryCodeNavigation).ToListAsync();
        }

        // GET: api/Volunteers/filter?sortBy=
        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<Volunteer>>> FilterVolunteer(string sortBy)
        {
            var query = _context.Volunteer.Include(x => x.CountryCodeNavigation).AsQueryable();

            switch (sortBy)
            {
                case "FirstName":
                    query = query.OrderBy(x => x.FirstName);
                    break;
                case "LastName":
                    query = query.OrderBy(x => x.LastName);
                    break;
                case "Country":
                    query = query.OrderBy(x => x.CountryCodeNavigation.CountryName);
                    break;
                case "Gender":
                    query = query.OrderBy(x => x.Gender);
                    break;
            }

            return await query.ToListAsync();
        }

        // GET: api/Volunteers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Volunteer>> GetVolunteer(int id)
        {
            var volunteer = await _context.Volunteer.FindAsync(id);

            if (volunteer == null)
            {
                return NotFound();
            }

            return volunteer;
        }



        // PUT: api/Volunteers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVolunteer(int id, Volunteer volunteer)
        {
            if (id != volunteer.VolunteerId)
            {
                return BadRequest();
            }

            _context.Entry(volunteer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VolunteerExists(id))
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

        // POST: api/Volunteers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public  ActionResult<Volunteer> PostVolunteer(Volunteer volunteer)
        {
            _context.Volunteer.Add(volunteer);
            _context.SaveChanges();

            return CreatedAtAction("GetVolunteer", new { id = volunteer.VolunteerId }, volunteer);
        }

        // DELETE: api/Volunteers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Volunteer>> DeleteVolunteer(int id)
        {
            var volunteer = await _context.Volunteer.FindAsync(id);
            if (volunteer == null)
            {
                return NotFound();
            }

            _context.Volunteer.Remove(volunteer);
            await _context.SaveChangesAsync();

            return volunteer;
        }

        // GET: api/Volunteers/exist/5
        [HttpGet("exist/{id}")]
        public async Task<ActionResult<bool>> ExistVolunteer(int id)
        {
            return await _context.Volunteer.AnyAsync(e => e.VolunteerId == id);
        }

        private bool VolunteerExists(int id)
        {
            return _context.Volunteer.Any(e => e.VolunteerId == id);
        }
    }
}
