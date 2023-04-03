using MessagePack;
using System.ComponentModel.DataAnnotations;

namespace JewelryRentalSystem.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public List<User> Users { get; set; }

        //public Role() 
        //{ 
        //}
        //public Role(int roleId, string roleName)
        //{
        //    RoleId = roleId;
        //    RoleName = roleName;
        //}
    }
}
