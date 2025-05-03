using Core.Entity;
using Core.Repository.BaseRepository;

namespace Core.Repository
{
    public interface IRolesRepository : IRepository<Role>
    {
        Role TryGetByName(string name);
    }
}
