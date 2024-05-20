using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sample.Interface;
using Sample.ViewModel;

namespace Sample.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        private readonly IStudentRepository studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public IActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> AddStudent(StudentViewModel student)
        {
            await studentRepository.AddStudent(student);
            return RedirectToAction("AddStudent", "Student");
        }


    }
}
