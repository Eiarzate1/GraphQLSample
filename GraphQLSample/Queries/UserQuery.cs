using GraphQL.Types;
using GraphQLSample.DataAccess.Repositories.Contracts;
using GraphQLSample.Types.User;

namespace GraphQLSample.Queries
{
    public class UserQuery: ObjectGraphType
    {
        public UserQuery(IUserRepository userRepository)
        {
            Field<ListGraphType<UserType>>(
                "users",
                resolve: context => userRepository.GetAll());

            Field<UserType>(
                "user",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context => userRepository.GetById(context.GetArgument<int>("id")));
        }
       
    }
}
