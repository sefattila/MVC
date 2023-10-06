using _17_API_JWT_Authentication.Context;
using _17_API_JWT_Authentication.Models;
using _17_API_JWT_Authentication.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace _17_API_JWT_Authentication.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/auth")]
    public class AuthController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        //user kayıt
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserForRegistrationDTO userDTO)
        {
            var result = _context.Users.SingleOrDefaultAsync(x => x.Email == userDTO.Email);

            if (result == null)
            {
                AppUser user = new AppUser();

                user.Id = Guid.NewGuid().ToString();
                user.FirstName = userDTO.FirstName;
                user.LastName = userDTO.LastName;
                user.NormalizedEmail = userDTO.Email.ToString();
                user.Email = userDTO.Email;
                user.EmailConfirmed = true;
                user.PasswordHash = userDTO.Password;
                user.SecurityStamp = Guid.NewGuid().ToString();
                user.ConcurrencyStamp = Guid.NewGuid().ToString();
                user.PhoneNumber = userDTO.PhoneNumber;
                user.PhoneNumberConfirmed = true;

                _context.Users.Add(user);
                _context.SaveChanges();

                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        //user login
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] AppUserLogin userLogin)
        {
            var login = _context.Users.SingleOrDefaultAsync(x => x.Email == userLogin.Email && x.PasswordHash == userLogin.Password);

            if (login != null)
            {
                var authClaims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Email,userLogin.Email),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                };

                var token = GetToken(authClaims);

                return Ok(
                    new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo
                    });
            }
            else
            {
                return Unauthorized();
            }
        }

        private JwtSecurityToken GetToken(List<Claim> authClaim)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWTSettings:securityKey"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                    _configuration["JWTSettings:validIssuer"],
                    _configuration["JWTSettings:validAudience"],
                    authClaim,
                    expires: DateTime.UtcNow.AddMinutes(10),
                    signingCredentials: signIn
                );

            return token;
        }
    }
}
