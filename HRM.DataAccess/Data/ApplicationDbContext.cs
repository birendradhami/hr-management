using HRM.Models;
using Microsoft.EntityFrameworkCore;

namespace HRM.DataAccess.Data;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
                   

        } public DbSet<Employee> Employees { get; set; }
          public DbSet<Designation>Designations { get; set; }
          public DbSet<Department> Departments { get; set; }
    }

