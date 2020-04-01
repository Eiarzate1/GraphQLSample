using GraphQL;
using GraphQLSample.Mutations;
using GraphQLSample.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLSample.Schema
{
    public class GraphQLSampleSchema: GraphQL.Types.Schema
    {
        public GraphQLSampleSchema(IDependencyResolver resolver): base(resolver)
        {
            Query = resolver.Resolve<UserQuery>();
            Mutation = resolver.Resolve<UserMutation>();
        }
    }
}
