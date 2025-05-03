using Core.Repository;
using Application.DTOs;
using Application.Mappers;


namespace Application.Servises
{
    public class RoleService : IRoleService
    {
        private readonly IRolesRepository _rolesRepository;

        public RoleService(IRolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository;
        }

        public List<RoleDTO> GetAllRoles()
        {
            var roles = _rolesRepository.GetAll();
            return RoleMapperDTO.MapToRoleDTOList(roles);
        }

        public void RemoveRole(Guid roleId)
        {
            _rolesRepository.Delete(roleId);
        }

        public void AddRole(RoleDTO role)
        {
            if (_rolesRepository.TryGetByName(role.Name) != null)
            {
                throw new InvalidOperationException("Такая роль уже существует!");
            }

            _rolesRepository.Add(RoleMapperDTO.MapToRole(role));
        }
    }
}
