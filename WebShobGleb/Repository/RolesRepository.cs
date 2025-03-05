using WebShobGleb.Areas.Admin.Models;

namespace WebShobGleb.Repository
{
    public class RolesRepository : IRolesRepository
    {
        private readonly List<Role> roles = new List<Role>();
        public void Add(Role role)
        {
            roles.Add(role);
        }

        public List<Role> GetAll()
        {
            return roles;
        }

        public Role TryGetByName(string name)
        {
            return roles.FirstOrDefault(x => x.Name.ToUpper().Trim() == name.ToUpper().Trim());
        }

        public void Remove(Guid roleId)
        {
            roles.RemoveAll(x => x.Id == roleId);
        }
    }
}
