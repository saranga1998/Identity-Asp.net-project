using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sample.Interface;
using Sample.Models;
using Sample.ViewModel;

namespace Sample.Controllers
{
    [Authorize]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _Departmentrepository;
        private readonly ILogger<DepartmentController> _logger;
        
        public DepartmentController(IDepartmentRepository Departmentrepository,ILogger <DepartmentController> logger) {
        
            _Departmentrepository = Departmentrepository;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult AddDepartment()
        {
            return View();
        }


        //Add department post method
        [HttpPost]
        public async Task<IActionResult> AddDepartment(DepartmentViewModel department)
        {
            try
            {
                await _Departmentrepository.AddDepartment(department);
                return RedirectToAction("AddDepartment", "Department");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Something Worng.Check Again !");
                return View();
            }
            
        }



        //View All Departments get method
        [HttpGet]
        public async Task<IActionResult> ViewDepartment()
        {
            var AllDepartments = await _Departmentrepository.ViewAllDepartment();
            var Viewmodel = new CompositeViewModel
            {
                Departments = AllDepartments
            };
            return View(Viewmodel);
            
            
        }

        [HttpGet]
        public async Task<IActionResult> EditDepartment(int DepatmentId) 
        {
            var EditDepartment = await _Departmentrepository.DepatmentGetById(DepatmentId);
            return View(EditDepartment);
            
        }

        [HttpPost]

        public async Task<IActionResult> EditDepartment(DepartmentViewModel update)
        {
            try
            {
                await _Departmentrepository.UpdateDepartment(update);
                TempData["SuccessMessage"] = "Department successfully Updated.";
                return RedirectToAction("ViewDepartment", "Department");
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Something Worng.Check Again !");
                return View();
            }

            
        }
        [HttpGet]
        public async Task<IActionResult> DeleteDepartment(int DepatmentId)
        {
            var department = await _Departmentrepository.DepatmentGetById(DepatmentId);

            if (department == null)
            {
                TempData["ErrorMessage"] = "Department not found.";
                return RedirectToAction("ViewDepartment", "Department");
            }

            return View(department);
        }

        [HttpGet]

        public async Task<IActionResult> DeleteDepartmentConform(int DepatmentId)
        {
            try
            {
                await _Departmentrepository.DeleteDepartment(DepatmentId);
                TempData["SuccessMessage"] = "Department successfully deleted.";
                return RedirectToAction("ViewDepartment", "Department");
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Something Worng.Check Again !");
                TempData["ErrorMessage"] = "An error occurred while deleting the department. Please try again.";
                return View();
            }
        }
    }
}
