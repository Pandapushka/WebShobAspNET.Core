using Microsoft.AspNetCore.Mvc;
using WebShobGleb.Areas.Admin.Models;
using WebShobGleb.Halpers;
using WebShobGleb.Repository;

namespace WebShobGleb.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserManager usersManager;

        public LoginController(IUserManager usersManager)
        {
            this.usersManager = usersManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Enter(UserEnter user)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", user);
            }
            var userAccount = usersManager.TryGetByName(user.Login);
            if (userAccount == null)
            {
                ModelState.AddModelError("", "Такого пользователя не существует!");
                return View("Index", user);
            }
            if (userAccount.Pasword != user.Password)
            {
                ModelState.AddModelError("", "Не верный пароль!");
                return View("Index", user);
            }
            return RedirectToAction("Index", "Home");


        }
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNewUser(UserRegistration user)
        {
            if (user.Login == user.Password)
            {
                ModelState.AddModelError("", "Логин и пароль не должны совпадать!");
            }
            if (ModelState.IsValid)
            {
                usersManager.Add(HalperFromAccount.FromRegister(user));
                return RedirectToAction("Index", "Home");
            }
            return View("Registration", user);
        }
    }
}
