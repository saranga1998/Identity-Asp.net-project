using Sample.ViewModel;

namespace Sample.Interface
{
    public interface IDepartmentRepository
    {

        Task AddDepartment(DepartmentViewModel Department);
        Task  <List<DepartmentViewModel>> ViewAllDepartment();
        //Task<ZoneViewModel> GetByIdAsync(string id);
        //Task<List<ZoneViewModel>> GetAllAsync();

        //Task UpdateAsync(ZoneViewModel zone);
    }
}
