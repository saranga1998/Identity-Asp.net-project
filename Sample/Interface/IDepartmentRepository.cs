using Sample.ViewModel;

namespace Sample.Interface
{
    public interface IDepartmentRepository
    {

        Task AddDepartment(DepartmentViewModel Department);
        Task  <List<DepartmentViewModel>> ViewAllDepartment();

        Task<DepartmentViewModel> DepatmentGetById(int id);

        Task UpdateDepartment(DepartmentViewModel Department);
        //Task<List<ZoneViewModel>> GetAllAsync();

       
    }
}
