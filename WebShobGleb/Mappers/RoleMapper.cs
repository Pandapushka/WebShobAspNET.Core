using Application.DTOs;
using WebShobGleb.Areas.Admin.Models;

namespace WebShobGleb.Mappers
{
    public static class RoleMapper
    {
        // RoleDTO -> RoleVM
        public static RoleVM MapToRoleVM(RoleDTO roleDTO)
        {
            if (roleDTO == null)
                return null;

            return new RoleVM
            {
                Id = roleDTO.Id,
                Name = roleDTO.Name
            };
        }

        // RoleVM -> RoleDTO
        public static RoleDTO MapToRoleDTO(RoleVM roleVM)
        {
            if (roleVM == null)
                return null;

            return new RoleDTO
            {
                Id = roleVM.Id,
                Name = roleVM.Name
            };
        }

        // List<RoleDTO> -> List<RoleVM>
        public static List<RoleVM> MapToRoleVMList(List<RoleDTO> roleDTOs)
        {
            if (roleDTOs == null)
                return new List<RoleVM>();

            return roleDTOs.Select(MapToRoleVM).ToList();
        }

        // List<RoleVM> -> List<RoleDTO>
        public static List<RoleDTO> MapToRoleDTOList(List<RoleVM> roleVMs)
        {
            if (roleVMs == null)
                return new List<RoleDTO>();

            return roleVMs.Select(MapToRoleDTO).ToList();
        }
    }
}