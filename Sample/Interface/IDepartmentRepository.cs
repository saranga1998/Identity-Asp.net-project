using Sample.ViewModel;

namespace Sample.Interface
{
    public interface IDepartmentRepository
    {

        Task AddDepartment(DepartmentViewModel Department);
    }
}
