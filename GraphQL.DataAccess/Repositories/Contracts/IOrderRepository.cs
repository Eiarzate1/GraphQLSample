using GraphQLSample.Database.Models;
using System.Collections.Generic;

namespace GraphQLSample.DataAccess.Repositories.Contracts
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAllForUser(int userId);
        IEnumerable<Order> GetAllForUser(int userId, int lastAmount);
    }
}
