using EmployeeManagementSystem.DataAccess;
using EmployeeManagementSystem.DataAccess.Models;
using EmployeeManagementSystem.Graphql.Types;
using GraphQL;
using GraphQL.Types;

namespace EmployeeManagementSystem.Graphql.Mutations
{
    public class EmployeeMutations : ObjectGraphType
    {
        public EmployeeMutations(IEmployeeRepository employeeRepository)
        {
            Field<EmployeeType>(
                "createEmployee",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<EmployeeInputType>> { Name = "employee" }
                ),
                resolve: context =>
                {
                    var employee = context.GetArgument<Employee>("employee");
                    return employeeRepository.Add(employee);
                });
        }
    }
}
