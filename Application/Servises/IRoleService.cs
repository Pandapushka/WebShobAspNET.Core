using Application.DTOs;

namespace Application.Servises
{
    public interface IRoleService
    {
        List<RoleDTO> GetAllRoles();
        void RemoveRole(Guid roleId);
        void AddRole(RoleDTO role);
    }
}
