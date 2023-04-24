using System.Collections.Generic;
using System.Threading.Tasks;
using JewelryRentalSystemAPI.DTO;
using JewelryRentalSystemAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JewelryRentalSystemAPI.Controllers
{
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

        [HttpDelete("{email}")]
        [Authorize]
        public async Task<IActionResult> DeleteUserByEmail(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return NotFound();
            }

            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return NoContent();
        }
    }
}
