using GraphQL.Types;
using GraphQLSample.DataAccess.Repositories.Contracts;
using GraphQLSample.Types.Order;

namespace GraphQLSample.Types.User
{
    public class UserType: ObjectGraphType<GraphQLSample.Database.Models.User>
    {
        public UserType(IOrderRepository orderRepository)
        {
            Field(x => x.Id);
            Field(x => x.FirstName);
            Field(x => x.LastName);
            Field(x => x.DateOfBirth);
            Field<ListGraphType<OrderType>>("orders", 
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "last"}),
                resolve: context => {
                    var lastItemsFilter = context.GetArgument<int?>("last");
                    return lastItemsFilter != null
                        ? orderRepository.GetAllForUser(context.Source.Id, lastItemsFilter.Value)
                        : orderRepository.GetAllForUser(context.Source.Id);
                 });
        }
    }
}
