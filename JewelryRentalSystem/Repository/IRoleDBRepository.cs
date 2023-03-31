using JewelryRentalSystem.Models;

namespace JewelryRentalSystem.Repository
{
    public interface IRoleDBRepository
    {
        List<Role> GetAllRoles();
        Role GetRoleById(int RoleId);

        Role AddRole(Role newRole);
        Role UpdateRole(int RoleId, Role newRole);
        Role DeleteRole(int RoleId);

    }
}
