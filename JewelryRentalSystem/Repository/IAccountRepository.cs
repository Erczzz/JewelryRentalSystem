using JewelryRentalSystem.Models;
using JewelryRentalSystem.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace JewelryRentalSystem.Repository
{
    public interface IAccountRepository
    {
        Task <IdentityResult> CreateUserAsync(SignUpUserModel userModel);
        Task<SignInResult> PasswordSignInAsync(SignInModel signInModel);
        Task SignOutAsync();
        Task<IdentityResult> ChangePasswordAsync(ChangePasswordModel model);
        IEnumerable<ApplicationUser> GetUsers();
        Task<ApplicationUser> UpdateCustomerClassIdAsync(string userId, int customerClassId);
    }
}