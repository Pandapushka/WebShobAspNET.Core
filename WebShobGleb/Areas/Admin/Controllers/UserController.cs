using Microsoft.AspNetCore.Mvc;
using WebShobGleb.Areas.Admin.Models;
using WebShobGleb.Repository;

namespace WebShobGleb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUserManager userManager;
        public UserController(IUserManager usersManager)
        {
            this.userManager = usersManager;
        }
        public IActionResult Users()
        {
            var userAccount = userManager.GetAll();
            return View(userAccount);
        }
        public IActionResult Details(string name)
        {
            var user = userManager.TryGetByName(name);
            return View(user);
        }
        public IActionResult ChangePassword(string name)
        {
            var changePassword = new ChangePassword()
            {
                Name = name
            };
            return View(changePassword);
        }
        [HttpPost]
        public IActionResult ChangePassword(ChangePassword changePassword)
        {
            var user = userManager.TryGetByName(changePassword.Name);
            if (user.Pasword == changePassword.Password)
            {
                ModelState.AddModelError("", "Старый и новый пароль не должны совпадать!");
            }
            if (changePassword.Name == changePassword.Password)
            {
                ModelState.AddModelError("", "Логин и пароль не должны совпадать!");
            }
            if (ModelState.IsValid)
            {
                userManager.ChangePassword(changePassword);
                return RedirectToAction("Users");
            }
            return View("ChangePassword", changePassword);

        }
        public IActionResult Delete(Guid id)
        {
            userManager.Delete(id);
            return RedirectToAction("Users");
        }

    }
}
