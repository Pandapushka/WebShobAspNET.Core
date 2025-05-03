using Application.DTOs;
using Core.Entity;

namespace Application.Mappers
{
    public class RoleMapperDTO
    {
        public static RoleDTO MapToRoleDTO(Role role)
        {
            if (role == null)
                return null;

            return new RoleDTO
            {
                Id = role.Id,
                Name = role.Name
            };
        }

        // Маппинг из RoleVM в Role
        public static Role MapToRole(RoleDTO roleDTO)
        {
            if (roleDTO == null)
                return null;

            return new Role
            {
                Id = roleDTO.Id,
                Name = roleDTO.Name
            };
        }

        // Маппинг списка Role в список RoleVM
        public static List<RoleDTO> MapToRoleDTOList(List<Role> roles)
        {
            if (roles == null)
                return null;

            return roles.Select(role => MapToRoleDTO(role)).ToList();
        }

        // Маппинг списка RoleVM в список Role
        public static List<Role> MapToRoleList(List<RoleDTO> roleDTOs)
        {
            if (roleDTOs == null)
                return null;

            return roleDTOs.Select(roleVM => MapToRole(roleVM)).ToList();
        }
    }
}
