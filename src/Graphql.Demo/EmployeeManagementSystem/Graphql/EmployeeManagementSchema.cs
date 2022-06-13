using EmployeeManagementSystem.Graphql.Mutations;
using EmployeeManagementSystem.Graphql.Queries;
using GraphQL.Types;

namespace EmployeeManagementSystem.Graphql
{
    public class EmployeeManagementSchema : Schema
    {
        public EmployeeManagementSchema(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<RootQuery>();
            Mutation = serviceProvider.GetRequiredService<RootMutations>();
        }
    }
}
