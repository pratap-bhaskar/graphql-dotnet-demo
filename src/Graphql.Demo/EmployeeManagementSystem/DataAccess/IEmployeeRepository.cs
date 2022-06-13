using EmployeeManagementSystem.DataAccess.Models;

namespace EmployeeManagementSystem.DataAccess
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();
        Employee? GetById(int id);
        Employee Add(Employee employee);
        IEnumerable<Employee> GetByDepartmentId(int departmentId);
        IEnumerable<Employee> GetReportees(int mangerId);
    }
}
