using OnlineShopDB.Repository;
using WebShobGleb.Areas.Admin.Models;
using WebShobGleb.Mappers;

namespace WebShobGleb.Servises
{
    public class RoleService : IRoleService
    {
        private readonly IRolesRepository _rolesRepository;

        public RoleService(IRolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository;
        }

        public List<RoleVM> GetAllRoles()
        {
            var roles = _rolesRepository.GetAll();
            return RoleMapper.MapToRoleVMList(roles);
        }

        public void RemoveRole(Guid roleId)
        {
            _rolesRepository.Delete(roleId);
        }

        public void AddRole(RoleVM role)
        {
            if (_rolesRepository.TryGetByName(role.Name) != null)
            {
                throw new InvalidOperationException("Такая роль уже существует!");
            }

            _rolesRepository.Add(RoleMapper.MapToRole(role));
        }
    }
}
