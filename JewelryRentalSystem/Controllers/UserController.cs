using JewelryRentalSystem.Data;
using JewelryRentalSystem.Models;
using JewelryRentalSystem.Repository;
using JewelryRentalSystem.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace JewelryRentalSystem.Controllers
{
    public class UserController : Controller
    {

        IUserDBRepository _userRepository;
        IRoleDBRepository _roleRepository;

        public UserController(IUserDBRepository userRepository, IRoleDBRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public async Task<IActionResult> GetAllUsers()
        {
            return View(await _userRepository.GetAllUsers());
        }

        //READ EMPLOYEE

        public async Task<IActionResult> Details(int? UserId)
        {
            if (UserId == null)
            {
                return NotFound();
            }

            var employee = await _userRepository.GetUserById(UserId);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        //CREATE EMPLOYEE

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            CreateUserViewModel createUserViewModel = new CreateUserViewModel
            {
                Roles = await _roleRepository.GetAllRoles()
            };

            return View(createUserViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateUserViewModel createUserViewModel)
        {
            createUserViewModel.Roles = await _roleRepository.GetAllRoles();

            if (ModelState.IsValid)
            {
                User newUser = new User
                {
                    FirstName = createUserViewModel.NewUser.FirstName,
                    LastName = createUserViewModel.NewUser.LastName,
                    BirthDate = createUserViewModel.NewUser.Birthdate,
                    ContactNo = createUserViewModel.NewUser.ContactNo,
                    Email = createUserViewModel.NewUser.Email,
                    Address = createUserViewModel.NewUser.Address,
                    Username = createUserViewModel.NewUser.Username,
                    RoleId = createUserViewModel.NewUser.RoleId
                };

                await _userRepository.AddUser(newUser);
                return RedirectToAction(nameof(GetAllUsers));
            }
            return View(createUserViewModel);
        }

        //DELETE EMPLOYEE

        public async Task<IActionResult> Delete(int? UserId)
        {
            if (UserId == null)
            {
                return NotFound();
            }

            var user = await _userRepository.GetUserById(UserId);
            
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int UserId)
        {
            if (_userRepository.GetAllUsers() == null)
            {
                return Problem("Entity set 'SampleDBContext.Users'  is null.");
            }

            var user = await _userRepository.GetUserById(UserId);

            if (_userRepository is null)
            {
                return NotFound();
            }

            await _userRepository.DeleteUser(user.UserId);
            return RedirectToAction(nameof(GetAllUsers));
        }

        //UPDATE EMPLOYEE

        [HttpGet]
        public IActionResult Update(int UserId)
        {
            var oldUser = _userRepository.GetUserById(UserId);
            return View(oldUser);
        }

        [HttpPost]
        public IActionResult Update(User newUser)
        {
            var user = _userRepository.UpdateUser(newUser.UserId, newUser);
            return RedirectToAction("GetAllUsers");
        }

    }
}
