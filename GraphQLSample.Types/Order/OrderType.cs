using GraphQL.Types;

namespace GraphQLSample.Types.Order
{
    public class OrderType : ObjectGraphType<GraphQLSample.Database.Models.Order>
    {

        public OrderType()
        {
            Field(x => x.Id);
            Field(x => x.Amount);
            Field(x => x.DatePlaced);
            Field(x => x.DateShipped);
            Field(x => x.DateArrived);
        }
    }
}
