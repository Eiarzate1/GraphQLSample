using GraphQLSample.DataAccess.Repositories.Contracts;
using GraphQLSample.Database;
using GraphQLSample.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphQLSample.DataAccess.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly GraphQLSampleContext _dbContext;

        public OrderRepository(GraphQLSampleContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Order> GetAllForUser(int userId)
        {
            return _dbContext.Orders.Where(x => x.UserId == userId);
        }

        public IEnumerable<Order> GetAllForUser(int userId, int lastAmount)
        {
            return _dbContext.Orders.Where(x => x.UserId == userId)
                .OrderByDescending(x => x.DatePlaced)
                .Take(lastAmount);
        }
    }
}
