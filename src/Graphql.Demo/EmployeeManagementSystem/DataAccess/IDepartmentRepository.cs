using EmployeeManagementSystem.DataAccess.Models;

namespace EmployeeManagementSystem.DataAccess
{
    public interface IDepartmentRepository
    {
        Department? GetById(int departmentId);
        Department Create(Department department);
        IEnumerable<Department> GetAll();
    }
}
