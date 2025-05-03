using Core.Entity;
using OnlineShopDB.Repository.BaseRepository;

namespace Core.Repository
{
    public interface IRolesRepository : IRepository<Role>
    {
        Role TryGetByName(string name);
    }
}
