using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShopDB.Models;
using WebShobGleb.Areas.Admin.Models;
using System.Threading.Tasks;

namespace WebShobGleb.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public LoginController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // Отображение страницы входа
        public IActionResult Index()
        {
            return View(new UserEnter { });
        }

        // Обработка входа пользователя
        [HttpPost]
        public async Task<IActionResult> Enter(UserEnter user)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(user.Login, user.Password, user.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    // Перенаправление на returnUrl или на главную страницу
                    return Redirect("/Home/Index");
                }

                ModelState.AddModelError(string.Empty, "Неправильный логин или пароль");
            }

            // Если модель не валидна, возвращаем форму с ошибками
            return View("Index", user);
        }

        // Отображение страницы регистрации
        public IActionResult Registration()
        {
            return View(new UserRegistration {});
        }

        // Обработка регистрации нового пользователя
        [HttpPost]
        public async Task<IActionResult> AddNewUser(UserRegistration user)
        {
            if (user.Login == user.Password)
            {
                ModelState.AddModelError(string.Empty, "Логин и пароль не должны совпадать!");
            }

            if (ModelState.IsValid)
            {
                var newUser = new User
                {
                    Email = user.Login,
                    UserName = user.Login,
                    PhoneNumber = user.Phone
                };

                var result = await _userManager.CreateAsync(newUser, user.Password);
                if (result.Succeeded)
                {
                    // Автоматический вход после регистрации
                    await _signInManager.SignInAsync(newUser, isPersistent: false);

                    // Перенаправление на returnUrl или на главную страницу
                    return Redirect("/Home/Index");
                }

                // Добавление ошибок регистрации в ModelState
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // Если модель не валидна, возвращаем форму с ошибками
            return View("Registration", user);
        }

        // Выход пользователя
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}