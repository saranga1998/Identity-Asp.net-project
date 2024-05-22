using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sample.Interface;
using Sample.Models;
using Sample.ViewModel;

namespace Sample.Controllers
{
    //[Authorize]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _Departmentrepository;
        
        public DepartmentController(IDepartmentRepository Departmentrepository) {
        
            _Departmentrepository = Departmentrepository;
        }

        [HttpPost]
        public IActionResult AddDepartment()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> AddDepartment(DepartmentViewModel department)
        {
            await _Departmentrepository.AddDepartment(department);
            return RedirectToAction("AddDepartment", "Department");
        }

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
    }
}
