using JewelryRentalSystem.Data;
using JewelryRentalSystem.Models;
using JewelryRentalSystem.Repository;
using JewelryRentalSystem.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JewelryRentalSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JRSDBContext _context;

        public AccountController(IAccountRepository accountRepository,
            UserManager<ApplicationUser> userManager , JRSDBContext context)
        {
            _accountRepository = accountRepository;
            _userManager = userManager;
            _context = context;
        }
        [Route("signup")]
        public IActionResult SignUp()
        {
            return View();
        }

        [Route("signup")]
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpUserModel userModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountRepository.CreateUserAsync(userModel);
                if(!result.Succeeded)
                {
                    foreach(var errorMessage in result.Errors)
                    {
                        ModelState.AddModelError("", errorMessage.Description);
                    }
                    return View(userModel);
                }
                else
                {
                    return View("Login");
                }
            }
            return View();
        }

        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(SignInModel signInModel)
        {
            if(ModelState.IsValid)
            {
                var result = await _accountRepository.PasswordSignInAsync(signInModel);
                var user = await _userManager.FindByEmailAsync(signInModel.Email);
                if (result.Succeeded)
                {
                    if (user.isActive == false)
                    {
                        user.isActive = true;
                        var updatedUser = await _userManager.UpdateAsync(user);
                        return RedirectToAction("DeactivatedAccountWelcomePage");
                    }


                    else
                    {
                        return RedirectToAction("GetAllProducts", "Product");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Credentials");
                }
                

            }
            
            return View();
        }

        public async Task<IActionResult> DeactivatedAccountWelcomePage()
        {
            return View();
        }

        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await _accountRepository.SignOutAsync();
            return RedirectToAction("GetAllProducts", "Product");
        }

        [Route("change-password")]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountRepository.ChangePasswordAsync(model);
                if (result.Succeeded)
                {
                    ViewBag.IsSuccess = true;
                    ModelState.Clear();
                    return View();
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Profile()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction(controllerName: "Account", actionName: "Login");
            }
            var viewModel = new ProfileViewModel
            {
                CustomerId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Birthdate = user.Birthdate,
                ContactNo = user.ContactNo,
                Address = user.Address
            };
            return View(viewModel);
        }

        public async Task<IActionResult> DeactivateConfirmed()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Deactivate()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user != null)
            {
                user.isActive = false;
                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    await _accountRepository.SignOutAsync();
                    return RedirectToAction("GetAllProducts", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Error deactivating account.");
                }
            }
            else
            {
                ModelState.AddModelError("", "User not found.");
            }

            return View();
        }

    }
}
