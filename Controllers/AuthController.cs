using FilmRental.Models.DTOs.Identity;
using FilmRental.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FilmRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _config;
        private readonly EmailService _emailService;
        public AuthController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IConfiguration config, EmailService emailService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _config = config;
            _emailService = emailService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO register)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = new IdentityUser { UserName = register.Email, Email = register.Email };
            var result = await _userManager.CreateAsync(user, register.Password);

            if (!result.Succeeded)
            {
                return BadRequest();
            }

            var emailConfirmToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var confirmationLink = Url.Action("ConfirmEmail", "Auth",
                new { emailConfirmToken, email = user.Email }, Request.Scheme, Request.Host.ToString());

            var emailSent = await _emailService.SendEmailAsync(user.Email, "Confirm your email",
                $" <a href='{confirmationLink}'>Confirm your email</a>");

            if (!emailSent)
            {
                return BadRequest("Error sending email.");
            }

            return Ok("User registered!");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = await _userManager.FindByEmailAsync(login.Email);
            if (user == null)
            {
                return BadRequest("Invalid email");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, login.Password, false);
            if (!result.Succeeded)
            {
                return BadRequest("Invalid password");
            }

            var token = GenerateJwtTokenAsync(user);

            return Ok(new { token });
        }

        [HttpGet("GoogleLogin")]
        public IActionResult GoogleLogin()
        {
            var redirectUrl = Url.Action("GoogleResponse", "Auth");
            var props = _signInManager.ConfigureExternalAuthenticationProperties("Google", redirectUrl);

            return new ChallengeResult("Google", props);
        }


        [HttpGet("GoogleResponse")]
        public async Task<IActionResult> GoogleResponse()
        {
            var result = await HttpContext.AuthenticateAsync(IdentityConstants.ExternalScheme);
            if (!result.Succeeded)
                return BadRequest("Google Authentication failed.");

            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
                return BadRequest("External login information is missing.");

            var user = await _userManager.FindByEmailAsync(result.Principal.FindFirstValue(ClaimTypes.Email));

            if (user == null)
            {
                // Create the user if not found
                user = new IdentityUser { 
                    UserName = result.Principal.FindFirstValue(ClaimTypes.Email), 
                    Email = result.Principal.FindFirstValue(ClaimTypes.Email) 
                };
                
                var createUserResult = await _userManager.CreateAsync(user);
                
                if (!createUserResult.Succeeded)
                    return BadRequest("User registration failed.");
            }

            var token = GenerateJwtTokenAsync(user);

            return Ok(new { token });
        }

        private string GenerateJwtTokenAsync(IdentityUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            // Lägg till "IConfiguration" i DI.
            var jwtKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var jwtIssuer = _config["Jwt:Issuer"];
            var jwtAudience = _config["Jwt:Audience"];

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            var token = new JwtSecurityToken
                (
                    issuer: jwtIssuer,
                    audience: jwtAudience,
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: new SigningCredentials(jwtKey, SecurityAlgorithms.HmacSha256)
                );

            return tokenHandler.WriteToken(token);
        }

        [HttpGet("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string emailConfirmToken, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return BadRequest("Invalid Email");
            }

            var result = await _userManager.ConfirmEmailAsync(user, emailConfirmToken);
            if (!result.Succeeded)
            {
                return BadRequest("Email confirmation failed");
            }

            return Ok("Email confirmed!");
        }
    }
}
