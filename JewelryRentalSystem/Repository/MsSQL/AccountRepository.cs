using JewelryRentalSystem.Models;
using JewelryRentalSystem.Services;
using JewelryRentalSystem.ViewModels;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Identity;

namespace JewelryRentalSystem.Repository.MsSQL
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserService _userService;

        public AccountRepository(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, IUserService userService,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userService = userService;
            _roleManager = roleManager;
        }

/*        public async Task<ApplicationUser> GetUserByEmailAsync(string email)
        {
            _userManager.CreateAsync
        }
*/
        public async Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel)
        {
            var user = new ApplicationUser()
            {
                FirstName = userModel.FirstName, 
                LastName = userModel.LastName,
                Birthdate = userModel.Birthdate,
                ContactNo = userModel.ContactNo,
                Address = userModel.Address,
                Email = userModel.Email,
                UserName = userModel.Email
            };
            var result = await _userManager.CreateAsync(user, userModel.Password);
            await _userManager.AddToRoleAsync(user, "Customer");
            return result;
        }

        public async Task<SignInResult> PasswordSignInAsync(SignInModel signInModel)
        {
            return await _signInManager.PasswordSignInAsync(signInModel.Email, signInModel.Password, signInModel.RememberMe, false);

        }
        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> ChangePasswordAsync(ChangePasswordModel model)
        {
            var userId = _userService.GetUserId();
            var user = await _userManager.FindByIdAsync(userId);
            return await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
        }
    }
}
