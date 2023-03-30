using JewelryRentalSystem.Data;
using JewelryRentalSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace JewelryRentalSystem.Repository.MsSQL
{
    public class UserDBRepository : IUserDBRepository
    {
        JRSDBContext _JRSDBContext;
        public UserDBRepository(JRSDBContext jRSDBContext)
        {
            _JRSDBContext = jRSDBContext;
        }
        public User AddUser(User newUser)
        {
            _JRSDBContext.Add(newUser);
            _JRSDBContext.SaveChanges();
            return newUser;
        }

        public User DeleteUser(int UserId)
        {
            var user = GetUserById(UserId);
            if (user != null)
            {
                _JRSDBContext.Users.Remove(user);
                _JRSDBContext.SaveChanges();
            }
            return user;
        }

        public List<User> GetAllUsers()
        {
            return _JRSDBContext.Users.AsNoTracking().ToList();
        }

        public User GetUserById(int UserId)
        {
            return _JRSDBContext.Users.AsNoTracking().ToList().FirstOrDefault(x => x.UserId == UserId);
        }

        public User UpdateUser(int UserId, User newUser)
        {
            _JRSDBContext.Users.Update(newUser);
            _JRSDBContext.SaveChanges();
            return newUser;
        }
    }
}
