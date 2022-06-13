using EmployeeManagementSystem.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.DataAccess
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;
        public EmployeeRepository(IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                dbContext.Database.EnsureCreated();
            }            
        }

        public Employee Add(Employee employee)
        {
            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                employee.Id = dbContext.Employees.Max(a => a.Id) + 1;

                dbContext.Employees.Add(employee);
                dbContext.SaveChanges();
                return employee;
            }
        }

        public IEnumerable<Employee> GetAll()
        {
            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                return dbContext.Employees.ToList();
            }
        }

        public IEnumerable<Employee> GetByDepartmentId(int departmentId)
        {
            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                return dbContext.Employees.Where(a => a.DepartmentId == departmentId).ToList();
            }
        }

        public Employee? GetById(int id)
        {
            using(var dbContext = _dbContextFactory.CreateDbContext())
            {
                return dbContext.Employees.Find(id);
            }
        }

        public IEnumerable<Employee> GetReportees(int mangerId)
        {
            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                return dbContext.Employees.Where(a => a.ManagerId == mangerId);
            }
        }
    }
}
