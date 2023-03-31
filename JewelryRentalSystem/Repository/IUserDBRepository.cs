using JewelryRentalSystem.Models;

namespace JewelryRentalSystem.Repository
{
    public interface IUserDBRepository
    {
        List<User> GetAllUsers();
        User GetUserById(int UserId);
        User AddUser(User newUser);
        User UpdateUser(int userID, User newUser);
        User DeleteUser(int userID);
    }
}
