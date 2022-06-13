using EmployeeManagementSystem.DataAccess;
using EmployeeManagementSystem.DataAccess.Models;
using EmployeeManagementSystem.Graphql.Types;
using GraphQL;
using GraphQL.Types;

namespace EmployeeManagementSystem.Graphql.Queries
{
    public class EmployeeQuery : ObjectGraphType
    {
        public EmployeeQuery(IEmployeeRepository employeeRepository)
        {
            Name = "EmployeeQuery";

            Field<EmployeeType>(
                "one",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "employeeId" }),
                resolve: context => employeeRepository.GetById(context.GetArgument<int>("employeeId")));

            Field<ListGraphType<EmployeeType>>(
                "all",
                resolve: context => employeeRepository.GetAll()
                );

            Field<ListGraphType<EmployeeType>>(
                "byDepartment",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "departmentId" }),
                resolve: context => employeeRepository.GetByDepartmentId(context.GetArgument<int>("departmentId"))
                );
        }
    }
}
