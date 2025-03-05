using WebShobGleb.Areas.Admin.Models;

namespace WebShobGleb.Repository
{
    public interface IRolesRepository
    {
        List<Role> GetAll();
        Role TryGetByName(string Name);
        void Add(Role role);
        void Remove(Guid roleId);
    }
}
