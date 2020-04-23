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

        // GET: api/Runners/filter?marathonId=2&eventTypeId=FR&genderId=Male&ageCategory=18to29&registerStatus=1&sortBy=LastName
        [HttpGet("filter")]
        public async Task<ActionResult<dynamic>> FilterRunner(
            int? marathonId,
            string eventTypeId,
            string genderId,
            string ageCategory,
            int? registerStatus,
            string sortBy)
        {
            var borders = GetBorders(ageCategory);
            var query = _context.RegistrationEvent.Include(x => x.Registration)
                                                        .ThenInclude(x => x.Runner)
                                                            .ThenInclude(x => x.EmailNavigation)
                                                  .Include(x => x.Registration)
                                                        .ThenInclude(x => x.RegistrationStatus)
                                                  .Include(x => x.Registration)
                                                        .ThenInclude(x => x.Runner)
                                                            .ThenInclude(x => x.CountryCodeNavigation)
                                                  .AsQueryable();
            if (marathonId.HasValue)
                query = query.Where(x => x.Event.MarathonId == marathonId.Value);

            if (!string.IsNullOrEmpty(eventTypeId))
                query = query.Where(x => x.Event.EventTypeId == eventTypeId);

            if (!string.IsNullOrEmpty(genderId) && genderId != "Any")
                query = query.Where(x => x.Registration.Runner.Gender == genderId);

            if (registerStatus.HasValue && registerStatus != 0)
                query = query.Where(x => x.Registration.RegistrationStatusId == registerStatus.Value);

            var now = DateTime.Now;
            if (!string.IsNullOrEmpty(genderId))
                query = query.Where(x => (now.Year - x.Registration.Runner.DateOfBirth.Value.Year) >= borders.From &&
                                         (now.Year - x.Registration.Runner.DateOfBirth.Value.Year) < borders.To);

            if (!string.IsNullOrEmpty(sortBy))
            {
                switch(sortBy)
                {
                    case "FirstName":
                        query = query.OrderBy(x => x.Registration.Runner.EmailNavigation.FirstName);
                        break;
                    case "LastName":
                        query = query.OrderBy(x => x.Registration.Runner.EmailNavigation.LastName);
                        break;
                    case "Email":
                        query = query.OrderBy(x => x.Registration.Runner.Email);
                        break;
                    case "RaceTime":
                        query = query.OrderBy(x => x.RaceTime).Where(x => x.RaceTime.HasValue && x.RaceTime > 0);
                        break;
                    case "RegisterStatus":
                        query = query.OrderBy(x => x.Registration.RegistrationStatus.RegistrationStatus1);
                        break;
                }
            }

            var runnersResult = await query.AsNoTracking()
                                           .ToListAsync();

            return new
            {
                TotalRunners = runnersResult.Count,
                TotalRunnersFinished = runnersResult.Count(x => x.RaceTime.HasValue),
                AvgRaceTime = runnersResult.Where(x => x.RaceTime.HasValue)
                                           .Average(x => x.RaceTime) ?? 0,
                Runners = runnersResult
            };
        }

        // POST: api/Runners/email/
        [HttpPost("email")]
        public async Task<ActionResult<Runner>> GetRunnerFromEmail([FromBody] string email)
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

            _context.Attach(runner);
            _context.Entry(runner).Reference(x => x.EmailNavigation).IsModified = true;
            _context.Entry(runner).State = EntityState.Modified;

            try
            {
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

        // POST: api/Runners/charity
        [HttpPost("charity")]
        public async Task<ActionResult<Charity>> GetCharityByRunner([FromBody]Runner runner)
        {
            var charity = await _context.Charity.SingleOrDefaultAsync(x => x.CharityId == runner.Registration.First().CharityId);
            
            if (charity == null)
                return NotFound();

            return charity;
        }

        // POST: api/Runners/sponsorships
        [HttpPost("sponsorships")]
        public async Task<ActionResult<List<Sponsorship>>> GetSponsorshipsByRunner([FromBody]Runner runner)
        {
            var sponsorships = await _context.Sponsorship.Where(x => x.RegistrationId == runner.Registration.First().RegistrationId)
                                                         .ToListAsync();

            if (sponsorships == null)
                return NotFound();

            return sponsorships;
        }

        // POST: api/Runners/raceevents
        [HttpPost("raceevents")]
        public async Task<ActionResult<List<string>>> GetRaceEventsByRunner([FromBody]Registration regRunner)
        {
            var raceEvents = await _context.RegistrationEvent.Include(x => x.Event)
                                                                .ThenInclude(x => x.EventType)
                                                             .Where(x => x.RegistrationId == regRunner.RegistrationId)
                                                             .Select(x => x.Event.EventType.EventTypeName)
                                                             .ToListAsync();

            return raceEvents;
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
