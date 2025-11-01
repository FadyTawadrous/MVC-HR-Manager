using Microsoft.AspNetCore.Mvc;
using Tiers.BLL.Service.Abstraction;

namespace Tiers.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = await _departmentService.GetAllAsync();

            if (response.IsSuccess)
            {
                return View(response.Result); // Passes IEnumerable<GetDepartmentVM>
            }

            // Return an empty list on failure
            return View(new List<GetDepartmentVM>());
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (id <= 0) return BadRequest();

            var response = await _departmentService.GetByIdAsync(id);

            if (response.IsSuccess)
            {
                return View(response.Result); // Passes GetDepartmentVM
            }

            return NotFound();
        }

        // Get create view
        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateDepartmentVM());
        }

        // Create department
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateDepartmentVM model)
        {
            if (ModelState.IsValid)
            {
                var response = await _departmentService.CreateAsync(model);

                if (response.IsSuccess)
                {
                    TempData["SuccessMessage"] = "Department has been created successfully";
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, response.ErrorMessage);
            }

            return View(model);
        }

        // Get edit view
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id <= 0) return BadRequest();

            // Get the VM populated with department data
            var response = await _departmentService.GetUpdateModelAsync(id);

            if (response.IsSuccess)
            {
                return View(response.Result); // Passes UpdateDepartmentVM
            }

            return NotFound();
        }

        // Edit department
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateDepartmentVM model)
        {
            if (id != model.Id) return BadRequest();

            if (ModelState.IsValid)
            {
                var response = await _departmentService.UpdateAsync(model);

                if (response.IsSuccess)
                {
                    TempData["SuccessMessage"] = "Employee has been updated successfully";
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, response.ErrorMessage);
            }

            return View(model);
        }

        // Get delete view
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest();

            var response = await _departmentService.GetDeleteModelAsync(id);

            if (response.IsSuccess)
            {
                return View(response.Result); // Passes DeleteDepartmentVM
            }

            return NotFound();
        }

        // Delete department
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(DeleteDepartmentVM model)
        {
            var response = await _departmentService.DeleteAsync(model);

            if (response.IsSuccess)
            {
                TempData["SuccessMessage"] = "Department has been deleted successfully";
                return RedirectToAction(nameof(Index));
            }

            // If it failed, redisplay the confirmation page with an error
            ModelState.AddModelError(string.Empty, response.ErrorMessage);
            return View(model);
        }
    }
}
