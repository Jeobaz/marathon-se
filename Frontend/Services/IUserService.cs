using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontend.Services
{
    public interface IUserService
    {
        public Task<UserWithToken> LoginAsync(User user);
        public Task<UserWithToken> RegisterAsync();

    }
}
