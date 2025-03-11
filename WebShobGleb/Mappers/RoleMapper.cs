using OnlineShopDB.Models;
using WebShobGleb.Areas.Admin.Models;

namespace WebShobGleb.Mappers
{
    public class RoleMapper
    {
        public static RoleVM MapToRoleVM(Role role)
        {
            if (role == null)
                return null;

            return new RoleVM
            {
                Id = role.Id,
                Name = role.Name
            };
        }

        // Маппинг из RoleVM в Role
        public static Role MapToRole(RoleVM roleVM)
        {
            if (roleVM == null)
                return null;

            return new Role
            {
                Id = roleVM.Id,
                Name = roleVM.Name
            };
        }

        // Маппинг списка Role в список RoleVM
        public static List<RoleVM> MapToRoleVMList(List<Role> roles)
        {
            if (roles == null)
                return null;

            return roles.Select(role => MapToRoleVM(role)).ToList();
        }

        // Маппинг списка RoleVM в список Role
        public static List<Role> MapToRoleList(List<RoleVM> roleVMs)
        {
            if (roleVMs == null)
                return null;

            return roleVMs.Select(roleVM => MapToRole(roleVM)).ToList();
        }
    }
}
