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


    }
}
