using HRM.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HRM.DataAccess.Data;

    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
                   

        } public DbSet<Employee> Employees { get; set; }
          public DbSet<Designation>Designations { get; set; }
          public DbSet<Department> Departments { get; set; }

    public void SaveChanges(Employee obj)
    {
        throw new NotImplementedException();
    }
}

