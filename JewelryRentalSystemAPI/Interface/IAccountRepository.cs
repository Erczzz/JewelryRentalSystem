using JewelryRentalSystemAPI.DTO;
using JewelryRentalSystemAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace JewelryRentalSystemAPI.Interface
{
    public interface IAccountRepository
    {
        Task<ApplicationUser> SignUpUserAsync(ApplicationUser user, string password);
        Task<SignInResult> SignInUserAsync(LogInDto logInDto);
        Task<ApplicationUser> FindUserByEmailAsync(string email);

    }
}
