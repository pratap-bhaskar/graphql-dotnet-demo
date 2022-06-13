using EmployeeManagementSystem.DataAccess;
using EmployeeManagementSystem.DataAccess.Models;
using EmployeeManagementSystem.Graphql.Types;
using GraphQL;
using GraphQL.Types;

namespace EmployeeManagementSystem.Graphql.Mutations
{
    public class DepartmentMutations : ObjectGraphType
    {
        public DepartmentMutations(IDepartmentRepository departmentRepository)
        {
            Field<DepartmentType>(
                "createDepartment",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<DepartmentInputType>> { Name = "department" }
                ),
                resolve: context =>
                {
                    var department = context.GetArgument<Department>("department");
                    return departmentRepository.Create(department);
                });
        }
    }
}
