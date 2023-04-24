using JewelryRentalSystemAPI.DTO;
using JewelryRentalSystemAPI.Interface;
using JewelryRentalSystemAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace JewelryRentalSystemAPI.Repository
{
    public class AccountRepository : IAccountRepository
    {
        public UserManager<ApplicationUser> _userManager { get; }
        public SignInManager<ApplicationUser> _signInManager { get; }
        private readonly IServiceProvider _serviceProvider;

        public AccountRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IServiceProvider serviceProvider)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _serviceProvider = serviceProvider;
        }

        public async Task<IList<string>> GetUserRolesAsync(ApplicationUser user)
        {
            var userManager = _serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            return await userManager.GetRolesAsync(user);
        }


        public async Task<ApplicationUser> SignUpUserAsync(ApplicationUser user, string password)
        {
            var newUser = await _userManager.CreateAsync(user, password);
            if (newUser.Succeeded)
                return user;
            return null;
        }

        public async Task<SignInResult> SignInUserAsync(LogInDto logInDto)
        {
            var logInResult = await _signInManager.PasswordSignInAsync(logInDto.Email, logInDto.Password, logInDto.RememberMe, false);
            return logInResult;
        }

        public async Task<ApplicationUser> FindUserByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user;
        }
    }
}
