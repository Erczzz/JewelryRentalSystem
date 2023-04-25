using AutoMapper;
using JewelryRentalSystemAPI.DTO;
using JewelryRentalSystemAPI.Interface;
using JewelryRentalSystemAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JewelryRentalSystemAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        public IConfiguration _configuration { get; }

        public AccountController(IAccountRepository accountRepository, IMapper mapper, IConfiguration configuration)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> Register(SignUpDto signUpDto)
        {
            var user = _mapper.Map<ApplicationUser>(signUpDto);
            await _accountRepository.SignUpUserAsync(user, signUpDto.Password);
            return Ok();
        }

        /*[HttpPost("SignIn")]
        public async Task<IActionResult> LogIn(LogInDto logInDto)
        {
            var audience = _configuration["JWT:Audience"];
            var issuer = _configuration["JWT:Issuer"];
            var key = _configuration["JWT:Key"];

            if(ModelState.IsValid)
            {
                var loginResult = await _accountRepository.SignInUserAsync(logInDto);
                if(loginResult.Succeeded)
                {
                    var user = _accountRepository.FindUserByEmailAsync(logInDto.Email);
                    if (user != null)
                    {

                        var keyBytes = Encoding.UTF8.GetBytes(key);
                        var theKey = new SymmetricSecurityKey(keyBytes);
                        var creds = new SigningCredentials(theKey,SecurityAlgorithms.HmacSha256);
                        var token = new JwtSecurityToken(issuer, audience, null, expires: DateTime.Now.AddMinutes(30), signingCredentials: creds);
                        return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
                    }                   
                }
            }
            return BadRequest();
        }*/
        [HttpPost("SignIn")]
        public async Task<IActionResult> LogIn(LogInDto logInDto)
        {
            var audience = _configuration["JWT:Audience"];
            var issuer = _configuration["JWT:Issuer"];
            var key = _configuration["JWT:Key"];

            if (ModelState.IsValid)
            {
                var loginResult = await _accountRepository.SignInUserAsync(logInDto);
                if (loginResult.Succeeded)
                {
                    var user = await _accountRepository.FindUserByEmailAsync(logInDto.Email);
                    if (user != null)
                    {
                        // Get user's roles
                        var roles = await _accountRepository.GetUserRolesAsync(user);

                        var keyBytes = Encoding.UTF8.GetBytes(key);
                        var theKey = new SymmetricSecurityKey(keyBytes);
                        var creds = new SigningCredentials(theKey, SecurityAlgorithms.HmacSha256);

                        // Add user's role as claim
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, user.UserName),
                            new Claim(ClaimTypes.Email, user.Email),
                            new Claim(ClaimTypes.NameIdentifier, user.Id),
                        };
                        foreach (var role in roles)
                        {
                            claims.Add(new Claim(ClaimTypes.Role, role));
                        }

                        var token = new JwtSecurityToken(issuer, audience, claims, expires: DateTime.Now.AddMinutes(30), signingCredentials: creds);
                        return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
                    }
                }
            }
            return BadRequest();
        }

    }
}
