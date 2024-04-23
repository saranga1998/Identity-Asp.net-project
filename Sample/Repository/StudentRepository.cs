using Microsoft.EntityFrameworkCore;
using Sample.Data;
using Sample.Interface;
using Sample.Models;
using Sample.ViewModel;

namespace Sample.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _applicationDb;

        public StudentRepository(ApplicationDbContext applicationDb)
        {
            _applicationDb = applicationDb;
        }
        public async Task AddStudent(StudentViewModel student)
        {
            await _applicationDb.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT dbo.Departments ON");
            var NewStudent = new Models.Student()
            {
                Name = student.Name,
                Address = student.Address,
                DepartmentId = student.DepartmentId,
            };

            await _applicationDb.Students.AddAsync(NewStudent);
            await _applicationDb.SaveChangesAsync();
            await _applicationDb.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT dbo.Departments OFF");
        }
    }
}
