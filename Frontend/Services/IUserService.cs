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

        public Task<User> GetUserByEmail(string email);

        public Task<User> GetUserByToken(string token);

        public Task<string> GetTokenByUser(User user);

        public Task EditUserAsync(User user);

        public Task<User> AddUserAsync(User user);
    }
}
