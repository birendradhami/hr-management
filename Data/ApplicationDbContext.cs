using hr_management.Models;
using Microsoft.EntityFrameworkCore;

namespace hr_management.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
