using Microsoft.AspNetCore.Mvc;
using WebShobGleb.Areas.Admin.Models;
using WebShobGleb.Repository;

namespace WebShobGleb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly IRolesRepository _rolesRepository;

        public RoleController(IRolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository;
        }
        public IActionResult Roles()
        {
            var roles = _rolesRepository.GetAll();
            return View(roles);
        }
        public IActionResult RemoveRole(Guid roleId)
        {
            _rolesRepository.Remove(roleId);
            return RedirectToAction("Roles");
        }
        public IActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddRole(Role role)
        {
            if (_rolesRepository.TryGetByName(role.Name) != null)
            {
                ModelState.AddModelError("", "Такая роль уже существует!");
            }
            if (ModelState.IsValid)
            {
                _rolesRepository.Add(role);
                return RedirectToAction("Roles");
            }
            return View(role);
        }
    }
}
