using GraphQL.Types;
using GraphQLSample.DataAccess.Repositories.Contracts;
using GraphQLSample.Database.Models;
using GraphQLSample.Types.User;

namespace GraphQLSample.Mutations
{
    public class UserMutation : ObjectGraphType
    {
        
        public UserMutation(IUserRepository userRepository)
        {
            Field<UserType>(
                "addUser",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<UserInputType>> { Name = "user" }),
                resolve: context =>
                {
                    var user = context.GetArgument<User>("user");
                    return userRepository.Add(user);
                }
            );
        }
    }
}
