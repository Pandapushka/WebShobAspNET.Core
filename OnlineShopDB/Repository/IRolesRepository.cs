using Core.Entity;
using OnlineShopDB.Repository.BaseRepository;

namespace OnlineShopDB.Repository
{
    public interface IRolesRepository : IRepository<Role>
    {
        Role TryGetByName(string name);
    }
}
