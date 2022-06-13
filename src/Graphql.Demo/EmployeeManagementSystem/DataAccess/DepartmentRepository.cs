using EmployeeManagementSystem.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.DataAccess
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

        public DepartmentRepository(IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                dbContext.Database.EnsureCreated();
            }
        }
        
        public Department Create(Department department)
        {
            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                var latestId = dbContext.Departments.Max(x => x.Id) + 1;
                department.Id = latestId;
                
                dbContext.Departments.Add(department);
                dbContext.SaveChanges();
                return department;
            }
        }

        public IEnumerable<Department> GetAll()
        {
            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                return dbContext.Departments.ToList();
            }
        }

        public Department? GetById(int departmentId)
        {
            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                return dbContext.Departments.Find(departmentId);
            }
        }
    }
}
