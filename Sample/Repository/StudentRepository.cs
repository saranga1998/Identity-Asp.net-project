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

        public async Task DeleteStudent(int id)
        {
            var DeleteStudent = await _applicationDb.Students.FindAsync(id);

            if (DeleteStudent != null)
            {
                _applicationDb.Remove(DeleteStudent);
                await _applicationDb.SaveChangesAsync();
            }
        }

        public async Task<List<Models.Department>> GetallDepartment()
        {
            return await _applicationDb.Departments.ToListAsync();
            
        }

        public async Task<StudentViewModel> StudentGetById(int id)
        {
            var student = await _applicationDb.Students.FindAsync(id);

            var studentViewModel = new StudentViewModel
            {
                Id = student.Id,
                DepartmentId = student.DepartmentId,
                Name = student.Name,
                Address = student.Address,
            };

            return studentViewModel;
        }

        public async Task UpdateStudent(StudentViewModel student)
        {
            var updateStudent = await _applicationDb.Students.FindAsync(student.Id);

            if (updateStudent != null)
            {
                
                updateStudent.Name = student.Name;
                updateStudent.Address =student.Address;
                updateStudent.DepartmentId = student.DepartmentId;
                _applicationDb.Update(updateStudent);
                await _applicationDb.SaveChangesAsync();
            }
        }

        public async Task<List<StudentViewModel>> ViewAllStudents()
        {
            var students = await _applicationDb.Students.ToListAsync();

            List<StudentViewModel> departmentViewModels = new List<StudentViewModel>();

            foreach (var student in students)
            {
                var result = new StudentViewModel
                {
                    Id=student.Id,
                    Name = student.Name,
                    Address = student.Address,
                    DepartmentId=student.DepartmentId
                };

                departmentViewModels.Add(result);
            }

            return departmentViewModels;
        }
    }
}
