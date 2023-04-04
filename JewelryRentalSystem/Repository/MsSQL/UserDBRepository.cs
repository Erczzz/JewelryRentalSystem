/*using JewelryRentalSystem.Data;
using JewelryRentalSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace JewelryRentalSystem.Repository.MsSQL
{
    public class UserDBRepository : IUserDBRepository
    {
        private readonly JRSDBContext _JRSDbContext;
        public UserDBRepository(JRSDBContext JRSDBContext)
        {
            _JRSDbContext = JRSDBContext;
        }
        public async Task<User?> AddUser(User User)
        {
            await _JRSDbContext.AddAsync(User);
            await _JRSDbContext.SaveChangesAsync();
           
            return User;
        }

        public async Task<User?> DeleteUser(int UserId)
        {
            var user = await GetUserById(UserId);
            if (user != null)
            {
                _JRSDbContext.Users.Remove(user);
                await _JRSDbContext.SaveChangesAsync();
                return user;
            }
            return null;
        }


        public async Task<List<User>> GetAllUsers()
        {
            return await _JRSDbContext.Users.Include(x => x.Roles).ToListAsync();
        }

        public async Task<User?> GetUserById(int? UserId)
        {
            return await _JRSDbContext.Users
            .AsNoTracking()
            .Include(e => e.Roles)
            .SingleOrDefaultAsync(x => x.UserId == UserId);
        }

        public async Task<User?> UpdateUser(int UserId, User User)
        {
            _JRSDbContext.Users.Update(User);
            await _JRSDbContext.SaveChangesAsync();
            return User;
        }
    }
}
*/