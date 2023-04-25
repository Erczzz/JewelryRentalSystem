using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using JewelryRentalSystemAPI.DTO;
using JewelryRentalSystemAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JewelryRentalSystemAPI.Controllers
{
    [Authorize(Roles = "Administrator")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<UsersDto>>> GetUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            var usersDto = new List<UsersDto>();
            foreach (var user in users)
            {
                usersDto.Add(new UsersDto
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Birthdate = user.Birthdate,
                    ContactNo = user.ContactNo,
                    Address = user.Address,
                    isActive = user.isActive,
                    CustClassId = user.CustClassId
                });
            }
            return Ok(usersDto);
        }

        /*[HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<UsersDto>> GetUser(string id)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            var userDto = new UsersDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Birthdate = user.Birthdate,
                ContactNo = user.ContactNo,
                Address = user.Address,
                isActive = user.isActive,
                CustClassId = user.CustClassId
            };
            return Ok(userDto);
        }*/

        [HttpGet("email/{email}")]
        [Authorize]
        public async Task<ActionResult<UsersDto>> GetUserByEmail(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return NotFound();
            }
            var userDto = new UsersDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Birthdate = user.Birthdate,
                ContactNo = user.ContactNo,
                Address = user.Address,
                isActive = user.isActive,
                CustClassId = user.CustClassId
            };
            return Ok(userDto);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<UsersDto>> CreateUser(UsersDto usersDto)
        {
            var user = new ApplicationUser
            {
                FirstName = usersDto.FirstName,
                LastName = usersDto.LastName,
                Birthdate = usersDto.Birthdate,
                ContactNo = usersDto.ContactNo,
                Address = usersDto.Address,
                isActive = usersDto.isActive,
                CustClassId = usersDto.CustClassId
            };
            var result = await _userManager.CreateAsync(user);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            return CreatedAtAction(nameof(GetUserByEmail), new { id = user.Id }, usersDto);
        }

        [HttpPut("{email}")]
        [Authorize]
        public async Task<IActionResult> UpdateUserByEmail(string email, UsersDto usersDto)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return NotFound();
            }
            user.FirstName = usersDto.FirstName;
            user.LastName = usersDto.LastName;
            user.Birthdate = usersDto.Birthdate;
            user.ContactNo = usersDto.ContactNo;
            user.Address = usersDto.Address;
            user.isActive = usersDto.isActive;
            user.CustClassId = usersDto.CustClassId;
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            return NoContent();
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateAccount(UsersDto usersDto)
        {
            // Get the user's information from the HttpContext
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            // Only allow the user to update their own account
            if (user.FirstName != usersDto.FirstName)
            {
                return Forbid();
            }

            // Update the user's information
            user.FirstName = usersDto.FirstName;
            user.LastName = usersDto.LastName;
            user.Birthdate = usersDto.Birthdate;
            user.ContactNo = usersDto.ContactNo;
            user.Address = usersDto.Address;

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return NoContent();
        }
    }
}
