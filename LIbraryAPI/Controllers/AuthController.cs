using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using LibraryApp.ApiModels;
using LibraryApp.Core.Models;

namespace LibraryApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    //todo Do I need??
    //[ApiController]
    public class AuthController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _config;

        public AuthController(UserManager<User> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _config = configuration;
        }

        //POST api/auth/register
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RegistrationModel registration)
        {
            var newUser = new User
            {
                UserName = registration.Email,
                Email = registration.Email,
                FirstName = registration.FirstName,
                LastName = registration.LastName
            };

            var result = await _userManager.CreateAsync(newUser, registration.Password);
            if (result.Succeeded)
            {
                return Ok();
            }
            foreach(var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return BadRequest(ModelState);
        }

        //POST: api/auth/login
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginModel login)
        {
            IActionResult response = Unauthorized();
            var user = await AuthenticateUserAsync(login.Email, login.Password);

            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString, email = login.Email });
            }

            return response;
        }

        private string GenerateJSONWebToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            // retrieve the secret key from configuration
            var key = Encoding.ASCII.GetBytes(_config["Jwt:Key"]);
            // create signing credentials based on secret key
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);
            var claims = new Claim[]
            {
                // add Email to the token payload
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
            };
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddDays(7), // make the token valid for 7 days
                signingCredentials: credentials);
            // return the string representation of the token
            return tokenHandler.WriteToken(token);
        }

        private async Task<User> AuthenticateUserAsync(string userName, string password)
        {
            // retrieve the user by username and then check password
            var user = await _userManager.FindByNameAsync(userName);
            if (user != null && await _userManager.CheckPasswordAsync(user, password))
            {
                return user;
            }
            return null;
        }

        [HttpGet("verify")]
        public IActionResult Verify()
        {
            return Ok();
        }
    }
}