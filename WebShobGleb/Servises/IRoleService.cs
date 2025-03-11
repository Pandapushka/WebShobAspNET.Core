using WebShobGleb.Areas.Admin.Models;

namespace WebShobGleb.Servises
{
    public interface IRoleService
    {
        List<RoleVM> GetAllRoles();
        void RemoveRole(Guid roleId);
        void AddRole(RoleVM role);
    }
}
