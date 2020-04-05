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
    public class GendersController : ControllerBase
    {
        private readonly marathonseContext _context;

        public GendersController(marathonseContext context)
        {
            _context = context;
        }

        // GET: api/Genders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gender>>> GetGender()
        {
            return await _context.Gender.ToListAsync();
        }

        // GET: api/Genders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Gender>> GetGender(string id)
        {
            var gender = await _context.Gender.FindAsync(id);

            if (gender == null)
            {
                return NotFound();
            }

            return gender;
        }

        // PUT: api/Genders/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutGender(string id, Gender gender)
        //{
        //    if (id != gender.Gender1)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(gender).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!GenderExists(id))
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

        // POST: api/Genders
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        //[HttpPost]
        //public async Task<ActionResult<Gender>> PostGender(Gender gender)
        //{
        //    _context.Gender.Add(gender);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (GenderExists(gender.Gender1))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetGender", new { id = gender.Gender1 }, gender);
        //}

        // DELETE: api/Genders/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Gender>> DeleteGender(string id)
        //{
        //    var gender = await _context.Gender.FindAsync(id);
        //    if (gender == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Gender.Remove(gender);
        //    await _context.SaveChangesAsync();

        //    return gender;
        //}

        private bool GenderExists(string id)
        {
            return _context.Gender.Any(e => e.Gender1 == id);
        }
    }
}
