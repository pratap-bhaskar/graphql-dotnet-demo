using GraphQL.Types;

namespace EmployeeManagementSystem.Graphql.Queries
{
    public class RootQuery : ObjectGraphType
    {
        public RootQuery()
        {
            Name = "RootQuery";
            //Aggregate multiple queries into a Single root query
            Field<EmployeeQuery>("employees", resolve: context => new { });
            Field<DepartmentQuery>("departments", resolve: context => new { });
        }
    }
}
