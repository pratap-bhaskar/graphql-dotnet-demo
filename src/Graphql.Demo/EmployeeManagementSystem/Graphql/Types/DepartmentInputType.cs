using EmployeeManagementSystem.DataAccess.Models;
using GraphQL.Types;

namespace EmployeeManagementSystem.Graphql.Types
{
    public class DepartmentInputType : InputObjectGraphType<Department>
    {
        public DepartmentInputType()
        {
            Name = "DepartmentInput";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<StringGraphType>>("company"); 
        }
    }
}
