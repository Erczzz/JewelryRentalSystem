using JewelryRentalSystem.Data;
using JewelryRentalSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace JewelryRentalSystem.Repository.MsSQL
{
    public class RoleDBRepository : IRoleDBRepository
    {
        private readonly JRSDBContext _JRSDBContext;
        public RoleDBRepository(JRSDBContext jRSDBContext)
        {
            _JRSDBContext = jRSDBContext;
        }

        public Role AddRole(Role newRole)
        {
            _JRSDBContext.Add(newRole);
            _JRSDBContext.SaveChanges();
            return newRole;
        }

        public Role DeleteRole(int RoleId)
        {
            throw new NotImplementedException();
        }

        public List<Role> GetAllRoles()
        {
            return _JRSDBContext.Roles.AsNoTracking().ToList();
        }

        public Role GetRoleById(int RoleId)
        {
            throw new NotImplementedException();
        }

        public Role UpdateRole(int RoleId, Role role)
        {
            throw new NotImplementedException();
        }
    }
}
