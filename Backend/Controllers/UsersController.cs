using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Options;
using Backend.Data;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly marathonseContext _context;
        private readonly JWTSettings _jwtsettings;

        public UsersController(marathonseContext context, IOptions<JWTSettings> jwtsettings)
        {
            _context = context;
            _jwtsettings = jwtsettings.Value;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
            return await _context.User.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(string id)
        {
            var user = await _context.User.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }
            user.Password = null;
            return user;
        }

        // GET: api/Users/email/
        [HttpPost("email")]
        public async Task<ActionResult<User>> GetUserByEmail([FromBody] string email)
        {
            var user = await _context.User.SingleOrDefaultAsync(x => x.Email == email);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // POST: api/Users/Login
        [HttpPost("Login")]
        public async Task<ActionResult<UserWithToken>> Login([FromBody] User user)
        {
            user = await _context.User.Include(u => u.Role)
                                      .Where(u => u.Email == user.Email && u.Password == user.Password)
                                      .FirstOrDefaultAsync();

            UserWithToken userWithToken = null;
            
            if (user != null)
                userWithToken = new UserWithToken(user);

            if (userWithToken == null)
            {
                return NotFound();
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtsettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Email)
                }),
                Expires = DateTime.UtcNow.AddMonths(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            userWithToken.Token = tokenHandler.WriteToken(token);

            return userWithToken;
        }

        // POST: api/Users/Register
        [HttpPost("Register")]
        public async Task<ActionResult<UserWithToken>> Register([FromBody] User user)
        {
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();

            var userWithToken = new UserWithToken(user);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtsettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Email)
                }),
                Expires = DateTime.UtcNow.AddMonths(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            userWithToken.Token = tokenHandler.WriteToken(token);

            return userWithToken;
        }

        // POST: api/Users/user_by_token
        [HttpPost("user_by_token")]
        public async Task<ActionResult<User>> GetUserToken([FromBody] string token)
        {
            var user = await GetUserByToken(token);

            if (user != null)
            {
                return user;
            }

            return null;
        }

        // GET: api/Users/filter?sortBy=LastName&role=R&search=john
        [HttpGet("filter")]
        public async Task<ActionResult<List<User>>> UsersFilter(
            string sortBy,
            string role,
            string search)
        {

            var query = _context.User.Include(x => x.Role).AsQueryable();

            if (!string.IsNullOrEmpty(role) && role != "All")
                query = query.Where(x => x.RoleId == role);

            if (!string.IsNullOrEmpty(search))
            {
                var searchStrLower = search.ToLower();

                query = query.Where(x => x.Email.ToLower().Contains(searchStrLower) ||
                                         x.FirstName.ToLower().Contains(searchStrLower) ||
                                         x.LastName.ToLower().Contains(searchStrLower));
            }

            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy)
                {
                    case "FirstName":
                        query = query.OrderBy(x => x.FirstName);
                        break;
                    case "LastName":
                        query = query.OrderBy(x => x.LastName);
                        break;
                    case "Email":
                        query = query.OrderBy(x => x.Email);
                        break;
                    case "Role":
                        query = query.OrderBy(x => x.Role.RoleName);
                        break;
                }
            }

            return await query.AsNoTracking().ToListAsync();
        }

        private async Task<User> GetUserByToken(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_jwtsettings.SecretKey);

                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };

                SecurityToken securityToken;
                var principle = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);

                JwtSecurityToken jwtSecurityToken = securityToken as JwtSecurityToken;

                if (jwtSecurityToken != null && jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                {
                    var email = principle.FindFirst(ClaimTypes.Name)?.Value;

                    return await _context.User.Where(x => x.Email == email).SingleOrDefaultAsync();
                }
            }
            catch (Exception)
            {
                return new User();
            }

            return new User();
        }

        // POST: api/Users/token_by_user
        [HttpPost("token_by_user")]
        public ActionResult<string> GetToken([FromBody] User user)
        {
            return GetTokenByEmail(user.Email);
        }

        private string GetTokenByEmail(string email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtsettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, email)
                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        // PUT: api/Users/test@mail.ru
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(string id, User user)
        {
            if (id != user.Email)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        [HttpPost]
        public ActionResult<User> PostUser(User user)
        {
            _context.User.Add(user);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (UserExists(user.Email))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUser", new { id = user.Email }, user);
        }

        // DELETE: api/Users/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<User>> DeleteUser(string id)
        //{
        //    var user = await _context.User.FindAsync(id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.User.Remove(user);
        //    await _context.SaveChangesAsync();

        //    return user;
        //}

        private bool UserExists(string id)
        {
            return _context.User.Any(e => e.Email == id);
        }
    }
}
