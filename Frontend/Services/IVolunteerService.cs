using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontend.Services
{
    public interface IVolunteerService
    {
        public Task<Volunteer> AddVolunteerAsync(Volunteer volunteer);
        public Task<Volunteer> EditVolunteerAsync(Volunteer volunteer);
        public Task<bool> ExistVolunteerAsync(int volunteerId);
    }
}
