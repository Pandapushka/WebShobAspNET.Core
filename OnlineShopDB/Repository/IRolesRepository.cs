using OnlineShopDB.Models;

namespace OnlineShopDB.Repository
{
    public interface IRolesRepository
    {
        List<Role> GetAll();
        Role TryGetByName(string Name);
        void Add(Role role);
        void Remove(Guid roleId);
    }
}
