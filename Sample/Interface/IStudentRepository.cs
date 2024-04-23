using Sample.ViewModel;

namespace Sample.Interface
{
    public interface IStudentRepository
    {

        Task AddStudent(StudentViewModel student);
    }
}
