using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Models;
using Backend.Data;

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

        // GET: api/Runners/regrunners
        [HttpGet("regrunners")]
        public async Task<ActionResult<IEnumerable<Runner>>> GetRegRunner()
        {

            return await _context.Runner.Include(x => x.Registration)
                                            .ThenInclude(reg => reg.RegistrationEvent)
                                        .Include(x => x.Registration)
                                            .ThenInclude(x => x.Charity)
                                        .Include(x => x.EmailNavigation)
                                        .Where(x => x.Registration.Count == 1)
                                        .Where(x => x.Registration.First().RegistrationEvent.Count > 0 &&
                                                    x.Registration.First().RegistrationEvent.Any(regEvent => regEvent.EventId.Contains("15")))
                                        .AsNoTracking()
                                        .ToListAsync();
        }
        // POST: api/Runners/ranks
        [HttpPost("ranks")]
        public async Task<ActionResult<List<RegEventWithRanks>>> GetGeneralRunk([FromBody] int runnerId)
        {
            var runner = await _context.Runner.Include(x => x.Registration)
                                                    .ThenInclude(reg => reg.RegistrationEvent)
                                                        .ThenInclude(regEvent => regEvent.Event)
                                                            .ThenInclude(evnt => evnt.Marathon)
                                              .Include(x => x.Registration)
                                                    .ThenInclude(reg => reg.RegistrationEvent)
                                                        .ThenInclude(regEvent => regEvent.Event)
                                                            .ThenInclude(evnt => evnt.EventType)
                                              .SingleOrDefaultAsync(x => x.RunnerId == runnerId);

            if (runner == null)
                return NotFound();

            var reg = runner.Registration.First();
            var regEvents = reg.RegistrationEvent.Where(x => x.RaceTime.HasValue)
                                                 .Select(x => new RegEventWithRanks
                                                 {
                                                     BibNumber = x.BibNumber,
                                                     EventId = x.EventId,
                                                     RaceTime = x.RaceTime,
                                                     Registration = x.Registration,
                                                     RegistrationId = x.RegistrationId,
                                                     RegistrationEventId = x.RegistrationEventId,
                                                     Event = x.Event,
                                                 })
                                                 .ToList();

            var ageCat = AgeMapping.GetAgeCategory(runner.DateOfBirth.Value);

            regEvents.ForEach(regEvnt =>
            {
                regEvnt.GeneralRank = _context.RegistrationEvent.Where(x => x.RaceTime.HasValue)
                                                                .Count(x => x.EventId == regEvnt.EventId &&
                                                                            x.RaceTime < regEvnt.RaceTime) + 1;
                regEvnt.CatRank = _context.RegistrationEvent.Where(x => x.RaceTime.HasValue)
                                                            .Where(x => x.EventId == regEvnt.EventId &&
                                                                        x.RaceTime < regEvnt.RaceTime)
                                                            .Include(x => x.Registration)
                                                                .ThenInclude(x => x.Runner)
                                                            .ToList()
                                                            .Count(x => x.Registration.Runner.Gender == x.Registration.Runner.Gender &&
                                                                        AgeMapping.GetAgeCategory(x.Registration.Runner.DateOfBirth.Value) == ageCat) + 1;
            });

            return regEvents;


        }

        // GET: api/Runners/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Runner>> GetRunner(int id)
        {
            var runner = await _context.Runner.Include(x => x.EmailNavigation)
                                              .SingleOrDefaultAsync(x => x.RunnerId == id);

            if (runner == null)
                return NotFound();

            return runner;
        }

        // POST: api/Runners/email/
        [HttpPost("email")]
        public async Task<ActionResult<Runner>> GetRunnerIdFromEmail([FromBody] string email)
        {
            var runner = await _context.Runner.Include(x => x.EmailNavigation)
                                              .Include(x => x.Registration)
                                              .AsNoTracking()
                                              .SingleOrDefaultAsync(x => x.Email == email);

            if (runner == null)
                return NotFound();

            return runner;
        }

        // PUT: api/Runners/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRunner(int id, [FromBody] Runner runner)
        {
            if (id != runner.RunnerId)
            {
                return BadRequest();
            }
            //ru
            _context.Attach(runner);
            _context.Entry(runner).Reference(x => x.EmailNavigation).IsModified = true;
            _context.Entry(runner).State = EntityState.Modified;
            //var runnerToUpdate = await _context.Runner.SingleAsync(x => x.RunnerId == runner.RunnerId);
            try
            {
                //runnerToUpdate.EmailNavigation.FirstName = runner.EmailNavigation.FirstName;
                //runnerToUpdate.EmailNavigation.LastName = runner.EmailNavigation.LastName;
                //runnerToUpdate.CountryCode = runner.CountryCode;
                //runnerToUpdate.Gender = runner.Gender;
                //runnerToUpdate.DateOfBirth = runner.DateOfBirth;
                _context.User.Update(runner.EmailNavigation);
                _context.Runner.Update(runner);
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
        //[HttpPost]
        //public async Task<ActionResult<Runner>> PostRunner(Runner runner)
        //{
        //    _context.Runner.Add(runner);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetRunner", new { id = runner.RunnerId }, runner);
        //}
        // POST: api/Runners/Register
        [HttpPost("Register")]
        public async Task<ActionResult<Runner>> RegisterRunner(Runner runner)
        {
            _context.Runner.Add(runner);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRunner", new { id = runner.RunnerId }, runner);
        }

        // DELETE: api/Runners/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Runner>> DeleteRunner(int id)
        //{
        //    var runner = await _context.Runner.FindAsync(id);
        //    if (runner == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Runner.Remove(runner);
        //    await _context.SaveChangesAsync();

        //    return runner;
        //}

        private bool RunnerExists(int id)
        {
            return _context.Runner.Any(e => e.RunnerId == id);
        }
    }
}
