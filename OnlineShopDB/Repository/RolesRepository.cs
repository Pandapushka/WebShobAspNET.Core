using Core.Entity;

namespace OnlineShopDB.Repository
{
    public class RolesRepository : BaseRepository<Role>, IRolesRepository
    {
        public RolesRepository(DataBaseContext context)
            : base(context)
        {
        }

        public Role TryGetByName(string name)
        {
            return _context.Roles.FirstOrDefault(x => x.Name.ToUpper().Trim() == name.ToUpper().Trim());
        }
    }
}
