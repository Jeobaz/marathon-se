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
    public class RaceKitOptionsController : ControllerBase
    {
        private readonly marathonseContext _context;

        public RaceKitOptionsController(marathonseContext context)
        {
            _context = context;
        }

        // GET: api/RaceKitOptions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RaceKitOption>>> GetRaceKitOption()
        {
            return await _context.RaceKitOption.ToListAsync();
        }

        // GET: api/RaceKitOptions/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<RaceKitOption>> GetRaceKitOption(string id)
        //{
        //    var raceKitOption = await _context.RaceKitOption.FindAsync(id);

        //    if (raceKitOption == null)
        //    {
        //        return NotFound();
        //    }

        //    return raceKitOption;
        //}

        // PUT: api/RaceKitOptions/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutRaceKitOption(string id, RaceKitOption raceKitOption)
        //{
        //    if (id != raceKitOption.RaceKitOptionId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(raceKitOption).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!RaceKitOptionExists(id))
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

        // POST: api/RaceKitOptions
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        //[HttpPost]
        //public async Task<ActionResult<RaceKitOption>> PostRaceKitOption(RaceKitOption raceKitOption)
        //{
        //    _context.RaceKitOption.Add(raceKitOption);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (RaceKitOptionExists(raceKitOption.RaceKitOptionId))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetRaceKitOption", new { id = raceKitOption.RaceKitOptionId }, raceKitOption);
        //}

        // DELETE: api/RaceKitOptions/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<RaceKitOption>> DeleteRaceKitOption(string id)
        //{
        //    var raceKitOption = await _context.RaceKitOption.FindAsync(id);
        //    if (raceKitOption == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.RaceKitOption.Remove(raceKitOption);
        //    await _context.SaveChangesAsync();

        //    return raceKitOption;
        //}

        //private bool RaceKitOptionExists(string id)
        //{
        //    return _context.RaceKitOption.Any(e => e.RaceKitOptionId == id);
        //}
    }
}
