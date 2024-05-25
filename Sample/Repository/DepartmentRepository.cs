using Microsoft.EntityFrameworkCore;
using Sample.Data;
using Sample.Interface;
using Sample.ViewModel;
using System;

namespace Sample.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _applicationDb;
        public DepartmentRepository(ApplicationDbContext ApplicationDb) {
        
            _applicationDb = ApplicationDb;
        }

        //Add Department
        public async Task AddDepartment(DepartmentViewModel Department)
        {
            await _applicationDb.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT dbo.Departments ON");
            var NewDepartment = new Models.Department()
            {
                //DepartmentId = Department.DepartmentId,
                Name = Department.Name
            };

            await _applicationDb.Departments.AddAsync(NewDepartment);
            await _applicationDb.SaveChangesAsync();
            await _applicationDb.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT dbo.Departments OFF");
        }

        

        //View All Department
        public async Task<List<DepartmentViewModel>> ViewAllDepartment()
        {
            var departments = await _applicationDb.Departments.ToListAsync();

            List<DepartmentViewModel> departmentViewModels = new List<DepartmentViewModel>();

            foreach (var department in departments)
            {
                var result = new DepartmentViewModel
                {
                    DepartmentId = department.DepartmentId,
                    Name = department.Name,
                };

                departmentViewModels.Add(result);
            }

            return departmentViewModels;
        }

        //Edit using Department Id
        public async Task<DepartmentViewModel> DepatmentGetById(int id)
        {
            var department = await _applicationDb.Departments.FindAsync(id);

            var departmentViewModel = new DepartmentViewModel
            {
                DepartmentId = department.DepartmentId, 
                Name = department.Name
            };

            return departmentViewModel;

        }

        public async Task UpdateDepartment(DepartmentViewModel Department)
        {
            var updateDepartment = await _applicationDb.Departments.FindAsync(Department.DepartmentId);

            if (updateDepartment != null)
            {
                updateDepartment.DepartmentId = Department.DepartmentId;
                updateDepartment.Name = Department.Name;
                _applicationDb.Update(updateDepartment);
                await _applicationDb.SaveChangesAsync();
            }
            

            
        }

        public async Task DeleteDepartment(int DepatmentId)
        {
            var DeleteDepartment = await _applicationDb.Departments.FindAsync(DepatmentId);

            if (DeleteDepartment != null)
            {
                _applicationDb.Remove(DeleteDepartment);
                await _applicationDb.SaveChangesAsync();
            }

            
        }
    }
}
