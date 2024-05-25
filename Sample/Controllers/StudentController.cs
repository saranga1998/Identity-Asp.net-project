using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sample.Interface;
using Sample.Repository;
using Sample.ViewModel;

namespace Sample.Controllers
{
    [Authorize]
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
        public IActionResult AddStudent()
        {
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
                TempData["SuccessMessage"] = "Department successfully Updated.";
                return RedirectToAction("ViewAllStudent", "Student");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Something Worng.Check Again !");
                return View();
            }
        }
    }
}
