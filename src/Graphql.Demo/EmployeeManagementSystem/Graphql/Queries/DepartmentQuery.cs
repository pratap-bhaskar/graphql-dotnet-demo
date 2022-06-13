using EmployeeManagementSystem.DataAccess;
using EmployeeManagementSystem.DataAccess.Models;
using EmployeeManagementSystem.Graphql.Types;
using GraphQL;
using GraphQL.Types;

namespace EmployeeManagementSystem.Graphql.Queries
{
    public class DepartmentQuery : ObjectGraphType
    {
        public DepartmentQuery(IDepartmentRepository departmentRepository)
        {
            Name = "DepartmentQuery";

            Field<ListGraphType<DepartmentType>>(
                "all",
                resolve: context => departmentRepository.GetAll()
                );

            Field<DepartmentType>(
                "one",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "id", Description = "The id of the department." }
                ),
                resolve: context => departmentRepository.GetById(context.GetArgument<int>("id"))
                );
        }
    }
}
