using EmployeeManagementSystem.DataAccess;
using EmployeeManagementSystem.DataAccess.Models;
using GraphQL.Types;

namespace EmployeeManagementSystem.Graphql.Types
{
    public class EmployeeType : ObjectGraphType<Employee>
    {
        public EmployeeType(IEmployeeRepository employeeRepository)
        {
            Field(x => x.Id).Description("The id of the employee");
            Field(x => x.FirstName).Description("First name of the employee");
            Field(x => x.LastName).Description("Last name of the employee");
            Field(x => x.FullName).Description("Full name of the employee");
            Field(x => x.DepartmentId, nullable: true, type: typeof(IntGraphType)).Description("DeparmentId of the employee");
            Field(x => x.ManagerId, nullable: true, type: typeof(IntGraphType)).Description("ManagerId of the employee");
            Field(x => x.Designation).Description("Designation of the employee");
        }
    }
}
