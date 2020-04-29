using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;

namespace Frontend.Services
{
    public interface ICharityService
    {
        public Task<Charity> AddCharity(Charity charity);
        public Task<Charity> EditCharity(Charity charity);
    }
}
