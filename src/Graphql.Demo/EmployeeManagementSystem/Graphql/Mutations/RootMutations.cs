using GraphQL.Types;

namespace EmployeeManagementSystem.Graphql.Mutations
{
    public class RootMutations : ObjectGraphType
    {
        public RootMutations()
        {
            Name = "Mutations";
            Field<EmployeeMutations>("employees", resolve: context => new { });
            Field<DepartmentMutations>("deparments", resolve: context => new { });
        }
    }
}
