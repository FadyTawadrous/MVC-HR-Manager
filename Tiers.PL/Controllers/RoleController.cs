using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Tiers.BLL.ModelVM.Role;
using Tiers.DAL.Entity;

namespace Tiers.PL.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoleVM roleVM)
        {

            var getRoleByName = await _roleManager.FindByNameAsync(roleVM.Name); //Admin
            if (getRoleByName is not { })
            {
                var role = new IdentityRole() { Name = roleVM.Name };
                var result = await _roleManager.CreateAsync(role);
                return RedirectToAction("Index");
            }
            return View(roleVM);
        }
    }
}
