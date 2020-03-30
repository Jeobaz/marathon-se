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
    public class RunnersController : ControllerBase
    {
        private readonly marathonseContext _context;

        public RunnersController(marathonseContext context)
        {
            _context = context;
        }

        // GET: api/Runners
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Runner>>> GetRunner()
        {
            return await _context.Runner
                //.Include(x => x.CountryCodeNavigation)
                                        .Include(x => x.EmailNavigation)
                                        //.Include(x => x.GenderNavigation)
                                        .ToListAsync();
        }

        // GET: api/regrunners
        [HttpGet("regrunners")]
        public async Task<ActionResult<IEnumerable<Runner>>> GetRegRunner()
        {

            return await _context.Runner.Include(x => x.Registration)
                                            .ThenInclude(reg => reg.RegistrationEvent)
                                        .Include(x => x.Registration)
                                            .ThenInclude(x => x.Charity)
                                        .Include(x => x.EmailNavigation)
                                        .Where(x => x.Registration.Count == 1)
                                        .Where(x => x.Registration.First().RegistrationEvent.Count == 1)
                                        .AsNoTracking()
                                        .ToListAsync();
        }

        // GET: api/Runners/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Runner>> GetRunner(int id)
        {
            var runner = await _context.Runner.FindAsync(id);

            if (runner == null)
            {
                return NotFound();
            }

            return runner;
        }

        // PUT: api/Runners/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRunner(int id, Runner runner)
        {
            if (id != runner.RunnerId)
            {
                return BadRequest();
            }

            _context.Entry(runner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RunnerExists(id))
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

        // POST: api/Runners
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Runner>> PostRunner(Runner runner)
        {
            _context.Runner.Add(runner);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRunner", new { id = runner.RunnerId }, runner);
        }

        // DELETE: api/Runners/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Runner>> DeleteRunner(int id)
        {
            var runner = await _context.Runner.FindAsync(id);
            if (runner == null)
            {
                return NotFound();
            }

            _context.Runner.Remove(runner);
            await _context.SaveChangesAsync();

            return runner;
        }

        private bool RunnerExists(int id)
        {
            return _context.Runner.Any(e => e.RunnerId == id);
        }
    }
}
