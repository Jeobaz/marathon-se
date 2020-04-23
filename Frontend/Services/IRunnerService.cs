using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontend.Services
{
    public interface IRunnerService
    {
        public Task<Runner> RegisterRunnerAsync(Runner runner);
        public Task EditRunnerAsync(Runner runner);
        public Task<Runner> GetRunnerByEmail(string email);
        public Task<List<Sponsorship>> GetSponsorships(Runner runner);
        public Task<Charity> GetCharity(Runner runner);
        public Task<List<string>> GetRaceEvents(Registration regRunner);
    }
}
