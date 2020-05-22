using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontend.Services
{
    public interface IRegistrationEventService
    {
        public Task<bool> AcceptToRegisterAsync(RegistrationEvent registrationEvent);
        public Task<RegistrationEvent> RegisterAsync(RegistrationEvent registrationEvent);
    }
}
