using WebShobGleb.Areas.Admin.Models;
using WebShobGleb.Models;

namespace WebShobGleb.Repository
{
    public class UserManager : IUserManager
    {
        private readonly List<UserAccount> users = new List<UserAccount>();

        public List<UserAccount> GetAll()
        {
            return users;
        }

        public void Add(UserAccount user)
        {
            users.Add(user);
        }
        public UserAccount TryGetByName(string name)
        {
            return users.FirstOrDefault(x => x.Login == name);
        }
        public void ChangePassword(ChangePassword changePassword)
        {
            var user = TryGetByName(changePassword.Name);
            user.Pasword = changePassword.Password;
        }

        public void Delete(Guid id)
        {
            var user = users.FirstOrDefault(x => x.Id == id);
            users.Remove(user);
        }
    }
}
