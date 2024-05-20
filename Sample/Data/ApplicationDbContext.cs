using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sample.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace Sample.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DbSet<Student> Students { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DbSet<Department> Departments { get; set; }
    }
}
