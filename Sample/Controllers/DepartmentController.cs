﻿using Microsoft.AspNetCore.Mvc;
using Sample.Interface;
using Sample.ViewModel;

namespace Sample.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _Departmentrepository;
        public DepartmentController(IDepartmentRepository Departmentrepository) {
        
            _Departmentrepository = Departmentrepository;
        }
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

        public IActionResult ViewDepartment()
        {
            return View();
        }
    }
}