using System.ComponentModel.DataAnnotations.Schema;

namespace Sample.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Address { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; } //Foreign Key
        public Department? Department { get; set; }
    }
}
