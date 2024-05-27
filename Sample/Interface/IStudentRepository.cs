using Sample.Models;
using Sample.ViewModel;

namespace Sample.Interface
{
    public interface IStudentRepository
    {

        Task AddStudent(StudentViewModel student);

        Task<List<StudentViewModel>> ViewAllStudents();

        Task<StudentViewModel> StudentGetById(int id);

        Task UpdateStudent(StudentViewModel student);

        Task DeleteStudent(int id);

        Task<List<Models.Department>> GetallDepartment();
    }
}
