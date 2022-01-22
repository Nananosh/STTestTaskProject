using Microsoft.EntityFrameworkCore;
using STTestTaskProject.Models;

namespace STTestTaskProject.Migrations
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Staff> Staffs { get; set; }
    }
}