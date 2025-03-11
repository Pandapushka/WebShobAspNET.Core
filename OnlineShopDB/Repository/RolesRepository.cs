using OnlineShopDB.Models;

namespace OnlineShopDB.Repository
{
    public class RolesRepository : IRolesRepository
    {
        private readonly DataBaseContext _context;
        public RolesRepository(DataBaseContext context)
        {
            _context = context;
        }
        public void Add(Role role)
        {
            _context.Roles.Add(role);
            _context.SaveChanges();
        }

        public List<Role> GetAll()
        {
            return _context.Roles.ToList();
        }

        public Role TryGetByName(string name)
        {
            return _context.Roles.FirstOrDefault(x => x.Name.ToUpper().Trim() == name.ToUpper().Trim());
        }

        public void Remove(Guid roleId)
        {
            var role = _context.Roles.FirstOrDefault(x => x.Id == roleId);
            _context.Roles.Remove(role);
            _context.SaveChanges();
        }
    }
}
