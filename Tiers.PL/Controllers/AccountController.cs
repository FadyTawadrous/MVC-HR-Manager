//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Tiers.BLL.ModelVM.Account;
//using Tiers.DAL.Entity;

//namespace Tiers.PL.Controllers
//{
//    public class AccountController : Controller
//    {
//        private readonly UserManager<Employee> _userManager;
//        private readonly SignInManager<Employee> _signInManager;

//        public AccountController(UserManager<Employee> userManager, SignInManager<Employee> signInManager)
//        {
//            _userManager = userManager;
//            _signInManager = signInManager;
//        }

//        [HttpGet]
//        public async Task<IActionResult> Register()
//        {
//            return View();
//        }

//        [HttpPost]
//        public async Task<IActionResult> Register(RegisterEmployeeVM model)
//        {
//            if (ModelState.IsValid)
//            {
//                var user = new Employee(model.Name, model.Salary, 20, string.Empty, 1, "Fady")
//                {
//                };

//                var result = await _userManager.CreateAsync(user, model.Password);
//                await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
//                if (result.Succeeded)
//                {
//                    return RedirectToAction("Login");
//                }
//                foreach (var error in result.Errors)
//                {
//                    ModelState.AddModelError("", error.Description);
//                }
//            }
//            return View(model);
//        }

//        [Authorize]
//        public IActionResult Index()
//        {
//            return View();
//        }
//    }
//}
