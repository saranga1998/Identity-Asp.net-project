using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sample.Interface;
using Sample.Models;
using Sample.Repository;
using Sample.ViewModel;

namespace Sample.Controllers
{
    //[Authorize]
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ILogger<StudentController> _logger;
        public StudentController(IStudentRepository studentRepository, ILogger<StudentController> logger)
        {
            _studentRepository = studentRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> AddStudent()
        {
            var departments = await _studentRepository.GetallDepartment();
            ViewBag.Departments = new SelectList(departments, "DepartmentId", "Name");
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> AddStudent(StudentViewModel student)
        {
            try
            {
                await _studentRepository.AddStudent(student);
                return RedirectToAction("AddStudent", "Student");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Something Worng.Check Again !");
                return View();
            }
            
        }

        [HttpGet]

        public async Task<IActionResult> ViewAllStudents()
        {
            var AllStudents = await _studentRepository.ViewAllStudents();

            var ViewModel = new CompositeViewModel
            {
                Students = AllStudents
            };

            return View(ViewModel);
        }

        [HttpGet]

        public async Task<IActionResult> EditStudent(int id)
        {
            var editStudent = await _studentRepository.StudentGetById(id);
            return View(editStudent);
        }

        [HttpPost]
        public async Task<IActionResult> EditStudent(StudentViewModel update)
        {
            try
            {
                await _studentRepository.UpdateStudent(update);
                TempData["SuccessMessage"] = "Student successfully Updated.";
                return RedirectToAction("ViewAllStudents", "Student");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Something Worng.Check Again !");
                return View();
            }
        }

        [HttpGet]

        public async Task<IActionResult> DeleteStudent(int stuId)
        {
            var student = await _studentRepository.StudentGetById(stuId);
            if (student == null)
            {
                TempData["ErrorMessage"] = "Student not found.";
                return RedirectToAction("ViewAllStudents", "Student");
            }
            return View(student);
        }

        [HttpGet]

        public async Task<IActionResult> DeleteStudentConfirm(int stuId)
        {
            try
            {
                await _studentRepository.DeleteStudent(stuId);
                TempData["SuccessMessage"] = "Studnet successfully deleted.";
                return RedirectToAction("ViewAllStudents", "Student");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Something Worng.Check Again !");
                TempData["ErrorMessage"] = "An error occurred while deleting the Student. Please try again.";
                return View();
            }
        }
    }
}
