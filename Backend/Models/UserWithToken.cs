using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class UserWithToken : User
    {
        public string Token { get; set; }

        public UserWithToken()
        {
        }

        public UserWithToken(User user)
        {
            Email = user.Email;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Password = user.Password;
            RoleId = user.RoleId;

            Role = user.Role;
            Runner = user.Runner;
        }
    }
}
