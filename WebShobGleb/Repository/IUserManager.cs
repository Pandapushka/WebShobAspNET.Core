using WebShobGleb.Areas.Admin.Models;
using WebShobGleb.Models;

namespace WebShobGleb.Repository
{
    public interface IUserManager
    {
        List<UserAccount> GetAll();
        void Add(UserAccount user);
        UserAccount TryGetByName(string name);
        void ChangePassword(ChangePassword changePassword);
        void Delete(Guid id);
    }
}
