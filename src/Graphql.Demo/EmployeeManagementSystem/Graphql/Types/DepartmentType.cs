using EmployeeManagementSystem.DataAccess;
using EmployeeManagementSystem.DataAccess.Models;
using GraphQL.Types;

namespace EmployeeManagementSystem.Graphql.Types
{
    public class DepartmentType : ObjectGraphType<Department>
    {
        public DepartmentType(IEmployeeRepository employeeRepository)
        {
            Field(x => x.Id).Description("Department ID");
            Field(x => x.Name).Description("Department Name");
            Field(x => x.Company).Description("Company Name");

            Field<ListGraphType<EmployeeType>>(
                "employees",
                resolve: context => employeeRepository.GetByDepartmentId(context.Source.Id)
            );
        }
    }
}
