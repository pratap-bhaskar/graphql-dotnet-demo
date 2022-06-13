using EmployeeManagementSystem.DataAccess.Models;
using GraphQL.Types;

namespace EmployeeManagementSystem.Graphql.Types
{
    public class EmployeeInputType : InputObjectGraphType<Employee>
    {
        public EmployeeInputType()
        {
            Name = "EmployeeInput";
            Field<NonNullGraphType<StringGraphType>>("firstName");
            Field<NonNullGraphType<StringGraphType>>("lastName");
            Field<NonNullGraphType<IntGraphType>>("departmentId");
            Field<NonNullGraphType<IntGraphType>>("managerId");
            Field<NonNullGraphType<StringGraphType>>("designation");
        }
    }
}
