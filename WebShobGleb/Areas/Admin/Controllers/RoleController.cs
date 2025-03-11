using Microsoft.AspNetCore.Mvc;
using OnlineShopDB.Repository;
using WebShobGleb.Areas.Admin.Models;
using WebShobGleb.Mappers;
using WebShobGleb.Servises;

namespace WebShobGleb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public IActionResult Roles()
        {
            var roles = _roleService.GetAllRoles();
            return View(roles);
        }

        public IActionResult RemoveRole(Guid roleId)
        {
            _roleService.RemoveRole(roleId);
            return RedirectToAction("Roles");
        }

        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddRole(RoleVM role)
        {
            if (!ModelState.IsValid)
            {
                return View(role);
            }

            try
            {
                _roleService.AddRole(role);
                return RedirectToAction("Roles");
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(role);
            }
        }
    }
}
