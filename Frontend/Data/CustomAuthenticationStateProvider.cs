using Blazored.SessionStorage;
using Frontend.Services;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Frontend.Data
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private ISessionStorageService _sessionStorageService;
        public IUserService _userService { get; set; }
        public CustomAuthenticationStateProvider(ISessionStorageService sessionStorageService, IUserService userService)
        {
            _sessionStorageService = sessionStorageService;
            _userService = userService;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string email = await _sessionStorageService.GetItemAsync<string>("email");
            var userDb = await _userService.GetUserByEmail(email);

            ClaimsIdentity identity;

            if (email != null)
            {
                identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, email),
                    new Claim(ClaimTypes.Role, userDb.RoleId)
                }, "apiauth_type");
            }
            else
            {
                identity = new ClaimsIdentity();
            }
            var user = new ClaimsPrincipal(identity);

            return await Task.FromResult(new AuthenticationState(user));
        }

        public void MarkUserAsAuthenticated(string email, string role)
        {
            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, email),
                new Claim(ClaimTypes.Role, role)
            }, "apiauth_type");

            var user = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        public void MarkUserAsLoggedOut()
        {
            _sessionStorageService.RemoveItemAsync("email");

            var identity = new ClaimsIdentity();

            var user = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }
    }
}
