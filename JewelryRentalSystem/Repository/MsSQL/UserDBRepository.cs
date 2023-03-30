using JewelryRentalSystem.Data;
using JewelryRentalSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace JewelryRentalSystem.Repository.MsSQL
{
    public class UserDBRepository : IUserDBRepository
    {
        private readonly JRSDBContext _JRSDBContext;
        public UserDBRepository(JRSDBContext jRSDBContext)
        {
            _JRSDBContext = jRSDBContext;
        }
        public User AddUser(User newUser)
        {
            throw new NotImplementedException();
        }

        public User DeleteUser(int UserId)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAllUsers()
        {
            return _JRSDBContext.Users.AsNoTracking().ToList();
        }

        public User GetUserById(int UserId)
        {
            throw new NotImplementedException();
        }

        public User UpdateUser(int UserId, User newUser)
        {
            throw new NotImplementedException();
        }
    }
}
