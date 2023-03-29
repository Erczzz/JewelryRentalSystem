﻿namespace JewelryRentalSystem.Models
{
    public class Role
    {

        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public Role() { }
        public Role(int roleId, string roleName)
        {
            RoleId = roleId;
            RoleName = roleName;
        }
    }
}
