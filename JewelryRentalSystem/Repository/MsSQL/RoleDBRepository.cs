using JewelryRentalSystem.Data;
using JewelryRentalSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace JewelryRentalSystem.Repository.MsSQL
{
    public class RoleDBRepository : IRoleDBRepository
    {
        private readonly JRSDBContext _JRSDbContext;

        public RoleDBRepository(JRSDBContext JRSDbContext)
        {
            _JRSDbContext = JRSDbContext;
        }

        public async Task<Role?> AddRole(Role Role)
        {
            await _JRSDbContext.Roles.AddAsync(Role);
            await _JRSDbContext.SaveChangesAsync();
            return Role;
        }

        public async Task<Role?> DeleteRole(int RoleId)
        {
            var oldRole = await GetRoleById(RoleId);
            if (oldRole != null)
            {
                _JRSDbContext.Roles.Remove(oldRole);
                _JRSDbContext.SaveChanges();
                return oldRole;
            }
            return null;
        }

        public async Task<List<Role>> GetAllRoles()
        {
            return await _JRSDbContext.Roles.ToListAsync();
        }

        public async Task<Role?> GetRoleById(int? RoleId)
        {
            return await _JRSDbContext.Roles.AsNoTracking().FirstOrDefaultAsync(x => x.RoleId == RoleId);
        }

        public async Task<Role?> UpdateRole(int RoleId, Role Role)
        {
            _JRSDbContext.Roles.Update(Role);
            await _JRSDbContext.SaveChangesAsync();
            return Role;
        }
    }
}
