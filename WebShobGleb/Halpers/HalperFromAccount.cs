using WebShobGleb.Areas.Admin.Models;
using WebShobGleb.Models;

namespace WebShobGleb.Halpers
{
    public class HalperFromAccount
    {
        public static UserAccount FromRegister(UserRegistration user)
        {
            return new UserAccount()
            {
                Login = user.Login,
                Pasword = user.Password,
                Phone = user.Phone
            };
        }
    }
}
