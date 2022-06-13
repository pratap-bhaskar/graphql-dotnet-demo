namespace EmployeeManagementSystem.DataAccess.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public int? DepartmentId { get; set; }
        public int? ManagerId { get; set; }
        public string Designation { get; set; }
    }
}
