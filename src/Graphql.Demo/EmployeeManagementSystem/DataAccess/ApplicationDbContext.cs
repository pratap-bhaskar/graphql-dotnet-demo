using EmployeeManagementSystem.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var financeDept = new Department { Id = 1, Name = "Finance" , Company = "Acme"};
            var hrDept = new Department { Id = 2, Name = "HR", Company = "Acme" };

            modelBuilder.Entity<Department>().HasData(financeDept, hrDept);

            var andyCEO = new Employee { Id = 1, FirstName = "Andy", LastName = "Smith", Designation = "CEO" };

            //Adding employees to finance
            var brewerFromFinance = new Employee { Id = 2, FirstName = "Brewer", LastName = "Manny", DepartmentId = 1, Designation = "Vice President", ManagerId = 1 };
            var tomCruiseFromFinance = new Employee { Id = 3, FirstName = "Tom", LastName = "Cruise", DepartmentId = 1, Designation = "Lead Accountant", ManagerId = 2 };
            //Adding employees to HR Dept
            var gregFromHR = new Employee { Id = 4, FirstName = "Gregory", LastName = "Soprano", DepartmentId = 2, Designation = "HR Director", ManagerId = 1 };
            var LeiaFromFinance = new Employee { Id = 5, FirstName = "Leia", LastName = "Skywalker", DepartmentId = 2, Designation = "HR Manager", ManagerId = 4 };

            modelBuilder.Entity<Employee>().HasData(andyCEO, brewerFromFinance, tomCruiseFromFinance,
                gregFromHR, LeiaFromFinance);
        }
    }
}
